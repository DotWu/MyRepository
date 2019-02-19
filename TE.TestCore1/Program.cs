using System;

namespace TE.TestCore1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 主要介绍多态的各种种形式
            Console.WriteLine("------主要介绍多态的各种种形式------");
            //1.继承的方式实现多态，People有多种不同的实现形式（接口和抽象类的形式与之类似）
            People people1 = new People();
            People people2 = new Student();
            People people3 = new Teacher();

            //2.方法的重载也是一种多态，即同名方法不同的实现形式
            Student student1 = new Student();
            student1.Show(1);
            student1.Show("2");
            student1.Show(1, "ypf");

            //3.利用命名参数实现方法的重载，即方法的多态
            Student student2 = new Student();
            student2.Play(3);
            student2.Play(3, "4");

            //4.运行时的多态
            People people4 = new Student();
            people4.VirtualMethord();
            People people5 = new Teacher();
            people5.VirtualMethord();
            Console.ReadLine();
            #endregion

            #region 抽象类的使用和特点
            Console.WriteLine("------抽象类的使用和特点------");
            //面向抽象编程
            BasePhone iphone1 = new Iphone();  //里氏替换原则
            //1.iphone类中四个覆写的抽象方法
            iphone1.Brand();
            iphone1.System();
            iphone1.Call();
            iphone1.Do<Iphone>();
            //2.BasePhone中的两个方法
            iphone1.Show();   //调用父类中的方法
            iphone1.ShowVirtual();  //调用的是子类覆写以后的方法
            //3.调用子类特有的方法（调用不了）
            //iphone.ITunes();
            Iphone iphone2 = new Iphone();
            iphone2.ITunes();
            Console.ReadLine();
            #endregion

            #region 接口的使用和特点
            Console.WriteLine("------接口的使用和特点------");
            //1.面向接口编程
            Console.WriteLine("面向接口编程");
            IExtend iphone3 = new iphone();
            iphone3.Game();
            IPay iphone4 = new iphone();
            iphone4.Play();
            //2.正常编程
            iphone iphone5 = new iphone();
            iphone5.Game();
            iphone5.Play();
            Console.ReadLine();
            #endregion

            #region 重写   覆写
            Console.WriteLine("------重写------覆写------");
            //普通方法重写，调用的都是父类方法
            parentClass parent1 = new childClass();
            Console.WriteLine("------1.普通方法重写，调用的都是父类方法------");
            parent1.CommonMethord1();   //结果：父类方法
            parent1.CommonMethord1("111");   //结果：父类方法
            parent1.CommonMethord2();   //结果：父类方法
            //子类的直接调用
            childClass child1 = new childClass();
            Console.WriteLine("------2.子类的直接调用------");
            child1.CommonMethord1();   //结果：子类方法
            child1.CommonMethord1("222");  //结果：子类方法
            child1.CommonMethord2();   //结果：父类方法
            Console.WriteLine("------3.抽象类(符合里氏替换原则)的形式调用------");
            parent1.abstractMethord();   //结果：子类方法
            parent1.virtualMethord1();   //结果：父类方法
            parent1.virtualMethord2();   //结果：子类方法
            Console.WriteLine("------4.子类的直接调用------");
            child1.abstractMethord();    //结果：子类方法
            child1.virtualMethord1();    //结果：父类方法
            child1.virtualMethord2();    //结果：子类方法

            Console.ReadLine();
            #endregion

            Console.ReadLine();
        }
    }

    #region   主要介绍多态的各种种形式
    public class People
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public void Play()
        {
            Console.WriteLine("play方法");
        }
        /// <summary>
        /// 子类可以对其覆写，也可以不进行覆写
        /// </summary>
        public virtual void VirtualMethord()
        {
            Console.WriteLine("我是父类中的虚方法");
        }
    }
    public class Student : People
    {
        public void Show(int id)
        {
            Console.WriteLine($"id为：{id}");
        }
        public void Show(string id)
        {
            Console.WriteLine($"id为：{id}");
        }
        public void Show(int id, string name)
        {
            Console.WriteLine($"id为：{id}，name为：{name}");
        }
        /// <summary>
        /// 利用参数名实现方法的重载，即方法的多态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Play(int id, string name = null)
        {
            if (name != null)
            {
                Console.WriteLine($"id为：{id}，name为：{name}");
            }
            else
            {
                Console.WriteLine($"id为：{id}");
            }
        }
        public override void VirtualMethord()
        {
            //base.VirtualMethord();
            Console.WriteLine("我是子类Student中对方法的覆写");
        }
    }
    public class Teacher : People
    {
        public override void VirtualMethord()
        {
            //base.VirtualMethord();
            Console.WriteLine("我是子类Teacher中对方法的覆写");
        }
    }
    #endregion

    #region  抽象类的使用和特点
    public abstract class BasePhone
    {
        //1.属性
        public string id { get; set; }
        //2.字段
        public string userPwd = "maru";
        //3.委托
        public delegate void DoNothing();
        //4.抽象方法
        public abstract void Brand();
        public abstract void System();
        public abstract void Call();
        //5.普通方法（继承的子类无法对其进行覆写，可以对其进行重写）
        public void Show()
        {
            Console.WriteLine("这是父类的Show方法");
        }
        //6.虚方法（可以被任何继承他的子类所覆写）
        public virtual void ShowVirtual()
        {
            Console.WriteLine("这是父类的ShowVirtual方法");
        }
        //7.泛型方法抽象方法
        public abstract void Do<T>();
    }

    public class Iphone : BasePhone
    {
        public override void Brand()
        {
            //throw new NotImplementedException();
            Console.WriteLine("iphone品牌");
        }
        public override void System()
        {
            Console.WriteLine("iphone系统");
        }
        public override void Call()
        {
            Console.WriteLine("iphone电话");
        }
        public override void Do<T>()
        {
            Console.WriteLine("iphone做的事情");
        }
        /// <summary>
        /// 下面的ITunes方法为子类特有的方法
        /// </summary>
        public void ITunes()
        {
            Console.WriteLine("iphone连接到ITunes上");
        }
        /// <summary>
        /// 下面的ShowVirtual方法覆写父类中的虚方法
        /// </summary>
        public override void ShowVirtual()
        {
            //base.ShowVirtual();
            Console.WriteLine("这是子类中的ShowVirtual方法");
        }
        /// <summary>
        /// 下面的Show和父类中的一模一样，但是覆盖不了
        /// </summary>
        public void Show()
        {
            Console.WriteLine("这是子类中的Show方法");
        }

    }



    #endregion

    #region 接口的使用和特点
    public interface IExtend
    {
        void Game();
    }
    public interface IPay
    {
        void Play();
    }
    public class iphone : IExtend, IPay
    {
        //下面两个方法是显示实现接口中的方法

        public void Game()
        {
            Console.WriteLine("这是子类显示实现了接口中的Game方法");
        }
        public void Play()
        {
            Console.WriteLine("这是子类显示实现了接口中的Play方法");
        }
    }
    #endregion

    #region 重写  覆写
    public abstract class parentClass
    {
        #region 重写
        public void CommonMethord1()
        {
            Console.WriteLine("父类CommonMethord1");
        }
        public void CommonMethord1(string msg)
        {
            Console.WriteLine("父类 CommonMethord1");
        }
        public void CommonMethord2()
        {
            Console.WriteLine("父类CommonMethord2");
        }
        #endregion

        #region 覆写
        //下面为抽象方法
        public abstract void abstractMethord();
        //下面两个方法为虚方法
        public virtual void virtualMethord1()
        {
            Console.WriteLine("父类virtualMethord1");
        }
        public virtual void virtualMethord2()
        {
            Console.WriteLine("父类virtualMethord2");
        }
        #endregion
    }

    public class childClass : parentClass
    {
        #region 重写
        /// <summary>
        /// 单独声明子类实例的时候，将替换父类中的方法
        /// </summary>
        public void CommonMethord1()
        {
            Console.WriteLine("子类CommonMethord1");
        }
        /// <summary>
        /// new 关键字去除上述警告，单独声明子类实例的时候，将替换父类中的方法
        /// </summary>
        /// <param name="msg"></param>
        public new void CommonMethord1(string msg)
        {
            Console.WriteLine("子类 CommonMethord1");
        }
        #endregion

        #region 覆写
        public override void abstractMethord()
        {
            Console.WriteLine("子类abstractMethord");
        }
        //加上sealed关键字，子类不能继续对其进行覆写
        public sealed override void virtualMethord2()
        {
            Console.WriteLine("子类virtualMethord2");
        }
        #endregion
    }
    #endregion




}
