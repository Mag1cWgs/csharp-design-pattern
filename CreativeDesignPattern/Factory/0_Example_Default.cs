using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory
{
    class Example_Default
    {
        void InvokeDefault()
        {
            // 初始化操作数操作符
            Console.WriteLine("请输入操作符1：");
            double d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符2：");
            double d2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();
            // 创建响应对象
            ICalculator calculator = null;
            switch (oper)
            {
                case "+":
                    calculator = new Add();
                    break;
                case "-":
                    calculator = new Sub();
                    break;
                case "*":
                    calculator = new Mul();
                    break;
                case "/":
                    calculator = new Div();
                    break;
                default:
                    Console.WriteLine("请输入合法运算符！");
                    break;
            }

            double res = calculator.GetResult(d1, d2);
            Console.WriteLine(res);
        }



        /// <summary>
        /// 运算抽象接口
        /// </summary>
        private interface ICalculator
        {
            double GetResult(double d1, double d2);
        }

        /// <summary>
        /// 接口实现类
        /// </summary>
        private class Add : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 + d2;
            }
        }

        /// <summary>
        /// 接口实现类
        /// </summary>
        private class Sub : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 - d2;
            }
        }

        /// <summary>
        /// 接口实现类
        /// </summary>
        private class Mul : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 * d2;
            }
        }

        /// <summary>
        /// 接口实现类
        /// </summary>
        private class Div : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 / d2;
            }
        }
    }
}
