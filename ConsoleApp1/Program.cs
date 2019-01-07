using ConsoleApp1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 初始化
            //实体类
            People people = new People()
            {
                Id = "p1",
                Name="mr1"
            };
            Chinese chinese = new Chinese() {
                Id="p2",
                Name="mr2"
            };
            Janpanese janpanese = new Janpanese()
            {

            };
            ShenZhen shenZhen = new ShenZhen()
            {
                Id = "p3",
                Name = "mr3"
            };
            //构造函数有参数和无参数的两个类
            Test1 test1 = new Test1();
            Test2 test2 = new Test2("pp","maru");

            //声明一个值类型和一个引用类型
            int num = 12;   //值类型
            ShenZhen sz = new ShenZhen();

            #endregion

            #region  调用
            genericsConstraint gc = new genericsConstraint();
            //基类约束
            gc.Show<Chinese>(chinese);
            //gc.Show<People>(people);  //People类没有实现IWork接口
            Console.WriteLine("1");
            //接口约束
            gc.Show<ShenZhen>(shenZhen);
            //gc.Show<Janpanese>(janpanese);  //Janpanese只实现了IWork接口
            Console.WriteLine("2");
            //无参构造函数约束
            gc.ShowNo<Test1>(test1);
            Console.WriteLine("3");
            //值类型约束
            gc.ShowZhi<int>(num);
            Console.WriteLine("4");
            //引用类型约束
            gc.ShowYin<ShenZhen>(sz);
            Console.WriteLine("5");
            //多参数约束
            gc.ShowMany<People, Chinese>(people, chinese);
            //多条件约束
            Console.WriteLine("针对多条件约束，这里不做测试");
            Console.WriteLine("------------------分割线------------------");
            #endregion


            #region 
            CommonClass c1 = new CommonClass();
            c1.Show();
            Thread.Sleep(2000);
            CommonClass c2 = new CommonClass();
            c2.Show();
            Thread.Sleep(2000);
            CommonClass c3 = new CommonClass();
            c3.Show();
            Thread.Sleep(2000);
            Console.WriteLine("------------------分割线------------------");
            GenericsClass<int> intc1 = new GenericsClass<int>();
            intc1.Show();
            Thread.Sleep(2000);
            GenericsClass<string> intc2 = new GenericsClass<string>();
            intc2.Show();
            Thread.Sleep(2000);
            GenericsClass<int> intc3 = new GenericsClass<int>();
            intc3.Show();
            Thread.Sleep(2000);
            GenericsClass<string> intc4 = new GenericsClass<string>();
            intc4.Show();
            Thread.Sleep(2000);

            #endregion

            #region
            Person person1 = new Person()
            {
                Id = "123",
                userName = "吴曹辉",
                userPwd = "123456"
            };
            Console.WriteLine("");
            //获取类
            Type type = person1.GetType();
            //获取构造函数
            ConstructorInfo[] constructorInfosList = type.GetConstructors();
            for(int i=0; i < constructorInfosList.Length; i++)
            {
                Console.WriteLine("构造函数:" + constructorInfosList[i]);
            }
            //获取成员变量
            FieldInfo[] fielInforList = type.GetFields();
            for(int i = 0; i < fielInforList.Length; i++)
            {
                Console.WriteLine("成员变量:" + fielInforList[i]);
            }
            //获取成员
            MemberInfo[] memberInfosList = type.GetMembers();
            for(int i = 0; i < memberInfosList.Length; i++)
            {
                Console.WriteLine("成员:" + memberInfosList[i]);
            }
            //获取事件
            EventInfo[] eventInfosList = type.GetEvents();
            for (int i = 0; i < eventInfosList.Length; i++)
            {
                Console.WriteLine("事件:" + eventInfosList[i]);
            }
            //获取属性
            PropertyInfo[] propertyInfosList = type.GetProperties();
            for (int i = 0; i < propertyInfosList.Length; i++)
            {
                Console.WriteLine("属性:" + propertyInfosList[i]);
            }
            //获取特性
            PropertyInfo[] propertyInfoList = type.GetProperties();
            //1.获取属性上的特性
            //因为这些测试所用的特性都是加在属性上的，所以要先获取属性
            foreach (var item in propertyInfoList)
            {
                //获取该属性上的所有特性
                object[] attributeInfoList = item.GetCustomAttributes(true);
                foreach(var item2 in attributeInfoList)
                {
                    Console.WriteLine("{0}属性上的特性为{1}", item, item2);
                }
            }
            //2.获取类上的属性
            object[] attributeInfoList2 = type.GetCustomAttributes(true);
            foreach(var item3 in attributeInfoList2)
            {
                Console.WriteLine("{0}类上的特性为{1}", type, item3);

            }
            //获取Id属性的值
            PropertyInfo idProperty = type.GetProperty("Id");
            Console.WriteLine("属性名为：{0}", idProperty.Name);
            Console.WriteLine("属性值为：{0}", idProperty.GetValue(person1));
            //设置属性值
            idProperty.SetValue(person1, "2345");
            Console.WriteLine("设置后的属性值为：{0}", idProperty.GetValue(person1));

            #endregion
            Console.ReadLine();
        }
    }


    #region  实体类
    public class People
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public void Say() {
            Console.WriteLine("我会说话");
        }
    }

    public class Chinese : People, ISport, IWork
    {
        public void Sport() {
            Console.WriteLine("我在运动");
        }
        public void Work()
        {
            Console.WriteLine("我在工作");
        }
    }
    public class Janpanese : IWork
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public void Work()
        {
            Console.WriteLine("我在工作");
        }
    }
    public class ShenZhen : Chinese
    {

    }
    public interface IWork
    {
        void Work();
    }
    public interface ISport
    {
        void Sport();
    }
    /// <summary>
    /// 构造函数无参类
    /// </summary>
    public class Test1
    {
        public Test1() { }
    }
    /// <summary>
    /// 构造函数有参的类
    /// </summary>
    public class Test2
    {
        public Test2(string Id,string Namee) { }
    }

    #endregion
}
