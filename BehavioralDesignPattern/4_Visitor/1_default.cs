using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._4_Visitor
{
    public class _1_default
    {
        void Invoke_default(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();
            // 遍历对象结构中的对象集合，访问每个元素的Print方法打印元素信息
            foreach (Element e in objectStructure.Elements)
            {
                e.Print();
            }
            Console.Read();
        }



        // 对象结构
        // 一共六个元素，其中元素的具体类型取决于随机数?>5
        public class ObjectStructure
        {
            // 维护一个 ArrayList 存储对象元素
            private ArrayList elements = new ArrayList();

            public ArrayList Elements
            {
                get { return elements; }
            }

            public ObjectStructure()
            {
                Random ran = new Random();
                for (int i = 0; i < 6; i++)
                {
                    int ranNum = ran.Next(10);
                    if (ranNum > 5)
                    {
                        elements.Add(new ElementA());
                    }
                    else
                    {
                        elements.Add(new ElementB());
                    }
                }
            }
        }



        // 抽象元素角色
        public abstract class Element
        {
            public abstract void Print();
        }

        // 具体元素A
        public class ElementA : Element
        {
            public override void Print() => Console.WriteLine("我是元素A");
        }

        // 具体元素B
        public class ElementB : Element
        {
            public override void Print() => Console.WriteLine("我是元素B");
        }

    }
}
