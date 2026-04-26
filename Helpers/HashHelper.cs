using System;
using System.Security.Cryptography;
using System.Text;

namespace EquipmentAccounting.Helpers
{
    public static class HashHelper
    {
        public static string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
