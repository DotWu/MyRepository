﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDome
{
    class HPMulitPrinter:IMultiPrinter
    {
        public void Print(string contents)
        {
            //在这里编写打印程序
            Console.WriteLine("欢迎使用HP打印机");
            Console.WriteLine($"HP打印机正在打印：{contents}");
        }
        public void Copy(string contents)
        {
            //在这里编写打印程序
            Console.WriteLine("欢迎使用HP打印机");
            Console.WriteLine($"HP打印机正在复印：{contents}");
        }
        public bool Fax(string contents)
        {
            //在这里编写打印程序
            Console.WriteLine("欢迎使用HP打印机");
            Console.WriteLine($"HP打印机正在传真：{contents}");
            return true;
        }
    }
}