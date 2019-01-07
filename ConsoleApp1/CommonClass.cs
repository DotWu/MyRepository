using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CommonClass
    {
        static CommonClass()
        {
            _InitTime = string.Format("调用构造函数的时间：{0}",DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }
        private static string _InitTime = "";
        public void Show()
        {
            Console.WriteLine(_InitTime);
        }
    }
    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericsClass<T>
    {
        static GenericsClass()
        {
            _InitTime = string.Format("调用构造函数的时间：{0}", DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }
        private static string _InitTime = "";
        public void Show()
        {
            Console.WriteLine(_InitTime);
        }

    }
}
