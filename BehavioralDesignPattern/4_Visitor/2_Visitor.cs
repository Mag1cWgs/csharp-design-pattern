using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._4_Visitor
{
    public class _2_Visitor
    {
        void Invoke_Visitor(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();
            foreach (Element e in objectStructure.Elements)
            {
                // 每个元素接受访问者访问
                e.Accept(new ConcreteVistor());
            }

            Console.Read();
        }

        // 对象结构
        public class ObjectStructure
        {
            private ArrayList elements = new ArrayList();

            public ArrayList Elements { get { return elements; } }
            
            public ObjectStructure()
            {
                Random ran = new Random();
                for (int i = 0; i < 6; i++)
                {
                    int ranNum = ran.Next(10);
                    if (ranNum > 5)
                        elements.Add(new ElementA());
                    else
                        elements.Add(new ElementB());
                }
            }
        }


        // 抽象元素角色
        public abstract class Element
        {
            // 接受访问者的访问
            public abstract void Accept(IVistor vistor);

            // 处理操作
            public abstract void Print();
        }


        // 具体元素A
        public class ElementA : Element
        {
            // 调用访问者visit方法
            public override void Accept(IVistor vistor) => vistor.Visit(this);

            public override void Print() => Console.WriteLine("我是元素A");

        }

        // 具体元素B
        public class ElementB : Element
        {
            public override void Accept(IVistor vistor) => vistor.Visit(this);
            public override void Print() => Console.WriteLine("我是元素B");
        }


        // 抽象访问者
        // 通过重载来限定不同访问者
        public interface IVistor
        {
            void Visit(ElementA a);
            void Visit(ElementB b);
        }

        // 具体访问者
        public class ConcreteVistor : IVistor
        {
            // visit方法而是再去调用元素的Accept方法
            public void Visit(ElementA a) => a.Print();

            public void Visit(ElementB b) => b.Print();
        }

    }
}
