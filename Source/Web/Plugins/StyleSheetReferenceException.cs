using System;
using System.Runtime.Serialization;

namespace WebPx.Web.Plugins
{
    [Serializable]
    public sealed class StyleSheetReferenceException : Exception
    {
        public StyleSheetReferenceException()
        {
        }

        public StyleSheetReferenceException(string message) : base(message)
        {
        }

        public StyleSheetReferenceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StyleSheetReferenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}