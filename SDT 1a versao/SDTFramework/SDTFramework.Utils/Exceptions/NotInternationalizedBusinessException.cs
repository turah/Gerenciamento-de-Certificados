namespace SDTFramework.Utils.Exceptions
{
    public class NotInternationalizedBusinessException : BusinessException
    {
        public NotInternationalizedBusinessException(string message, params object[] obj) : base(message, obj) { }
        public NotInternationalizedBusinessException(string message, bool isAjaxResponse, params object[] obj) : base(message, isAjaxResponse, obj) { }
        public override bool Internationalized { get { return false; } }
    }
}
