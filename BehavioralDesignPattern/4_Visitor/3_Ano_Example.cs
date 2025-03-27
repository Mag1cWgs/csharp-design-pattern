using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._4_Visitor
{
    public class _3_Ano_Example
    {
        void Invoke_Example()
        {
            // 药品
            Medicine a = new MedicineA("板蓝根", 11.0);
            Medicine b = new MedicineB("感康", 14.3);

            // 处方单
            Prescription presciption = new Prescription();
            presciption.AddMedicine(a);
            presciption.AddMedicine(b);

            // 医生
            Visitor doctor = new Doctor("张三");
            // 药房拿药者
            Visitor workerOfPharmacy = new WorkerOfPharmacy("李四");

            // 开始业务流程
            // 1. 调用 Element.Accept(vistor)
            // 2. 在 Accept 函数中调用 vistor.Visit(this)
            // 3. 在 Visit 函数中对 vistor 做业务处理
            presciption.Accept(doctor);
            Console.WriteLine("------------------------------");
            presciption.Accept(workerOfPharmacy);

            Console.ReadLine();
        }

        /* 输出：
         *
         * 医生：张三，开药：板蓝根，价格：11
         * 医生：张三，开药：感康，价格：14.3
         * ------------------------------
         * 药房工作者：张三，拿药：板蓝根，价格：11
         * 药房工作者：张三，拿药：感康，价格：14.3
         *
         */





        // 对象结构：处方单
        // 用于存放元素对象，并且提供了遍历其内部元素的方法。
        public class Prescription
        {
            private List<Medicine> list = new List<Medicine>();

            public void Accept(Visitor visitor)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Accept(visitor);
                }
            }

            public void AddMedicine(Medicine medicine)
            {
                list.Add(medicine);
            }

            public void RemoveMedicien(Medicine medicine)
            {
                list.Remove(medicine);
            }
        }

        #region

        // 抽象访问者
        public abstract class Visitor
        {
            public string Name { get; set; }

            public Visitor(string name)
            {
                Name = name;
            }

            public abstract void Visit(MedicineA a);

            public abstract void Visit(MedicineB b);
        }

        // 具体访问者：医生
        public class Doctor : Visitor
        {
            public Doctor(string name) :
                base(name)
            { }

            public override void Visit(MedicineA a)
                => Console.WriteLine("医生：" + this.Name + "，开药：" + a.Name + "，价格：" + a.Price);

            public override void Visit(MedicineB b)
                => Console.WriteLine("医生：" + this.Name + "，开药：" + b.Name + "，价格：" + b.Price);
        }

        // 具体访问者：药房工作者
        public class WorkerOfPharmacy : Visitor
        {
            public WorkerOfPharmacy(string name) :
                base(name)
            { }

            public override void Visit(MedicineA a)
                => Console.WriteLine("药房工作者：" + this.Name + "，拿药：" + a.Name);

            public override void Visit(MedicineB b)
                => Console.WriteLine("药房工作者：" + this.Name + "，拿药：" + b.Name);
        }

        #endregion

        #region 元素

        // 抽象元素：药品
        public abstract class Medicine
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public Medicine(string name, double price)
            {
                this.Name = name;
                this.Price = price;
            }

            public abstract void Accept(Visitor visitor);
        }

        // 具体元素：药品A
        public class MedicineA : Medicine
        {
            public MedicineA(string name, double price) :
                base(name, price)
            { }

            public override void Accept(Visitor visitor) => visitor.Visit(this);
        }

        // 具体元素：药品B
        public class MedicineB : Medicine
        {
            public MedicineB(string name, double price) :
                base(name, price)
            { }

            public override void Accept(Visitor visitor) => visitor.Visit(this);
        }

        #endregion
    }
}