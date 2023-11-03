using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;

namespace Api
{
    public static class Utils
    {
        public static bool greaterThan(int a, int b)
        {
            return a > b;
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            return phone.Length == 9;
        }
    }
}
