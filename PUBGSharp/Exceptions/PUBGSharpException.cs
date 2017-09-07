using System;
using System.Runtime.Serialization;

namespace PUBGSharp.Exceptions
{
    [Serializable]
    public class PUBGSharpException : Exception
    {
        public PUBGSharpException() : base()
        {
        }

        public PUBGSharpException(string message) : base(message)
        {
        }

        public PUBGSharpException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public PUBGSharpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PUBGSharpException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
        }

        protected PUBGSharpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}