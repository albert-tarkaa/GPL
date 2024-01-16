using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL.Utilities
{
    public class VariableManager
    {
        // Private dictionary to store variable names and values
        private static Dictionary<string, object> variables = new Dictionary<string, object>();

        /// <summary>
        /// Checks if the variable with the specified name is already declared.
        /// </summary>
        /// <param name="variableName">The name of the variable to check.</param>
        /// <returns>The value of the variable if found; otherwise, null.</returns>
        public static object CheckVariable(string variableName)
        {
            if (variables.ContainsKey(variableName))
            {
                return variables[variableName]; // Variable found, return its value
            }

            return variableName; // Variable not found
        }

        /// <summary>
        /// Sets the value of a variable.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="value">The value to set.</param>
        public static void SetVariable(string variableName, object value)
        {
            variables[variableName] = value;
        }
    }
}
