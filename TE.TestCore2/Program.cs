using System;
using System.Collections;
using System.Collections.Generic;

namespace TE.TestCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Array(数组)  特别注意：Array不是线程安全，在多线程中需要配合锁机制来进行.
            //如果不想使用锁，可以用ConcurrentStack这个线程安全的数组来替代Array。
            Console.WriteLine("-----------01 Array(数组)-----------");
            //模式一：声明数组并指定长度
            int[] array1 = new int[3];
            //数组的赋值通过下标来赋值
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i + 10;
            }
            //数组的修改通过下标来修改
            array1[2] = 100;
            //输出
            for (int j = 0; j < array1.Length; j++)
            {
                Console.WriteLine(j + ":" + array1[j]);
            }
            //模式二：直接赋值
            string[] array2 = new string[] { "王二", "傻子" };
            for (int l = 0; l < array2.Length; l++)
            {
                Console.WriteLine(l + ":" + array2[l]);
            }
            Console.ReadLine();
            #endregion

            #region ArrayList(可变长度的数组) 结论：不推荐使用，建议使用List代替！！
            //ArrayList不是线程安全，在多线程中需要配合锁机制来进行。
            Console.WriteLine("-----------02 ArrayList(可变长度的数组)-----------");
            ArrayList arraylist1 = new ArrayList();
            arraylist1.Add("张三");
            arraylist1.Add("李四");
            arraylist1.Add(100);
            for (int i = 0; i < arraylist1.Count; i++)
            {
                Console.WriteLine(arraylist1[i] + "类型为：" + arraylist1.GetType());
            }
            Console.ReadLine();
            #endregion

            #region  List<T> (泛型集合) 推荐使用 List<T>不是线程安全，在多线程中需要配合锁机制来进行
            //如果不想使用锁，可以用ConcurrentBag这个线程安全的数组来替代List<T>
            Console.WriteLine("-----------03 List<T> (泛型集合)-----------");
            List<string> arrayList2 = new List<string>();
            arrayList2.Add("参数1");
            arrayList2.Add("参数2");
            arrayList2.Add("参数3");
            //修改操作
            arrayList2[2] = "参数4";
            //删除操作
            arrayList2.RemoveAt(0);
            for (int i = 0; i < arrayList2.Count; i++)
            {
                Console.WriteLine(arrayList2[i]);
            }
            Console.ReadLine();
            #endregion

            #region  LinkedList<T> 链表  不是线程安全，在多线程中需要配合锁机制来进行
            Console.WriteLine("-----------04 LinkedList<T> 链表-----------");
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("重阳节1");
            linkedList.AddLast("重阳节2");
            var node1 = linkedList.Find("重阳节1");
            linkedList.AddAfter(node1, "重阳节3");
            //删除操作
            //linkedList.Remove(node1);
            //查询操作
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            #endregion

            #region  Queue<T> 队列 先进先出 不是线程安全，在多线程中需要配合锁机制来进行
            Console.WriteLine("-----------05 Queue<T> 队列-----------");
            //先进先出，入队(Enqueue)和出队(Dequeue)两个操作，实际应用场景：利用队列解决高并发问题
            Queue<int> queueList = new Queue<int>();
            //入队操作
            for (int i = 0; i < 10; i++)
            {
                queueList.Enqueue(i + 100);
            }
            //出队操作
            while (queueList.Count != 0)
            {
                Console.WriteLine(queueList.Dequeue());
            }
            Console.ReadLine();
            #endregion

            #region  Stack<T> 栈  后进先出，入栈（push）和出栈（pop）两个操作  不是线程安全
            Console.WriteLine("-----------06 Stack<T> 栈-----------");
            Stack<int> stackList = new Stack<int>();
            //入栈操作
            for (int i = 0; i < 10; i++)
            {
                stackList.Push(i + 100);
            }
            //出栈操作
            while (stackList.Count != 0)
            {
                Console.WriteLine(stackList.Pop());
            }
            Console.ReadLine();
            #endregion 

            #region  Hashtable 是线程安全的，不需要配合锁使用
            //　典型的空间换时间，存储数据不能太多，但增删改查速度非常快。
            Console.WriteLine("-----------07 Hashtable-----------");
            Hashtable hashtable = new Hashtable();
            //存储
            hashtable.Add("001", "参数5");
            hashtable["002"] = "参数6";
            //查询
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine("key:{0},value{1}", item.Key.ToString(), item.Value.ToString());
            }
            Console.ReadLine();
            #endregion

            #region Dictionary<K,T>字典 （泛型的Hashtable）不是线程安全，在多线程中需要配合锁机制来进行
            //增删改查速度非常快，可以用来代替实体只有id和另一个属性的时候，大幅度提升效率。
            Console.WriteLine("-----------08 Dictionary<K,T>字典-----------");
            Dictionary<string, string> tableList = new Dictionary<string, string>();
            //存储
            tableList.Add("001", "变量1");
            tableList.Add("002", "变量2");
            tableList["002"] = "变量3";
            //查询
            foreach (var item in tableList)
            {
                Console.WriteLine("key:{0},value:{1}", item.Key.ToString(), item.Value.ToString());
            }
            Console.ReadLine();

            #endregion


            Console.ReadLine();
        }
    }
}
