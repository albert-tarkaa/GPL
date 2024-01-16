namespace GPL.Utilities
{
    public class ConvertToInteger
    {
        /// <summary>
        /// Converts a variable or constant value to an integer.
        /// </summary>
        /// <param name="value">The variable or constant value to convert.</param>
        /// <param name="variableName">The name of the variable (used in error messages).</param>
        /// <returns>The integer value obtained from the variable or constant.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the value cannot be converted to an integer or has an invalid type.
        /// </exception>
        public static int Convert(object value, string variableName)
        {
            if (value is string stringValue)
            {
                var numericValue = VariableManager.CheckVariable(stringValue);

                if (numericValue != null && int.TryParse(numericValue.ToString(), out int intValue))
                {
                    return intValue;
                }
                else
                {
                    throw new ArgumentException($"Invalid value for variable {variableName}: {stringValue}");
                }
            }
            else if (value is int)
            {
                return (int)value;
            }
            else
            {
                throw new ArgumentException($"Invalid type for parameter {variableName}: {value.GetType().Name}");
            }
        }


    }
}
