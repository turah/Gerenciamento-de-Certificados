using System;
using System.Runtime.Serialization;

namespace SDTFramework.Utils.Exceptions
{
    [Serializable]
    public class HandledException : Exception
    {
        public HandledException() { }
        public HandledException(string message) : base(message) { }
        public HandledException(string message, Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        protected HandledException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
