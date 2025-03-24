using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public class _2_Decorater
    {
        void Invoke_Decorater()
        {
            // 需求：一份奶茶加两份布丁和一份珍珠

            // 准备原料/组件
            MilkTea milkTea = new MilkTea();
            Puding puding1 = new Puding();
            Puding puding2 = new Puding();
            ZhenZhu zhenZhu = new ZhenZhu();

            // 给 milkTea 添加一份布丁
            puding1.SetComponent(milkTea);
            // 给 milkTea 添加第二份一份布丁
            puding2.SetComponent(puding1);
            // 给 milkTea 添加一份珍珠
            zhenZhu.SetComponent(puding2);

            // 计算价格
            Console.WriteLine("总价格为{0}", zhenZhu.Cost());
        }



        /// <summary>
        /// 抽象组件，所有类的父类
        /// </summary>
        public abstract class AbstractDrink
        {
            public abstract double Cost();  
        }



        /// <summary>
        /// 具体组件
        /// </summary>
        public class MilkTea : AbstractDrink
        {
            public double price = 10;

            public override double Cost()
            {
                Console.WriteLine("奶茶 {0} 元一杯",this.price);
                return this.price;
            }
        }

        public class FruitTea : AbstractDrink
        {
            public double price = 20;

            public override double Cost()
            {
                Console.WriteLine("水果茶 {0} 元一杯", this.price);
                return this.price;
            }
        }

        public class SodaTea : AbstractDrink
        {
            public double price = 30;

            public override double Cost()
            {
                Console.WriteLine("苏打茶 {0} 元一杯", this.price);
                return this.price;
            }
        }



        /// <summary>
        /// 装饰器父类
        /// </summary>
        public abstract class Decorater : AbstractDrink
        {
            // 添加父类的引用
            private AbstractDrink drink;

            // 通过SetComponent方法设置父类的引用赋值
            public void SetComponent(AbstractDrink abstractDrink)
            {
                this.drink = abstractDrink;
            }

            // 重写父类的方法
            public override double Cost()
            {
                if (drink != null)
                {
                    return drink.Cost();
                }
                return 0;
            }
        }



        /// <summary>
        /// 具体装饰器
        /// </summary>
        public class Puding : Decorater
        {
            private static double PudingPrice = 5;

            public override double Cost()
            {
                Console.WriteLine("布丁 {0} 元一份", PudingPrice);
                // 先调用父类的方法，再调用自己的方法
                // 递归调用，直到没有父类为止。
                // 计算层层叠加后的 Price
                return base.Cost() + PudingPrice;
            }
        }

        public class XianCao : Decorater
        {
            private static double XianCaoPrice = 6;

            public override double Cost()
            {
                Console.WriteLine("布丁 {0} 元一份", XianCaoPrice);
                return base.Cost() + XianCaoPrice;
            }
        }

        public class ZhenZhu : Decorater
        {
            private static double ZhenZhuPrice = 7;

            public override double Cost()
            {
                Console.WriteLine("布丁 {0} 元一份", ZhenZhuPrice);
                return base.Cost() + ZhenZhuPrice;
            }
        }

    }
}
