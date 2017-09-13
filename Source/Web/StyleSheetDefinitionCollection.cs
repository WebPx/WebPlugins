using System.Collections.ObjectModel;

namespace WebPx.Web
{
    public sealed class StyleSheetDefinitionCollection : Collection<StyleSheetDefinition>
    {
        public StyleSheetDefinitionCollection()
        {

        }

        public StyleSheetDefinition this[string name]
        {
            get
            {
                //throw new System.Exception($"{name} && {this.Count}");
                foreach (var item in this)
                    if (string.Equals(item.Name, name, System.StringComparison.OrdinalIgnoreCase))
                        return item;
                return null;
            }
        }
    }
}