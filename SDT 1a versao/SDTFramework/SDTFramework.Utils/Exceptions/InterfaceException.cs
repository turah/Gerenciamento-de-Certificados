using System;
using System.Runtime.Serialization;

namespace SDTFramework.Utils.Exceptions
{
    [Serializable]
    public class InterfaceException : Exception
    {
        public InterfaceException() { }
        public InterfaceException(string message) : base(message) { }
        public InterfaceException(string message, Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        protected InterfaceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
