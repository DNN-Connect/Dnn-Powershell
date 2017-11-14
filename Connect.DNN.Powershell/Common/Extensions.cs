using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Connect.DNN.Powershell.Common
{
    public static class Extensions
    {
        private const DataProtectionScope Scope = DataProtectionScope.CurrentUser;

        public static string Encrypt(this string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");
            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, Scope);
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(this string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");
            byte[] data = Convert.FromBase64String(cipher);
            byte[] decrypted = ProtectedData.Unprotect(data, null, Scope);
            return Encoding.Unicode.GetString(decrypted);
        }

    }
}
