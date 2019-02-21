using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using TE.Utility.Helpers;
using System.Text.RegularExpressions;
using System.Net;
using Snowflake.Net;
using TE.Utility.Exceptions;
using TE.Utility.Exensions;

namespace TE.Utility
{
    public static class Utils
    {

        #region 登录用户名检查

        /// <summary>
        /// 判断一个字符串是否全有数字组成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDigit(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 判断字符串中是否包含字母
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasLetter(string input)
        {
            if (input == null)
                throw new ArgumentNullException();
            if (input == string.Empty)
            {
                return false;
            }

            Match match = Regex.Match(input, @"[A-Za-z]");
            if (match != null && match.Success == true)
                return true;

            return false;
        }
        /// <summary>
        /// 判断用户名中是否包含非法字符。如果包含非法字符，则返回false。
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="illegalChar"></param>
        /// <returns></returns>
        public static bool HasIllegalChar(string accountName, out string illegalChar)
        {
            illegalChar = null;
            if (string.IsNullOrEmpty("11")) { }
            if (accountName.IsNullOrEmpty())
                throw new ArgumentException();

            Match match = Regex.Match(accountName, @"[^A-Za-z0-9_\.-]");
            if (match == null || match.Success == false)
                return false;

            illegalChar = match.Value;
            return true;
        }

        /// <summary>
        /// 检查一个用户名是否合法。
        /// </summary>
        /// <param name="accountName"></param>
        public static void EnsureAccountNameLegal(string accountName, int minLength = 6, int maxLength = 18)
        {
            if (accountName == null)
                throw new ArgumentNullException();

            if (accountName.Length < minLength || accountName.Length > maxLength)
                throw new InvalidInputException($"用户名长度必须为 {minLength}-{maxLength} 位");

            if (!HasLetter(accountName))
                throw new InvalidInputException("用户名至少包含一个字母");
            string illegalChar;
            if (HasIllegalChar(accountName, out illegalChar))
                throw new InvalidInputException($"用户名包含非法字符[{illegalChar}]");
        }

        public static bool IsMobilePhone(string input)
        {
            Regex regex = new Regex("^1[34578]\\d{9}$");
            return regex.IsMatch(input);
        }
        /// <summary>
        /// 判断一个字符串是否是邮箱地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmail(string input)
        {
            // /^[0-9A-Za-z][\.-_0-9A-Za-z]*@[0-9A-Za-z]+(\.[0-9A-Za-z]+)+$/

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            Match match = Regex.Match(input, @"^[0-9A-Za-z][\.-_0-9A-Za-z]*@[0-9A-Za-z]+(\.[0-9A-Za-z]+)+$");
            if (match != null && match.Success == true)
                return true;

            return false;
        }
        #endregion

        #region 随机数全局对象
        /// <summary>
        /// 随机数全局对象
        /// </summary>
        public readonly static Random _GlobalRandom = new Random();
        #endregion

        #region  数字使用成汉语表示
        /// <summary>
        /// 数字使用成汉语表示(只考虑整百,整千,整万)
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string NumToChinese(decimal d)
        {
            double NumPart = 0;
            string TextPart = "";
            string value = "";
            if (d >= 10000)
            {
                int Units = 10000;
                NumPart = Convert.ToDouble(d / Units); //Convert.ToDouble(((d - d % Units) / Units));
                value = ConvertChinese((int)NumPart);
                TextPart = "万";
            }
            else if (d >= 1000)
            {
                int Units = 1000;
                NumPart = Convert.ToInt32(((d - d % Units) / Units));
                TextPart = "千";
            }
            else if (d >= 100)
            {
                int Units = 100;
                NumPart = Convert.ToInt32(((d - d % Units) / Units));
                TextPart = "百";
            }
            else if (d >= 10)
            {
                int Units = 10;
                NumPart = Convert.ToInt32(((d - d % Units) / Units));
                TextPart = "十";
            }
            else if (d > 0)
            {
                NumPart = Convert.ToDouble(d);
                TextPart = "元";
            }
            return value.ToString() + TextPart;
        }
      
