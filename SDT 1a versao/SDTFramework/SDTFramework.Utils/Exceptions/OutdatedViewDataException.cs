using System;

namespace SDTFramework.Utils.Exceptions
{
    [Serializable]
    public class OutdatedViewDataException : BusinessException
    {
        public OutdatedViewDataException() : base(string.Empty) { }
    }
}
