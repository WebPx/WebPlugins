using System;

namespace WebPx
{
    /// <summary>
    /// This class support basic operations of validations in code, to ensure that no operations could failed with
    /// a parameter that has not been received, or is not a valid value that could be accepted in conversions
    /// or any other operation.
    /// </summary>
    internal static class ArgumentValidation
    {
        /// <summary>
        /// Validates a method parameter that a value should be received
        /// </summary>
        /// <param name="paramenterName">Provides the reference name of the parameter</param>
        /// <param name="value">This is the value received by the method that is validating</param>
        public static void NotNull(string paramenterName, object value)
        {
            if (value == null)
                throw new ArgumentNullException(paramenterName);
        }

        /// <summary>
        /// Validates a string method parameter that a value should be received
        /// </summary>
        /// <param name="paramenterName">Provides the reference name of the parameter</param>
        /// <param name="value">This is the string value received by the method that is validating</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void NotNull(string paramenterName, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramenterName);
        }

        /// <summary>Validates an array method parameter that is not empty collection should be received</summary>
        /// <param name="paramenterName">Provides the reference name of the parameter</param>
        /// <param name="value">This is the array value that should be validated</param>
        /// <requirements>fg</requirements>
        public static void ArrayNotEmpty(string paramenterName, object[] value)
        {
            if (value == null || value.Length == 0)
                throw new ArgumentException("Array is empty", paramenterName);
        }

        /// <summary>Checks if a type can be used to assign to another type</summary>
        /// <param name="paramenterName">The name of the argument received in the method</param>
        /// <param name="expectedType">The expected type of the parameter</param>
        /// <param name="targetType">The type provided on the argument</param>
        public static void IsAssignableFrom(string paramenterName, Type expectedType, Type targetType)
        {
            if (!expectedType.IsAssignableFrom(targetType))
                throw new ArgumentOutOfRangeException(paramenterName, string.Format("The Type '{0}' can't be used as a '{1}'", targetType.Name, expectedType.Name));
        }

        /// <summary>Checks if an object can be used to assign to a certain type.</summary>
        public static void IsAssignableFrom(string paramenterName, Type expectedType, object value)
        {
            Type valueTytpe = value.GetType();
            if (!expectedType.IsAssignableFrom(valueTytpe))
                throw new ArgumentOutOfRangeException(paramenterName, string.Format("The Type '{0}' can't be used as a '{1}'", valueTytpe, expectedType.Name));
        }
    }
}