        /// <summary>
        /// 将数字转换为大写
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertChinese(int val)
        {
            // "零壹贰叁肆伍陆柒捌玖拾佰仟万亿圆整角分"
            string cstr = "";
            switch (val)
            {
                case 0: cstr = "零"; break;
                case 1: cstr = "壹"; break;
                case 2: cstr = "贰"; break;
                case 3: cstr = "叁"; break;
                case 4: cstr = "肆"; break;
                case 5: cstr = "伍"; break;
                case 6: cstr = "陆"; break;
                case 7: cstr = "柒"; break;
                case 8: cstr = "捌"; break;
                case 9: cstr = "玖"; break;
                default:
                    val = val / 10;
                    if (val < 10)
                        cstr = ConvertChinese(val) + "拾";
                    else
                        cstr = ConvertChinese(val / 10) + "佰";
                    //cstr = "No."+val.ToString();
                    break;

            }
            return (cstr);
        }
        #endregion

        #region  保存txt文件日志
        /// <summary>
        /// 描述：保存txt文件日志
        /// </summary>
        /// <param name="fsname">保存文件名（无需后缀，已添加日期信息）</param>
        /// <param name="content">内容</param>
        public static void SaveTxtLog(string fsname, string content)
        {
            StreamWriter fs = null;
            try
            {
                var savePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TempFile");
                savePath = savePath + "\\" + fsname + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".txt";
                fs = new StreamWriter(savePath, false, System.Text.Encoding.UTF8);
                fs.WriteLine(content);
            }
            catch { }
            finally { if (fs != null) fs.Close(); }
        }
        #endregion

        #region  数字转换为中文
        public static string IntToChinese(int key)
        {
            var dic = new Dictionary<int, string> { { 1, "一" }, { 2, "二" }, { 3, "三" }, { 4, "四" }, { 5, "五" }, { 6, "六" }, { 7, "七" }, { 8, "八" }, { 9, "九" } };
            return dic[key];
        }
        #endregion

        #region 获取客户端IP地址

