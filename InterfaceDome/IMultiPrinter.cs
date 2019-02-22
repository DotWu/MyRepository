using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDome
{
    /// <summary>
    /// 多功能打印机接口
    /// </summary>
    public interface IMultiPrinter
    {
        //打印
        void Print(string contents);
        //复印
        void Copy(string contents);
        //传真
        bool Fax(string contents);
    }
}
