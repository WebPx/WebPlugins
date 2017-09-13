using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel;

namespace WebPx.Web.Plugins.Design
{
    static class DesignerExtensions
    {
        public static void LoadConfiguration(this IConfiguration target, ConfigurationRequest request)
        {
            ArgumentValidation.NotNull("configuration", target);
            ArgumentValidation.NotNull("request", request);
            IVsHierarchy hier = VsHelper.GetCurrentHierarchy(request.ServiceProvider);
            Project proj = VsHelper.ToDteProject(hier);
            string filename = proj.FileName;
            string fullname = proj.FullName;
            string webConfigPath = null;
            foreach (var item in proj.ProjectItems)
            {
                var pItem = ((ProjectItem)item);
                if (pItem.Name == "Web.config"/* || pItem.Name == "App.config"*/)
                    for (short i = 0; i < pItem.FileCount; i++)
                    {
                        var ifilename = pItem.FileNames[i];
                        webConfigPath = ifilename;
                        break;
                    }
                if (webConfigPath != null)
                    break;
            }

            try
            {
                if (webConfigPath != null)
                {
                    string root = webConfigPath.Substring(0, webConfigPath.LastIndexOf(Path.DirectorySeparatorChar));
                    WebConfigurationFileMap fileMap = CreateFileMap(root);
                    var config = System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(fileMap, "/web.config");

                    if ((target.Dependencies & ConfigurationDependency.ConnectionString) == ConfigurationDependency.ConnectionString)
                    {
                        var connectionString = config.ConnectionStrings.ConnectionStrings[request.ConnectionStringName];
                        if (connectionString != null)
                        {
                            target.ConnectionString = connectionString.ConnectionString;
                        }
                        else
                            MessageBox.Show($"Connection String not found {request.ConnectionStringName}");
                    }

                    if ((target.Dependencies & ConfigurationDependency.StyleSheets) == ConfigurationDependency.StyleSheets)
                    {
                        var section = (Configuration.WebSection)config.GetSection("webpx/web");
                        target.StyleSheets = WebResourceManagement.GetStyleSheets(section);
                    }
                }
                else
                    MessageBox.Show("Web Config Not Found!");
            }
            catch (System.Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
                sb.AppendFormat("{0}{1}", ex.StackTrace, Environment.NewLine);
                MessageBox.Show(sb.ToString(), ex.GetType().FullName);
            }
        }

        public static System.Configuration.Configuration LoadConfiguration(ITypeDescriptorContext context)
        {
            ArgumentValidation.NotNull("context", context);
            IVsHierarchy hier = VsHelper.GetCurrentHierarchy(context);
            Project proj = VsHelper.ToDteProject(hier);
            string filename = proj.FileName;
            string fullname = proj.FullName;
            ////EnvDTE.Project proj = GetProject(soln, "Test");
            //EnvDTE.Configuration config = proj.ConfigurationManager.ActiveConfiguration;
            //EnvDTE.Properties props = config.Properties;
            ////VSLangProj.VSProject vsPrj = (VSLangProj.VSProject)proj.Object;

            //proj.

            //this.textBox1.Clear();
            //this.textBox1.AppendText(string.Format("Filename: {0}{1}", filename, Environment.NewLine));
            //this.textBox1.AppendText(string.Format("Fullname: {0}{1}", fullname, Environment.NewLine));
            string webConfigPath = null;
            foreach (var item in proj.ProjectItems)
            {
                var pItem = ((ProjectItem)item);
                //this.textBox1.AppendText(string.Format("\t{0}:{1}", pItem.Name, Environment.NewLine));
                if (pItem.Name == "Web.config"/* || pItem.Name == "App.config"*/)
                    for (short i = 0; i < pItem.FileCount; i++)
                    {
                        var ifilename = pItem.FileNames[i];
                        //this.textBox1.AppendText(string.Format("\t\t{0}{1}", ifilename, Environment.NewLine));
                        webConfigPath = ifilename;
                        break;
                    }
                if (webConfigPath != null)
                    break;
            }

            try
            {
                if (webConfigPath != null)
                {
                    string root = webConfigPath.Substring(0, webConfigPath.LastIndexOf(Path.DirectorySeparatorChar));
                    WebConfigurationFileMap fileMap = CreateFileMap(root);
                    var config = System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(fileMap, "/web.config");
                    return config;
                }
                else
                {
                    MessageBox.Show("Web Config Not Found!");
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
                sb.AppendFormat("{0}{1}", ex.StackTrace, Environment.NewLine);
                MessageBox.Show(sb.ToString(), ex.GetType().FullName);
                return null;
            }
            throw new NotImplementedException();
        }

        // Utility to map virtual directories to physical ones. 
        // In the current physical directory maps  
        // a physical sub-directory with its virtual directory. 
        // A web.config file is created for the 
        // default and the virtual directory at the appropriate level. 
        // You must create a physical directory called config at the 
        // level where your app is running. 
        static WebConfigurationFileMap CreateFileMap(string rootPath)
        {

            WebConfigurationFileMap fileMap = new WebConfigurationFileMap();

            // Get he physical directory where this app runs. 
            // We'll use it to map the virtual directories 
            // defined next.  
            string physDir = rootPath;

            // Create a VirtualDirectoryMapping object to use 
            // as the root directory for the virtual directory 
            // named config.  
            // Note: you must assure that you have a physical subdirectory 
            // named config in the curremt physical directory where this 
            // application runs.
            VirtualDirectoryMapping vDirMap = new VirtualDirectoryMapping(physDir, true);

            // Add vDirMap to the VirtualDirectories collection  
            // assigning to it the virtual directory name.
            //fileMap.VirtualDirectories.Add("/config", vDirMap);

            // Create a VirtualDirectoryMapping object to use 
            // as the default directory for all the virtual  
            // directories.
            VirtualDirectoryMapping vDirMapBase = new VirtualDirectoryMapping(physDir, true, "web.config");

            // Add it to the virtual directory mapping collection.
            fileMap.VirtualDirectories.Add("/", vDirMapBase);

            //# if DEBUG
            //            // Test at debug time. 
            //            foreach (string key in fileMap.VirtualDirectories.AllKeys)
            //            {
            //                Console.WriteLine("Virtual directory: {0} Physical path: {1}",
            //                fileMap.VirtualDirectories[key].VirtualDirectory,
            //                fileMap.VirtualDirectories[key].PhysicalDirectory);
            //            }
            //# endif

            // Return the mapping. 
            return fileMap;

        }

    }
}