        /// <summary>
        /// 获取客户机链接IP,如果获取不到IP则返回“#”,最多返回20位的IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            if (HttpContext.Current != null)
            {
                HttpRequest _Request = HttpContext.Current.Request;
                string CurIp = !string.IsNullOrEmpty(_Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? _Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Trim() : string.Empty;
                if (string.IsNullOrEmpty(CurIp))
                { CurIp = !string.IsNullOrEmpty(_Request.ServerVariables["REMOTE_ADDR"]) ? _Request.ServerVariables["REMOTE_ADDR"].Trim() : "#"; }
                return CurIp.Length > 20 ? CurIp.Substring(0, 20) : CurIp;
            }
            else { return "#"; }
        }
        /// <summary>
        /// 获得客户端IP
        /// </summary>
        public static string ClientIP
        {
            get
            {
                bool isErr = false;
                string ip = "127.0.0.1";
                try
                {
                    string[] temp;
                    if (HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"] == null)
                        ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    else
                        ip = HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"].ToString();
                    if (ip.Length > 15)
                        isErr = true;
                    else
                    {
                        temp = ip.Split('.');
                        if (temp.Length == 4)
                        {
                            for (int i = 0; i < temp.Length; i++)
                            {
                                if (temp[i].Length > 3) isErr = true;
                            }
                        }
                        else
                            isErr = true;
                    }
                }
                catch { isErr = false; }

                if (isErr)
                    return "1.1.1.1";
                else
                    return ip;
            }
        }
        #endregion 获取客户端IP地址

        #region 判断指定的时间是否在时间段内

        /// <summary>
        /// 判断指定的时间是否在时间段内
        /// </summary>
        /// <param name="targetTime"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool IsDateInDatePeriod(DateTime targetTime, DateTime beginTime, DateTime endTime)
        {
            if (DateTime.Compare(beginTime, endTime) >= 0)
            { return false; }
            if (DateTime.Compare(targetTime, beginTime) < 0)
            { return false; }
            if (DateTime.Compare(targetTime, endTime) >= 0)
            { return false; }
            return true;
        }

        #endregion 判断指定的时间是否在时间段内

        #region 根据文件后缀来获取MIME类型字符串

        /// <summary>
        /// 根据文件后缀来获取MIME类型字符串
        /// </summary>
        /// <param name="extension">文件后缀</param>
        /// <returns></returns>
        public static string GetMimeType(string extension)
        {
            string mime = string.Empty;
            extension = extension.ToLower();
            switch (extension)
            {
                case ".avi": mime = "video/x-msvideo"; break;
                case ".bin":
                case ".exe":
                case ".msi":
                case ".dll":
                case ".class": mime = "application/octet-stream"; break;
                case ".csv": mime = "text/comma-separated-values"; break;
                case ".html":
                case ".htm":
                case ".shtml": mime = "text/html"; break;
                case ".css": mime = "text/css"; break;
                case ".js": mime = "text/javascript"; break;
                case ".doc":
                case ".dot":
                case ".docx": mime = "application/msword"; break;
                case ".xla":
                case ".xls":
                case ".xlsx": mime = "application/msexcel"; break;
                case ".ppt":
                case ".pptx": mime = "application/mspowerpoint"; break;
                case ".gz": mime = "application/gzip"; break;
                case ".gif": mime = "image/gif"; break;
                case ".bmp": mime = "image/bmp"; break;
                case ".jpeg":
                case ".jpg":
                case ".jpe":
                case ".png": mime = "image/jpeg"; break;
                case ".mpeg":
                case ".mpg":
                case ".mpe":
                case ".wmv": mime = "video/mpeg"; break;
                case ".mp3":
                case ".wma": mime = "audio/mpeg"; break;
                case ".pdf": mime = "application/pdf"; break;
                case ".rar": mime = "application/octet-stream"; break;
                case ".txt": mime = "text/plain"; break;
                case ".7z":
                case ".z": mime = "application/x-compress"; break;
                case ".zip": mime = "application/x-zip-compressed"; break;
                default:
                    mime = "application/octet-stream";
                    break;
            }
            return mime;
        }

        #endregion 根据文件后缀来获取MIME类型字符串

        #region 将异常写入文件

        /// <summary>
        /// 异常写入文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="CustomTags">UserTags</param>
        /// <param name="RequestUrl">发生错误的页面地址</param>
        /// <param name="SavePhyPath">保存信息的物理地址</param>
        public static void SaveErrorLog(Exception ex, string CustomTags, string RequestUrl, string SavePhyPath)
        {
            try
            {
                string filepath = SavePhyPath;
                string TitleText = "[---Begin---]";
                string FootText = "[----End----]";
                FileInfo fileInfo = new FileInfo(filepath);
                if (!fileInfo.Exists)
                {
                    FileStream cfile = fileInfo.Create();
                    cfile.Close();
                }
                using (StreamWriter stream = fileInfo.AppendText())
                {
                    stream.WriteLine(TitleText);
                    stream.WriteLine("时间：" + DateTime.Now);
                    stream.WriteLine("地址：" + RequestUrl);
                    stream.WriteLine("信息：" + ex.Message);
                    stream.WriteLine("对象：" + ex.Source);
                    stream.WriteLine("方法：" + ex.TargetSite);
                    stream.WriteLine("堆栈：");
                    stream.WriteLine(ex.StackTrace);
                    stream.WriteLine(FootText);
                    stream.WriteLine();
                    stream.Close();
                }
            }
            catch { }
        }

        #endregion 将异常写入文件

        #region 上传文件并返回文件名

        /// <summary>
        /// 上传文件并返回文件名
        /// </summary>
        /// <param name="hifile">HtmlInputFile控件</param>
        /// <param name="strAbsolutePath">绝对路径.如:Server.MapPath(@"Image/upload")与Server.MapPath(@"Image/upload/")均可,用\符号亦可</param>
        /// <returns>返回的文件名即上传后的文件名</returns>
        public static string SaveFile(HttpPostedFileBase file, string strAbsolutePath)
        {
            string strOldFilePath = "", strExtension = "", strNewFileName = "";
            strOldFilePath = Path.GetFileName(file.FileName);
            //取得上传文件的扩展名
            strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf(".")).ToLower();
            //文件上传后的命名
            strNewFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + strExtension;
            //如果路径末尾为\符号，则直接上传文件
            var physicalPath = string.Empty;
            if (strAbsolutePath.LastIndexOf("\\") == strAbsolutePath.Length)
            { physicalPath = Path.Combine(strAbsolutePath, strNewFileName); }
            else
            { physicalPath = strAbsolutePath + "\\" + strNewFileName; }
            file.SaveAs(physicalPath);
            return strNewFileName;
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="UploadFile">The file.</param>
        /// <param name="SavePhysicalPathFolder">保存文件的物理路径(不含文件名)</param>
        /// <param name="AllowExtension">允许的文件后缀名</param>
        /// <param name="MaxLength">最大长度(单位:KB)</param>
        /// <param name="MiniLength">最小长度(单位:KB)</param>
        /// <param name="SaveFileName">返回保存后的文件名(含extension)</param>
        /// <returns>上传成功(true);上传失败(false)</returns>
        public static UploadFileStatus SaveFile(HttpPostedFileBase UploadFile,
                                    string SavePhysicalPathFolder,
                                    string[] AllowExtension,
                                    int MaxLength,
                                    int MiniLength,
                                    out string SaveFileName)
        {
            SaveFileName = string.Empty;
            if (UploadFile != null && UploadFile.ContentLength > 0)
            {
                string SourceFileName = UploadFile.FileName;
                string SourceExtension = string.Empty;
                if (SourceFileName.Contains("."))
                { SourceExtension = SourceFileName.Substring(SourceFileName.LastIndexOf(".")).ToLower(); }

                bool IsAllowExtension = false;
                for (int i = 0; i < AllowExtension.Length; i++)
                {
                    if (string.Compare(SourceExtension, AllowExtension[i], true) == 0)
                    { IsAllowExtension = true; }
                }

                bool IsPassSizeCheck = false;
                if (UploadFile.ContentLength >= MiniLength * 1024 && UploadFile.ContentLength <= MaxLength * 1024)
                { IsPassSizeCheck = true; }

                if (IsAllowExtension)
                {
                    if (IsPassSizeCheck)
                    {
                        SaveFileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + SourceExtension;
                        string SavePath = SavePhysicalPathFolder + SaveFileName;
                        try
                        {
                            UploadFile.SaveAs(SavePath);
                            return UploadFileStatus.Succeed;
                        }
                        catch { return UploadFileStatus.OtherError; }
                    }
                    else { return UploadFileStatus.FileSizeError; }
                }
                else { return UploadFileStatus.ExtensionError; }
            }
            else { return UploadFileStatus.NullFile; }
        }


        /// <summary>
        /// check the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="allowExtension">允许的文件后缀名</param>
        /// <param name="maxLength">最大长度(单位:KB)</param>
        /// <param name="miniLength">最小长度(单位:KB)</param>
        /// <param name="saveFileName">返回保存后的文件名(含extension)</param>
        /// <returns>上传成功(true);上传失败(false)</returns>
        public static UploadFileStatus FileToCheck(HttpPostedFileBase file,
            string[] allowExtension, int maxLength, int miniLength, out string saveFileName)
        {
            saveFileName = string.Empty;
            if (file == null || file.ContentLength <= 0)
            { return UploadFileStatus.NullFile; }
            var ex = Path.GetExtension(file.FileName);
            var isAllowExtension = allowExtension.Any(e => string.Compare(ex, e, true) == 0);
            var isPassSizeCheck = file.ContentLength >= miniLength * 1024 && file.ContentLength <= maxLength * 1024;

            if (!isAllowExtension)
            { return UploadFileStatus.ExtensionError; }
            if (!isPassSizeCheck)
            { return UploadFileStatus.FileSizeError; }

            saveFileName = Guid.NewGuid().ToString("N") + ex;
            return UploadFileStatus.Succeed;
        }

        /// <summary>
        /// check the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="savePhysicalPathFolder"> 保存文件的物理路径(不含文件名)</param>
        /// <param name="allowExtension">允许的文件后缀名</param>
        /// <param name="maxLength">最大长度(单位:KB)</param>
        /// <param name="miniLength">最小长度(单位:KB)</param>
        /// <param name="saveFileName">返回保存后的文件名(含extension)</param>
        /// <returns>上传成功(true);上传失败(false)</returns>
        public static UploadFileStatus FileToCheck(HttpPostedFileBase file, string savePhysicalPathFolder,
            string[] allowExtension, int maxLength, int miniLength, out string saveFileName)
        {
            saveFileName = string.Empty;
            if (file == null || file.ContentLength <= 0)
            { return UploadFileStatus.NullFile; }
            var ex = Path.GetExtension(file.FileName);
            var isAllowExtension = allowExtension.Any(e => string.Compare(ex, e, true) == 0);
            var isPassSizeCheck = file.ContentLength >= miniLength * 1024 && file.ContentLength <= maxLength * 1024;

            if (!isAllowExtension)
            { return UploadFileStatus.ExtensionError; }
            if (!isPassSizeCheck)
            { return UploadFileStatus.FileSizeError; }

            saveFileName = Guid.NewGuid().ToString("N") + ex;
            var savePath = savePhysicalPathFolder + saveFileName;
            try
            {
                file.SaveAs(savePath);
                return UploadFileStatus.Succeed;
            }
            catch { return UploadFileStatus.OtherError; }
        }
        /// <summary>
        /// 文件上传的状态
        /// </summary>
        public enum UploadFileStatus
        {
            /// <summary>
            /// 上传成功
            /// </summary>
            Succeed,

            /// <summary>
            /// 上传文件为空
            /// </summary>
            NullFile,

            /// <summary>
            /// 后缀名错误
            /// </summary>
            ExtensionError,

            /// <summary>
            /// 上传文件长度错误
            /// </summary>
            FileSizeError,

            /// <summary>
            /// 其他错误
            /// </summary>
            OtherError
        }
        #endregion 上传文件并返回文件名

        #region 密码加密

        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="_Password">加密前</param>
        /// <returns></returns>
        public static string EncryptedPassword(string _Password)
        {
            return SecurityHelper.GetMD5(_Password);
        }

        #endregion 密码加密

        #region 截取字符长度

        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="inputString">字符</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len)
        {
            if (string.IsNullOrEmpty(inputString))
                return "";
            inputString = DropHTML(inputString);
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += "…";
            return tempString;
        }

