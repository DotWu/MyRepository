using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Properties
{
    class genericsConstraint
    {
        /// <summary>
        /// 基类约束和接口约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Show<T>(T t) where T : People, IWork
        {
            Console.WriteLine("id值为：" + t.Id + ",name值为：" + t.Name);
            t.Say();
            t.Work();
        }
        /// <summary>
        /// 无参构造函数约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void ShowNo<T>(T t) where T : new()
        {
            T t1 = new T();
            Console.WriteLine(t1);
        }
        /// <summary>
        /// 值类型约束
        /// C#值类型包括：结构体、数据类型(整型、字符型、浮点型、decimal型)、bool型、枚举、可空类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void ShowZhi<T>(T t) where T : struct
        {
            Console.WriteLine(t);
        }
        /// <summary>
        /// 引用类型约束
        /// C#引用类型包括：数组、类、接口、委托、object、字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void ShowYin<T>(T t) where T : class
        {
            Console.WriteLine(t);
        }
        /// <summary>
        /// 多参数约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="G"></typeparam>
        /// <param name="t"></param>
        /// <param name="g"></param>
        public void ShowMany<T,G>(T t,G g) where T:People where G:IWork
        {
            Console.WriteLine(t);
            Console.WriteLine(g);
        }
        /// <summary>
        /// 多条件约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void ShowManyCon<T>(T t) where T : class, IWork, ISport, new() { }
    }
}
