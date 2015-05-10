using System;
using System.Collections;
using NLog;
using SDTFramework.Utils.Exceptions;

namespace SDTFramework.Utils.Log
{
    public class Logger
    {
        private readonly string _class = string.Empty;
        private readonly NLog.Logger _log;

        public Logger(Type type)
        {
            _log = LogManager.GetLogger("logfile");
            _class = type.FullName;
        }

        public void Debug(string message)
        {
            _log.Debug(string.Format("{0}: {1}", _class, message));
        }

        public void Info(string message)
        {
            _log.Info(string.Format("{0}: {1}", _class, message));
        }

        public void Fatal(string message)
        {
            _log.Fatal(string.Format("{0}: {1}", _class, message));
        }

        public void Warn(string message)
        {
            _log.Warn(string.Format("{0}: {1}", _class, message));
        }

        public void Fatal(string message, Exception ex)
        {
            _log.Fatal(string.Format("{0}: {1}", _class, message), ex);
        }

        public void Error(string message)
        {
            _log.Error(string.Format("{0}: {1}", _class, message));
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(string.Format("{0}: {1}", _class, message), ex);
        }

        public void SQLError(string queryString, ArrayList paramsList, BaseException ex)
        {
            string @params = "[";
            int count = 0;

            if (((paramsList == null)))
            {
                @params = "";
            }
            else
            {
                while (count < paramsList.Count)
                {
                    if (((paramsList[count] == null)))
                    {
                        @params = @params + "null";
                    }
                    else
                    {
                        @params = @params + paramsList[count];
                    }
                    if (count != paramsList.Count - 1)
                    {
                        @params = @params + ", ";
                    }
                    count = count + 1;
                }
                @params = @params + "]";
            }
            Error("A error occurred when try to execute the query: " + queryString + " " + @params, ex);
        }

        public void SQLError(string queryString, Hashtable paramsList, BaseException ex)
        {
            string @params = "[";
            int count = 0;

            if (((paramsList == null)))
            {
                @params = "";
            }
            else
            {
                foreach (string param in paramsList.Keys)
                {
                    if (((paramsList[param] == null)))
                    {
                        @params = @params + param + " = null";
                    }
                    else
                    {
                        @params = @params + param + " = " + paramsList[param];
                    }
                    if (count != paramsList.Count - 1)
                    {
                        @params = @params + ", ";
                    }
                    count += 1;
                }
                @params = @params + "]";
            }
            Error("A error occurred when try to execute the query: " + queryString + " " + @params, ex);
        }

        public bool IsLoggingEnabled()
        {
            return _log.IsDebugEnabled || _log.IsErrorEnabled || _log.IsInfoEnabled || _log.IsWarnEnabled;
        }

        public bool IsDebugEnabled()
        {
            return _log.IsDebugEnabled;
        }

        public bool IsInfoEnabled()
        {
            return _log.IsInfoEnabled;
        }

        public bool IsWarnEnabled()
        {
            return _log.IsWarnEnabled;
        }

        public bool IsFatalEnabled()
        {
            return _log.IsFatalEnabled;
        }

        public bool IsErrorEnabled()
        {
            return _log.IsErrorEnabled;
        }
    }
}
