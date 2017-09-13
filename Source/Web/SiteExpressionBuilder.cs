using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace WebPx.Web
{
    [ExpressionPrefix("Site")]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class SiteExpressionBuilder : ExpressionBuilder
    {
        public SiteExpressionBuilder()
        {

        }

        public override object ParseExpression(string expression, Type propertyType, ExpressionBuilderContext context)
        {
            var regEx = new Regex(@"^([A-Z])\w+$");
            if (regEx.IsMatch(expression))
                return ValidateExpression(expression);
            else
                throw new HttpException(String.Format($"Invalid Site Expression expression - '{expression}'."));
        }

        private static PropertyInfo[] _properties = null;

        private object ValidateExpression(string expression)
        {
            PropertyInfo[] properties = _properties;
            if (properties == null)
            {
                var type = typeof(Site);
                properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty);
                _properties = properties;
            }
            foreach (var property in properties)
                if (property.Name.Equals(expression, StringComparison.OrdinalIgnoreCase))
                    return property.Name;
            throw new HttpCompileException($"Site Expression: Member {expression} doesn't exist.");
        }

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(Site)), (string)parsedData);
        }

        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }

        public override object EvaluateExpression(object target, BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return (string)parsedData;
        }
    }
}
