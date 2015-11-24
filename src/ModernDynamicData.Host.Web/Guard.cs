using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernDynamicData.Host.Web
{
    internal static class Guard
    {
        internal static void NotNull(object item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void NotEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
