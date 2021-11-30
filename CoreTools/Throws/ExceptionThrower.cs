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

        #region Static throwers methods

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> is null.
        /// </summary>
        /// <typeparam name="T">Type of <paramref name="arg"/>.</typeparam>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> is null.</exception>

        public static void ST_ThrowIfArgumentIsNull<T>(T arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsNull(arg, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> is null or an System.String.Empty string.
        /// </summary>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> 
        /// is null or an System.String.Empty string.</exception>
        public static void ST_ThrowIfArgumentIsNullOrEmpty(string arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsNullOrEmpty(arg, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> 
        /// is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> 
        /// is null, empty, or consists only of white-space characters.</exception>
        public static void ST_ThrowIfArgumentIsNullOrWhitespace(string arg, string paramName, string message)
        {
            ExThrower.ThrowIfArgumentIsNullOrWhitespace(arg, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the <paramref name="arg"/> is equal to an empty <see cref="Guid"/>.
        /// </summary>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if the <paramref name="arg"/>
        /// is equal to an empty <see cref="Guid"/>.</exception>
        public static void ST_ThrowIfGuidArgumentIsEmpty(Guid arg, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfGuidArgumentIsEmpty(arg, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the delegate <paramref name="isOutRangeFunc"/>
        /// returns false passing the <paramref name="arg"/> as the parameter.
        /// </summary>
        /// <typeparam name="T">Type of <paramref name="arg"/>.</typeparam>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="isOutRangeFunc">Delegate to determine if the <paramref name="arg"/> is out of range.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if the delegate <paramref name="isOutRangeFunc"/>
        /// returns false passing the <paramref name="arg"/> as the parameter.</exception>
        public static void ST_ThrowIfArgumentIsOutOfRange<T>(T arg, Func<T, bool> isOutRangeFunc, string paramName = null, string message = null)
        {
            ExThrower.ThrowIfArgumentIsOutOfRange(arg, isOutRangeFunc, paramName, message);
        }

        #endregion

        #region Throwers methods

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> is null.
        /// </summary>
        /// <typeparam name="T">Type of <paramref name="arg"/>.</typeparam>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> is null.</exception>
        public virtual void ThrowIfArgumentIsNull<T>(T arg, string paramName, string message)
        {
            if (arg == null)
                ThrowArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> is null or an System.String.Empty string.
        /// </summary>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> 
        /// is null or an System.String.Empty string.</exception>
        public virtual void ThrowIfArgumentIsNullOrEmpty(string arg, string paramName, string message)
        {
            if (string.IsNullOrEmpty(arg))
                ThrowArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> 
        /// is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if the <paramref name="arg"/> 
        /// is null, empty, or consists only of white-space characters.</exception>
        public virtual void ThrowIfArgumentIsNullOrWhitespace(string arg, string paramName, string message)
        {
            if (string.IsNullOrWhiteSpace(arg))
                ThrowArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the <paramref name="arg"/>
        /// is equal to an empty <see cref="Guid"/>.
        /// </summary>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if the <paramref name="arg"/>
        /// is equal to an empty <see cref="Guid"/>.</exception>
        public virtual void ThrowIfGuidArgumentIsEmpty(Guid arg, string paramName, string message)
        {
            if (arg.Equals(Guid.Empty))
                ThrowArgumentException(paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the delegate <paramref name="isOutRangeFunc"/>
        /// returns false passing the <paramref name="arg"/> as the parameter.
        /// </summary>
        /// <typeparam name="T">Type of <paramref name="arg"/>.</typeparam>
        /// <param name="arg">Argument to be evaluated.</param>
        /// <param name="isOutRangeFunc">Delegate to determine if the <paramref name="arg"/> is out of range.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if the delegate <paramref name="isOutRangeFunc"/>
        /// returns false passing the <paramref name="arg"/> as the parameter.</exception>
        public virtual void ThrowIfArgumentIsOutOfRange<T>(T arg, Func<T, bool> isOutRangeFunc, string paramName, string message)
        {
            if (isOutRangeFunc(arg))
                ThrowArgumentOutOfRangeException(paramName, arg, message);
        }

        #endregion


        #region Static base throwers methods

        /// <summary>
        /// Throws an ArgumentException.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/>.</exception>
        public static void ST_ThrowArgumentException(string paramName = null, string message = null)
        {
            ExThrower.ThrowArgumentException(paramName, message);
        }

        /// <summary>
        /// Throws an ArgumentNullException.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/>.</exception>
        public static void ST_ThrowArgumentNullException(string paramName = null, string message = null)
        {
            ExThrower.ThrowArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws an NullReferenceException.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="NullReferenceException">Throws <see cref="NullReferenceException"/>.</exception>
        public static void ST_ThrowNullReferenceException(string message)
        {
            ExThrower.ThrowNullReferenceException(message);
        }

        /// <summary>
        /// Throws an InvalidOperationException.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="InvalidOperationException">Throws <see cref="InvalidOperationException"/>.</exception>
        public static void ST_ThrowInvalidOperationException(string message)
        {
            ExThrower.ThrowInvalidOperationException(message);
        }

        /// <summary>
        /// Throws an NotImplementedException containing the name and value of <paramref name="message"/> in the exception message.
        /// </summary>
        /// <param name="message">Enum to extract data and build the message of the exception in 'name:value' format.</param>
        /// <exception cref="NotImplementedException">Throws <see cref="NotImplementedException"/>.</exception>
        public static void ST_ThrowNotImplementedException(Enum message)
        {
            ST_ThrowNotImplementedException(Texting.Texting.GetNameValue(message));
        }

        /// <summary>
        /// Throws an NotImplementedException.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="NotImplementedException">Throws <see cref="NotImplementedException"/>.</exception>
        public static void ST_ThrowNotImplementedException(string message)
        {
            ExThrower.ThrowNotImplementedException(message);
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws <see cref="ArgumentOutOfRangeException"/>.</exception>
        public static void ST_ThrowArgumentOutOfRangeException(string paramName = null, string message = null)
        {
            ExThrower.ThrowArgumentOutOfRangeException(paramName, default, message);
        }

        /// <summary>
        /// Throws an NotImplementedException.
        /// </summary>
        /// <param name="actualValue">Enum to extract data and build the 'paramName' parameter of the exception in 'name:value' format.
        /// Enum to pass in the 'actualValue' parameter of th exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws <see cref="ArgumentOutOfRangeException"/>.</exception>
        public static void ST_ThrowArgumentOutOfRangeException(Enum actualValue, string message = null)
        {
            ExThrower.ThrowArgumentOutOfRangeException(Texting.Texting.GetNameValue(actualValue), actualValue, message);
        }

        #endregion

        #region Base throwers methods

        /// <summary>
        /// Throws an ArgumentException.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/>.</exception>
        public virtual void ThrowArgumentException(string paramName, string message)
        {
            throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Throws an ArgumentNullException.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/>.</exception>
        public virtual void ThrowArgumentNullException(string paramName, string message)
        {
            throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws an NullReferenceException.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="NullReferenceException">Throws <see cref="NullReferenceException"/>.</exception>
        public virtual void ThrowNullReferenceException(string message)
        {
            throw new NullReferenceException(message);
        }

        /// <summary>
        /// Throws an InvalidOperationException.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="InvalidOperationException">Throws <see cref="InvalidOperationException"/>.</exception>
        public virtual void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Throws an NotImplementedException.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="NotImplementedException">Throws <see cref="NotImplementedException"/>.</exception>
        public virtual void ThrowNotImplementedException(string message)
        {
            throw new NotImplementedException(message);
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="actualValue">The value of the argument that causes this exception.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws <see cref="ArgumentOutOfRangeException"/>.</exception>
        public virtual void ThrowArgumentOutOfRangeException(string paramName, object actualValue, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        #endregion
    }
}
