using System;
using System.Diagnostics;

namespace SDTFramework.Utils.Exceptions
{
    public static class SDTExceptionUtils
    {
        public static SDTExceptionDTO GetExceptionInfo(Exception ex)
        {
            var info = new SDTExceptionDTO();

            try
            {
                var trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(0);

                for (int i = 0; i < trace.FrameCount; i++)
                {
                    var f = trace.GetFrame(i);
                    if (f.GetFileName() != null)
                    {
                        stackFrame = f;
                        break;
                    }
                }

                if (trace.FrameCount == 0)
                {
                    return info;
                }

                if (stackFrame.GetFileName() == null)
                {
                    info.ClassName = ex.TargetSite.ReflectedType.Name;
                    info.MehtodName = ex.TargetSite.Name;
                    info.Message = ex.Message;
                }
                else
                {
                    // Collect data where exception occured
                    string[] splitFile = stackFrame.GetFileName().Split('\\');

                    info.ClassName = splitFile.Length > 0 ? splitFile[splitFile.Length - 1] : string.Empty;
                    info.MehtodName = stackFrame.GetMethod().Name;
                    info.Message = ex.Message;
                    info.Line = stackFrame.GetFileLineNumber();
                }
            }
            catch
            {

            }

            return info;
        }
    }
}
