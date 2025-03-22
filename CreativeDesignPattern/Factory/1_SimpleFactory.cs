using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory
{
    class ProgramUse_SimpleFactory
    {
        /// <summary>
        /// 简单工厂模式的调用示例
        /// </summary>
        void InvokeSimpleFactory()
        {
            // main.cs
            // 初始化操作数操作符
            Console.WriteLine("请输入操作符1：");
            double d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符2：");
            double d2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();
            // 使用静态工厂方法来创建对象
            ICalculator cal = CalFactory.GetCalculator(oper);
            double res = cal.GetResult(d1, d2);
            Console.WriteLine(res);
        }


        /// <summary>
        /// 工厂类
        /// </summary>
        private class CalFactory
        {
            /// <summary>
            /// 静态工厂方法
            /// </summary>
            /// <param name="oper">运算符</param>
            /// <returns>具体的运算对象</returns>
            public static ICalculator GetCalculator(string oper)
            {
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
                        Console.WriteLine("请输入合法运算符");
                        break;
                }
                return calculator;
            }
        }

        /// <summary>
        /// 运算抽象接口
        /// </summary>
        private interface ICalculator
        {
            double GetResult(double d1, double d2);
        }

        /// <summary>
        /// 加法类
        /// </summary>
        private class Add : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 + d2;
            }
        }

        /// <summary>
        /// 减法类
        /// </summary>
        private class Sub : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 - d2;
            }
        }

        /// <summary>
        /// 乘法类
        /// </summary>
        private class Mul : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 * d2;
            }
        }

        /// <summary>
        /// 除法类
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
