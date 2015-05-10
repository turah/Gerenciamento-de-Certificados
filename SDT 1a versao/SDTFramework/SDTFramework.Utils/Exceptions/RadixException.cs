using System;
using System.Runtime.Serialization;

namespace SDTFramework.Utils.Exceptions
{
    public class RadixException : BaseException
    {
        public RadixException() { }
        public RadixException(string message) : base(message) { }
        public RadixException(string message, Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        protected RadixException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
