using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;

namespace CourseManagementSystem.Models.LogicModels.Services
{
    public class Security
    {
        public static string GetHashString(string s)
        {
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(s);
                var csp = new MD5CryptoServiceProvider();
                byte[] byteHash = csp.ComputeHash(bytes);
                return byteHash.Aggregate(string.Empty, (current, b) => current + string.Format("{0:x2}", b));
            }
            catch
            {
                return null;
            }
        }
    }
}