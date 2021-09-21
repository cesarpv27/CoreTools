using System;
using System.Text;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Extensions
{
    public static class EncodingExtensions
    {
        public static string EncodeToBase64String(this Encoding encoding, string s)
        {
            ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(s, nameof(s), nameof(s));

            return Convert.ToBase64String(encoding.GetBytes(s));
        }

        public static string DecodeFromBase64String(this Encoding encoding, string s)
        {
            ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(s, nameof(s), nameof(s));

            return encoding.GetString(Convert.FromBase64String(s));
        }
    }
}
