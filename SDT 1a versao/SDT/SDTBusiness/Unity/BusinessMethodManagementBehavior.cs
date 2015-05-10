using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Reflection;
using SDTFramework.Utils.Exceptions;
using SDTFramework.Utils.Log;

namespace SDTBusiness.Unity
{
    public class BusinessMethodManagementBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces() { return Type.EmptyTypes; }

        public bool WillExecute { get { return true; } }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Logger logWriter = new Logger(((MethodInfo)input.MethodBase).ReturnType);
            
            try
            {
                IMethodReturn result = Execute(input, getNext);
                WriteInfoLog(logWriter, input.MethodBase);
                return result;
            }
            catch (Exception ex)
            {
                
                WriteErrorLog(logWriter, ex, input.MethodBase);
                throw new BusinessException(string.Empty, ex);
            }
            finally
            {
                
            }
        }

        private static IMethodReturn Execute(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result = getNext().Invoke(input, getNext);
            if (result.Exception != null)
            {
                throw result.Exception;
            }
            return result;
        }

        private static void WriteErrorLog(Logger logWriter, Exception ex, MethodBase methodInfo)
        {
            if (!logWriter.IsErrorEnabled()) return;

            SDTExceptionUtils.GetExceptionInfo(ex);

            if (methodInfo.DeclaringType != null)
                logWriter.Error(string.Format("Type: {0}, Name: {1}, Exception: {2}",
                    methodInfo.DeclaringType.Name, methodInfo.Name, ex.Message + " : " + ex.StackTrace), ex);
        }

        private static void WriteInfoLog(Logger logWriter, MethodBase methodInfo)
        {
            if (logWriter.IsInfoEnabled() && methodInfo.DeclaringType != null)
            {
                logWriter.Info(string.Format("Type: {0}, Name: {1} ", methodInfo.DeclaringType.Name, methodInfo.Name));
            }
        }
    }
}
