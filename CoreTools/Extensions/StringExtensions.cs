using CoreTools.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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

        public static string ReplaceBreakLinesByNewLines(this string @this, string breakLineReplacement = " ", string newLineReplacement = "")
        {
            return @this.Replace("\r", breakLineReplacement).Replace("\n", newLineReplacement);
        }
    }
}
