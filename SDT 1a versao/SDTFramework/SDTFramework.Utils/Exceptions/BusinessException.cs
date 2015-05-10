using System;

namespace SDTFramework.Utils.Exceptions
{
    public class BusinessException : BaseException
    {
        private readonly bool _isAjaxResponse;

        public bool IsAjaxResponse { get { return _isAjaxResponse; } }

        public BusinessException(string message, params object[] obj) 
            : base(message)
        {
            _isAjaxResponse = true;
            SetDataField(obj);
        }

        public BusinessException(string message, bool isAjaxResponse, params object[] obj) 
            : base(message)
        {
            _isAjaxResponse = isAjaxResponse;
            SetDataField(obj);
        }

        public BusinessException(string message, Exception inner, params object[] obj) 
            : base(message, inner)
        {
            _isAjaxResponse = true;
            SetDataField(obj);
        }

        public BusinessException(string message, Exception inner, bool isAjaxResponse, params object[] obj)
            : base(message, inner)
        {
            _isAjaxResponse = isAjaxResponse;
            SetDataField(obj);
        }

        public virtual bool Internationalized { get { return true; } }

        private void SetDataField(params object[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
                Data.Add(i, obj[i]);
        }
    }
}
