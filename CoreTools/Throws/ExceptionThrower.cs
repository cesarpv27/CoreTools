using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTools.Throws
{
    public class ExceptionThrower
    {
        #region Properties

        private static ExceptionThrower _exThrower;
        private static ExceptionThrower ExThrower
        {
            get
            {
                if (_exThrower == null)
                    _exThrower = new ExceptionThrower();

                return _exThrower;
            }
        }

        #endregion

        #region Static throw's methods

        public static void ST_ThrowIfArgumentIsNull<T>(T arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsNull(arg, paramName, message);
        }

        public static void ST_ThrowArgumentException(string paramName = null, string message = null)
        {
            ExThrower.ThrowArgumentException(paramName, message);
        }

        public static void ST_ThrowIfArgumentIsNullOrEmpty(string arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsNullOrEmpty(arg, paramName, message);
        }

        public static void ST_ThrowIfArgumentIsNullOrWhitespace(string arg, string paramName, string message)
        {
            ExThrower.ThrowIfArgumentIsNullOrWhitespace(arg, paramName, message);
        }

        public static void ST_ThrowIfArgumentIsNullOrEmptyOrWhitespace(string arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsNullOrEmptyOrWhitespace(arg, paramName, message);
        }


        public static void ST_ThrowArgumentNullException(string paramName = null, string message = null)
        {
            ExThrower.ThrowArgumentNullException(paramName, message);
        }

        public static void ST_ThrowNullReferenceException(string message)
        {
            ExThrower.ThrowNullReferenceException(message);
        }

        public static void ST_ThrowInvalidOperationException(string message)
        {
            ExThrower.ThrowInvalidOperationException(message);
        }

        public static void ST_ThrowNotImplementedException(Enum enumToGetNameValue)
        {
            ST_ThrowNotImplementedException(Texting.Texting.GetNameValue(enumToGetNameValue));
        }
        public static void ST_ThrowNotImplementedException(string message)
        {
            ExThrower.ThrowNotImplementedException(message);
        }

        public static void ST_ThrowApplicationException(string message)
        {
            ExThrower.ThrowApplicationException(message);
        }

        public static void ST_ThrowIfGuidArgumentIsEmpty(Guid arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfGuidArgumentIsEmpty(arg, paramName, message);
        }

        public static void ST_ThrowIfArgumentIsOutOfRange<T>(T arg, Func<T, bool> isOutRangeFunc, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsOutOfRange(arg, isOutRangeFunc, paramName, message);
        }

        public static void ST_ThrowArgumentOutOfRangeException(string paramName = null, string message = null)
        {
            ExThrower.ThrowArgumentOutOfRangeException(paramName, null, message);
        }

        public static void ST_ThrowArgumentOutOfRangeException(Enum enumToGetNameValue, string message = null)
        {
            ExThrower.ThrowArgumentOutOfRangeException(Texting.Texting.GetNameValue(enumToGetNameValue), enumToGetNameValue, message);
        }

        #endregion

        #region Throwers methods

        public virtual void ThrowIfArgumentIsNull<T>(T arg, string paramName, string message)
        {
            if (arg == null)
                ThrowArgumentNullException(paramName, message);
        }

        public virtual void ThrowIfArgumentIsNullOrEmptyOrWhitespace(string arg, string paramName, string message)
        {
            ThrowIfArgumentIsNullOrEmpty(arg, paramName, message);
            ThrowIfArgumentIsNullOrWhitespace(arg, paramName, message);
        }

        public virtual void ThrowIfArgumentIsNullOrEmpty(string arg, string paramName, string message)
        {
            if (string.IsNullOrEmpty(arg))
                ThrowArgumentNullException(paramName, message);
        }

        public virtual void ThrowIfArgumentIsNullOrWhitespace(string arg, string paramName, string message)
        {
            if (string.IsNullOrWhiteSpace(arg))
                ThrowArgumentNullException(paramName, message);
        }

        public virtual void ThrowIfGuidArgumentIsEmpty(Guid arg, string paramName, string message)
        {
            if (arg.Equals(Guid.Empty))
                ThrowArgumentException(paramName, message);
        }

        public virtual void ThrowIfArgumentIsOutOfRange<T>(T arg, Func<T, bool> isOutRangeFunc, string paramName, string message)
        {
            if (isOutRangeFunc(arg))
                ThrowArgumentOutOfRangeException(paramName, arg, message);
        }

        #endregion


        #region Base throwers methods

        public virtual void ThrowArgumentException(string paramName, string message)
        {
            throw new ArgumentException(message, paramName);
        }

        public virtual void ThrowArgumentNullException(string paramName, string message)
        {
            throw new ArgumentNullException(paramName, message);
        }

        public virtual void ThrowNullReferenceException(string message)
        {
            throw new NullReferenceException(message);
        }

        public virtual void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        public virtual void ThrowNotImplementedException(string message)
        {
            throw new NotImplementedException(message);
        }

        public virtual void ThrowApplicationException(string message)
        {
            throw new ApplicationException(message);
        }

        public virtual void ThrowArgumentOutOfRangeException(string paramName, object actualValue, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        #endregion
    }
}