        #endregion

        #region 清除HTML标记

        public static string DropHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring)) return "";
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            // Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        #endregion

        #region 清除HTML标记且返回相应的长度

        public static string DropHTML(string Htmlstring, int strLen)
        {
            return CutString(DropHTML(Htmlstring), strLen);
        }

        #endregion

        #region TXT代码转换成HTML格式

        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把TXT代码转换成HTML格式
        public static String ToHtml(string Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\r\n", "<br />");
            sb.Replace("\n", "<br />");
            sb.Replace("\t", " ");
            //sb.Replace(" ", "&nbsp;");
            return sb.ToString();
        }

        #endregion

        #region HTML代码转换成TXT格式

        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把HTML代码转换成TXT格式
        public static String ToTxt(String Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&nbsp;", " ");
            sb.Replace("<br>", "\r\n");
            sb.Replace("<br>", "\n");
            sb.Replace("<br />", "\n");
            sb.Replace("<br />", "\r\n");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&amp;", "&");
            return sb.ToString();
        }

        #endregion

        #region 过滤特殊字符

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if (Input != string.Empty && Input != null)
            {
                string ihtml = Input.ToLower();
                ihtml = ihtml.Replace("<script", "&lt;script");
                ihtml = ihtml.Replace("script>", "script&gt;");
                ihtml = ihtml.Replace("<%", "&lt;%");
                ihtml = ihtml.Replace("%>", "%&gt;");
                ihtml = ihtml.Replace("<$", "&lt;$");
                ihtml = ihtml.Replace("$>", "$&gt;");
                return ihtml;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region 字符串省略呈现

        /// <summary>
        /// Paddings the point string.
        /// </summary>
        /// <param name="originalStr">原字符串.</param>
        /// <param name="render_front">字符串头部呈现位数.</param>
        /// <param name="render_foot">字符串尾部呈现位数.</param>
        /// <param name="paddingChar">补齐位数的字符.</param>
        /// <returns></returns>
        public static string PaddingStr(string originalStr, int render_front, int render_foot, char paddingChar = '*')
        {
            if (string.IsNullOrEmpty(originalStr))
            { return string.Empty; }
            if (originalStr.Length < (render_front + render_foot))
            { return originalStr; }

            return string.Format("{0}{1}{2}", originalStr.Substring(0, render_front),
                ("").PadLeft(originalStr.Length - render_foot - render_front, paddingChar),
                originalStr.Substring(originalStr.Length - render_foot));
        }

        /// <summary>
        /// Paddings the point string.
        /// </summary>
        /// <param name="originalStr">原字符串</param>
        /// <param name="render_front">字符串头部呈现位数</param>
        /// <param name="render_foot">字符串尾部呈现位数</param>
        /// <param name="paddingCount">补齐的位数</param>
        /// <param name="paddingChar">补齐位数的字符</param>
        /// <returns></returns>
        public static string PaddingStr(string originalStr, int render_front, int render_foot, int paddingCount, char paddingChar = '*')
        {
            if (string.IsNullOrEmpty(originalStr))
            { return string.Empty; }
            if (originalStr.Length < (render_front + render_foot))
            { return originalStr; }

            return string.Format("{0}{1}{2}", originalStr.Substring(0, render_front),
                ("").PadLeft(paddingCount, paddingChar),
                originalStr.Substring(originalStr.Length - render_foot));
        }

        #endregion

        #region 获得当前绝对路径

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        #endregion

        #region 读取或写入cookie

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = GetUTF8UrlEncode(strValue); //strValue.GetUTF8UrlEncode();
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = GetUTF8UrlEncode(strValue); // strValue.GetUTF8UrlEncode();
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = GetUTF8UrlEncode(strValue); // strValue.GetUTF8UrlEncode();
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = GetUTF8UrlEncode(strValue); // strValue.GetUTF8UrlEncode();
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return GetUTF8UrlDecode(HttpContext.Current.Request.Cookies[strName].Value);
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return GetUTF8UrlDecode(HttpContext.Current.Request.Cookies[strName].Value);

            return "";
        }
        /// <summary>
        /// Gets the ut f8 URL encode.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string GetUTF8UrlEncode(this string text)
        { return string.IsNullOrEmpty(text) ? "" : HttpUtility.UrlEncode(text.Trim(), Encoding.UTF8); }
        /// Gets the utf8 URL decode.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string GetUTF8UrlDecode(this string text)
        { return string.IsNullOrEmpty(text) ? "" : HttpUtility.UrlDecode(text.Trim(), Encoding.UTF8); }
        #endregion

        #region URL请求数据

        /// <summary>
        /// HTTP POST方式请求数据
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="param">POST的数据</param>
        /// <returns></returns>
        public static string HttpPost(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;

            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }

            return responseStr;
        }

        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            WebResponse response = null;
            string responseStr = null;

            try
            {
                response = request.GetResponse();

                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                response = null;
            }

            return responseStr;
        }

        #endregion

        #region 替换指定字
        public static string Str_Replace(string str, int startIndex, int count, int ArrSize)
        {
            try
            {
                string[] Arr = new string[ArrSize];
                for (int i = 0; i < ArrSize; i++)
                    Arr[i] = "*";
                string str2 = str.Remove(startIndex, count);
                string str3 = str2.Insert(startIndex, string.Join("", Arr));
                return str3;
            }
            catch
            {
                return str;
            }
        }
        #endregion

        #region 创建Snowflake唯一性Id，long类型
        /// <summary>
        /// 创建Snowflake唯一性Id，long类型
        /// </summary>
        /// <returns></returns>
        public static long CreateId()
        {
            IdWorker worker = new IdWorker(1, 1); //大并发的情况下，减少new的次数可以有效避免重复的可能
            long id = worker.NextId();
            return id;
        }
        #endregion

        #region 根据会员自增列生成推荐码
        /// <summary>
        /// 根据会员自增列生成6位唯一的推荐码
        /// </summary>
        /// <param name="Id">会员自增列</param>
        /// <returns>推荐码</returns>
        public static string CreateCode(int Id)
        {
            string code = "";
            string source_string = "2YU9IP6ASDFG8QWERTHJ7KLZX4CV5B3ONM1";//自定义35进制  
            int mod = 0;
            StringBuilder sb = new StringBuilder();
            while (Id > 0)
            {
                mod = Id % 35;
                Id = (Id - mod) / 35;
                code = source_string.ToCharArray()[mod] + code;

            }
            return code.PadRight(6, '0');//不足六位补0  
        }
        /// <summary>
        /// 根据推荐码反推会员自增列
        /// </summary>
        /// <param name="code">推荐码</param>
        /// <returns>会员自增列</returns>
        public static int Decode(string code)
        {
            code = new string((from s in code where s != '0' select s).ToArray());
            int num = 0;
            string source_string = "2YU9IP6ASDFG8QWERTHJ7KLZX4CV5B3ONM1";
            for (int i = 0; i < code.ToCharArray().Length; i++)
            {
                for (int j = 0; j < source_string.ToCharArray().Length; j++)
                {
                    if (code.ToCharArray()[i] == source_string.ToCharArray()[j])
                    {
                        num += j * Convert.ToInt32(Math.Pow(35, code.ToCharArray().Length - i - 1));
                    }
                }
            }
            return num;
        }

        #endregion



    }
}
