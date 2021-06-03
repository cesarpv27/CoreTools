using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTools.Texting
{
    public class Texting
    {
        public static string GetNameValue<Enu>(Enu @enum) where Enu : System.Enum
        {
            return $"{nameof(Enu)}:{@enum}";
        }
    }
}
