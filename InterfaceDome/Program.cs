using System;

namespace InterfaceDome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Print(new HPMulitPrinter());
            Console.WriteLine("----------------------");
            Print(new CanonPrinter());
            Console.ReadLine();
        }


        //多态特性（接口作为方法的返回值、接口作为方法的参数）
        static void Print(IMultiPrinter printer)
        {
            printer.Print("学生信息表");
            printer.Print("学生成绩单");
            printer.Print("录取名单");

        }
    }
}
