using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTools.Text
{
    public class TextProvider
    {
        /// <summary>
        /// Extracts the name and value of <paramref name="enum"/> to build the resulting 'name:value' string.
        /// </summary>
        /// <typeparam name="Enu">Type of the enum.</typeparam>
        /// <param name="enum">Enum to extract the data and build the result.</param>
        /// <returns>An <see cref="string"/> in 'name:value' format, with the name and value of <paramref name="enum"/>.</returns>
        public static string GetNameValue<Enu>(Enu @enum) where Enu : System.Enum
        {
            return $"{nameof(Enu)}:{@enum}";
        }
    }
}
