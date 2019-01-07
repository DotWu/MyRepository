using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ReflectionTest
    {
        public int Id { get; set;  }
        public string Name { get; set; }

        public static string Field = null;
        public static string FieldStatic = null;
        #region   构造函数
        public ReflectionTest()
        {
            Console.WriteLine("这里是{0}无参数构造函数", this.GetType());
        }
        public ReflectionTest(string Name)
        {
            Console.WriteLine("这里是{0}有1个参数构造函数", this.GetType());
        }
        public ReflectionTest(int Id,string Name)
        {
            Console.WriteLine("这里是{0}有2个参数构造函数", this.GetType());
        }
        #endregion

        public void Show1()
        {
            Console.WriteLine("这里是{0}的Show1", this.GetType());
        }
        public void Show2(int Id)
        {
            Console.WriteLine("这里是{0}的Show2", this.GetType());
        }
        public static void ShowStatic(string Name)
        {
            Console.WriteLine("这里是{0}的ShowStatic", typeof(ReflectionTest));
        }
        public void Show3()
        {
            Console.WriteLine("这里是{0}的Show3_1", this.GetType());
        }
        public void Show3(int Id,string Name)
        {
            Console.WriteLine("这里是{0}的Show3", this.GetType());
        }
        public void Show3(string Name, int Id)
        {
            Console.WriteLine("这里是{0}的Show3_2", this.GetType());
        }
        public void Show3(int Id)
        {
            Console.WriteLine("这里是{0}的Show3_3", this.GetType());
        }
        public void Show3(string Name)
        {
            Console.WriteLine("这里是{0}的Show3_4", this.GetType());
        }
        private void Show4(string Name)
        {
            Console.WriteLine("这里是{0}的Show4", this.GetType());
        }
        public void ShowGeneric<T>(T Name)
        {
            Console.WriteLine("这里是{0}的ShowStatic T={1}", this.GetType(), typeof(T));
        }
    }

    public sealed class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("初始化一次");
        }
        private static Singleton Instance = new Singleton();
        public static Singleton CreateInstance()
        {
            return Instance;
        }
    }

    [Description("我是Person类")]
    public class Person
    {

        #region //构造函数
        public Person() { }
        public Person(string sex)
        {
            this._Sex = sex;
        }
        #endregion
        #region //属性
        [Description("我是Id")]
        public string Id { get; set; }
        [ReadOnly(true)]
        public string userName { get; set; }

        public string userPwd { get; set; }
        #endregion
        #region //成员变量
        public string _Sex = null;
        public int _Age;
        #endregion

        #region  //方法
        public string GetOwnSex()
        {
            return this._Sex;
        }
        #endregion
        #region  //事件
        public event Action MyEvent;
        #endregion
    }

}
