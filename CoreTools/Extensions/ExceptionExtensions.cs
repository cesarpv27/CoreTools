using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;

namespace CoreTools.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception PrepareForRethrow(this Exception exception)
        {
            if (exception.InnerException == null)
            {
                ExceptionDispatchInfo.Capture(exception).Throw();

                // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
                //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
                return exception;
            }

            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();

            // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
            //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
            return exception.InnerException;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="separator">If null, the default separator will be used. Default separator: ' --> '</param>
        /// <returns></returns>
        public static string GetDepthMessages(this Exception exception, string separator = null)
        {
            separator = GetSeparator(separator);

            var message = exception.Message;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                message += separator + exception.Message;
            }
            if (!string.IsNullOrEmpty(message))
                message = message.ReplaceBreakLinesWithNewLines();

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="separator">If null, the default separator will be used. Default separator: ' --> '</param>
        /// <returns></returns>
        public static string GetDepthStackTraces(this Exception exception, string separator = null)
        {
            separator = GetSeparator(separator);

            var stackTrace = exception.StackTrace;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                stackTrace += separator + exception.StackTrace;
            }
            if (!string.IsNullOrEmpty(stackTrace))
                stackTrace = stackTrace.ReplaceBreakLinesWithNewLines();

            return stackTrace;
        }

        private static string GetSeparator(string userSeparator)
        {
            if (string.IsNullOrEmpty(userSeparator))
                userSeparator = GetDefaultSeparator();

            return userSeparator;
        }

        private static string GetDefaultSeparator()
        {
            return " --> ";
        }
    }
}
