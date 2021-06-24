using CoreTools.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Extensions
{
    public static class StringExtensions
    {
        public static HttpStatusCode? ConvertoHttpStatudCode(this string @this)
        {
            var _httpStatusCodes = Helper.GetEnumNamesValues<HttpStatusCode>();

            if (_httpStatusCodes.TryGetValue(@this, out HttpStatusCode result))
                return result;

            return null;
        }

        public static string ReplaceBreakLinesWithNewLines(
            this string @this, 
            string breakLineReplacement = " ", 
            string newLineReplacement = "")
        {
            ExThrower.ST_ThrowIfArgumentIsNull(breakLineReplacement, nameof(breakLineReplacement));
            ExThrower.ST_ThrowIfArgumentIsNull(newLineReplacement, nameof(newLineReplacement));

            return @this.Replace("\r", breakLineReplacement).Replace("\n", newLineReplacement);
        }

        public static string AddLastChar(this string @this)
        {
            return @this + (char)255;
        }

        public static bool IgnoreCaseContains(
            this string @this, 
            string value)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(value, nameof(value));

            return @this.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1;
        }

        public static bool IgnoreCaseEquals(
            this string @this, 
            string value)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(value, nameof(value));

            return @this.IgnoreCaseContains(value) && @this.Length == value.Length;
        }
    }
}
