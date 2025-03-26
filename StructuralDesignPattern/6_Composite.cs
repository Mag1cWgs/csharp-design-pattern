using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public class _6_Composite
    {
        void Invoke_Composite()
        {

            DepartComposite root = new DepartComposite("总公司");

            DepartComposite dp1 = new DepartComposite("部门1");
            DepartComposite dp2 = new DepartComposite("部门2");


            root.Add(new Employee("总经理"));
            root.Add(new Employee("总经理秘书"));
            root.Add(dp1);
            root.Add(dp2);

            dp1.Add(new Employee("部门1经理"));
            dp1.Add(new Employee("部门1秘书"));

            dp2.Add(new Employee("部门2经理"));
            dp2.Add(new Employee("部门2秘书"));

            root.Display(1);
        }



        /// <summary>
        /// 定义子类中共有的操作
        /// </summary>
        public abstract class Component
        {
            public string Name { get; set; }
            public Component(string name)
            {
                this.Name = name;
            }
            public abstract void Add(Component c);

            public abstract void Remove(Component c);

            public abstract void Display(int depth);
        }

        /// <summary>
        /// 部门类树枝
        /// </summary>
        public class DepartComposite : Component
        {
            public DepartComposite(string name) : base(name) { }

            //存储部门或者员工
            private List<Component> listComponent = new List<Component>();

            public override void Add(Component component)
            {
                listComponent.Add(component);
            }

            public override void Remove(Component component)
            {
                listComponent.Remove(component);
            }

            public override void Display(int depth)
            {
                int numberOfNewUnderline = 2;
                Console.WriteLine(new string('_', depth) + this.Name);
                foreach (var item in listComponent)
                {
                    //用到了递归的思想
                    item.Display(depth+numberOfNewUnderline);
                }
            }
        }


        /// <summary>
        ///Employee是我们的Leaf节点，也就是树叶,树叶是无法继续添加子集的,
        /// </summary>
        public class Employee : Component
        {
            public Employee(string name) : base(name)
            { }
            public override void Add(Component component)
            {
                throw new NotImplementedException();
            }
            public override void Remove(Component component)
            {
                throw new NotImplementedException();
            }
            public override void Display(int depth)
            {
                Console.WriteLine(new string('_', depth) + this.Name);
            }
        }

    }
}
