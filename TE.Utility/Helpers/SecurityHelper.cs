using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TE.Utility.Helpers
{
    public class SecurityHelper
    {
        /// <summary>
        /// 获取MD5摘要
        /// </summary>
        /// <param name="value">The string.</param>
        /// <param name="IsUpper">是否大写</param>
        /// <returns></returns>
        public static string GetMD5(string value, bool IsUpper = true)
        {
            string result = GetMD5(value, Encoding.UTF8);
            return IsUpper ? result.ToUpper() : result;
        }

        /// <summary>
        /// 获取MD5摘要
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="IsUpper">是否大写</param>
        /// <returns></returns>
        public static string GetMD5(byte[] bytes, bool IsUpper = true)
        {
            string result = GetMD5(bytes);
            return IsUpper ? result.ToUpper() : result;
        }

        /// <summary>
        /// 获取字符串的MD5哈希值，默认编码为<see cref="Encoding.UTF8" />
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="encoding">编码方式(默认Encoding.UTF8)</param>
        /// <returns></returns>
        public static string GetMD5(string value, Encoding encoding)
        {
            if (encoding == null)
            { encoding = Encoding.UTF8; }
            byte[] bytes = encoding.GetBytes(value);
            return GetMD5(bytes);
        }

        /// <summary>
        /// 获取字节数组的MD5哈希值
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        private static string GetMD5(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            MD5 hash = new MD5CryptoServiceProvider();
            bytes = hash.ComputeHash(bytes);
            foreach (byte b in bytes)
            { sb.AppendFormat("{0:x2}", b); }
            return sb.ToString();
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="str">要加密字符串</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 返回加密后字符串
        /// </returns>
        public static String AesEncrypt(String str, String key)
        {
            Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(key);
            Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(str);
            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
            rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">要解密字符串</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 返回解密后字符串
        /// </returns>
        public static String AesDecrypt(String str, String key)
        {
            Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(key);
            Byte[] toEncryptArray = Convert.FromBase64String(str);
            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
            rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return System.Text.UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="PlainText">The plain text.</param>
        /// <param name="CipherText">The cipher text.</param>
        /// <returns></returns>
        public static bool Base64Encrypt(string PlainText, out string CipherText)
        {
            CipherText = string.Empty;
            try
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(PlainText);
                CipherText = Convert.ToBase64String(b);
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="CipherText">The cipher text.</param>
        /// <param name="PlainText">The plain text.</param>
        /// <returns></returns>
        public static bool Base64Decrypt(string CipherText, out string PlainText)
        {
            PlainText = string.Empty;
            try
            {
                byte[] c = Convert.FromBase64String(CipherText);
                PlainText = System.Text.Encoding.UTF8.GetString(c);
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Base64加密(用于url传递)
        /// </summary>
        /// <param name="PlainText"></param>
        /// <param name="CipherText"></param>
        /// <returns></returns>
        public static bool Base64ForUrlEncrypt(string PlainText, out string CipherText)
        {
            CipherText = string.Empty;
            try
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(PlainText);
                CipherText = Convert.ToBase64String(b).Replace('+', '*').Replace('/', '-').Replace('=', '.');
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Base64解密(用于url传递)
        /// </summary>
        /// <param name="CipherText"></param>
        /// <param name="PlainText"></param>
        /// <returns></returns>
        public static bool Base64ForUrlDecrypt(string CipherText, out string PlainText)
        {
            PlainText = string.Empty;
            try
            {
                byte[] c = Convert.FromBase64String(CipherText.Replace('.', '=').Replace('*', '+').Replace('-', '/'));
                PlainText = Encoding.UTF8.GetString(c);
                return true;
            }
            catch
            { return false; }
        }
    }
}
