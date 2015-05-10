using System;
using System.Runtime.Serialization;

namespace SDTFramework.Utils.Exceptions
{
    [Serializable]
    public class BaseException : Exception
    {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
        public BaseException(string message, Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
