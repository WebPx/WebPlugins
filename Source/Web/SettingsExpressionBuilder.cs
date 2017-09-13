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
    [ExpressionPrefix("Settings")]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class SettingsExpressionBuilder : ExpressionBuilder
    {
        public SettingsExpressionBuilder()
        {

        }

        public override object ParseExpression(string expression, Type propertyType, ExpressionBuilderContext context)
        {
            var regEx = new Regex(@"^([A-Z])\w+$");
            if (regEx.IsMatch(expression))
                return ValidateExpression(expression);
            else
                throw new HttpException(String.Format($"Invalid Settings Expression expression - '{expression}'."));
        }

        private object ValidateExpression(string expression)
        {
            if (Settings.HasKey(expression))
                return expression;
            throw new HttpCompileException($"Settings Expression: '{expression}' doesn't exist.");
        }

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(typeof(Settings)), "GetValue", new CodePrimitiveExpression(parsedData));
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
