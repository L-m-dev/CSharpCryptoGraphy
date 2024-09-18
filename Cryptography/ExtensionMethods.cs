using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public static class ExtensionMethods
    {
        public static byte[] ToBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        public static string BytesToString(this byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
    }
}
