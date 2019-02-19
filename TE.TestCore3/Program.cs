using System;
using System.IO;
using System.Web;

namespace TE.TestCore3
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        #region  //讲相对路径转换为绝对路径
        //public static string PathConvert(string strPath)
        //{
        //    if (HttpContext.Current != null)  //web程序使用
        //    {
        //        return HttpContext.Current.Server.MapPath(strPath);
        //    }
        //    else   //非web程序使用
        //    {
        //        strPath = strPath.Replace("/", "\\");
        //        if (strPath.StartsWith("\\"))
        //        {
        //            strPath = strPath.TrimStart('\\');
        //        }
        //        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,strPath);
        //    }
        //}
        #endregion






    }
}
