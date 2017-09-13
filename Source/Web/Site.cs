using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace WebPx.Web
{
    public static class Site
    {

        private static SitePage _home = new SitePage("Home");

        private static SitePage _logout = new SitePage("Logout");

        private static SitePage _profile = new SitePage("Profile");

        private static SitePage _register = new SitePage("Register");

        private static SitePage _recover = new SitePage("Recover");

        private static SitePage _termsOfService = new SitePage("TermsOfService");

        private static SitePage _privacyPolicy = new SitePage("PrivacyPolicy");

        public static string Home { get { return Site._home.Value ?? FormsAuthentication.DefaultUrl; } }

        public static string Login { get { return FormsAuthentication.LoginUrl; } }

        public static string Logout { get { return Site._logout.Value; } }

        public static string Profile { get { return Site._profile.Value; } }

        public static string Register { get { return Site._register.Value; } }

        public static string Recover { get { return Site._recover.Value; } }

        public static string TermsOfService { get { return Site._termsOfService.Value; } }

        public static string PrivacyPolicy { get { return Site._privacyPolicy.Value; } }

        public static string LogoUrl { get { return Settings.Provider.GetValue<string>("Site:LogoUrl"); } }

        public static string Copyright { get { return Settings.Provider.GetValue<string>("Site:Copyright"); } }

        private static bool? _canCreateAccount;

        public static bool CanCreateAccount
        {
            get
            {
                if (_canCreateAccount.HasValue == false)
                {
                    bool temp;
                    _canCreateAccount = bool.TryParse(Settings.Provider.GetValue<string>("Site:CanCreateAccount"), out temp) ? temp : true;
                }
                return _canCreateAccount.Value;
            }
        }

        private static bool? _loginExternal;

        public static bool LoginExternal
        {
            get
            {
                if (_loginExternal.HasValue == false)
                {
                    bool temp;
                    _loginExternal = bool.TryParse(Settings.Provider.GetValue<string>("Site:LoginExternal"), out temp) ? temp : true;
                }
                return _loginExternal.Value;
            }
        }
    }
}