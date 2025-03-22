using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory
{
    class ProgramUse_FactoryMethod
    {
        void InvokeFactoryMethod()
        {
            // 初始化操作数操作符
            Console.WriteLine("请输入操作符1：");
            double d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符2：");
            double d2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();

            // 根据传入参数
            // 创建一个 可以创建对象 的 创建工厂对象
            ICalFactory calFactory = null;
            switch (oper)
            {
                case "+":
                    calFactory = new AddFactory();
                    break;
                case "-":
                    calFactory = new SubFactory();
                    break;
                default:
                    Console.WriteLine("请输入合法运算符");
                    break;
            }
            // 然后调用 创建工厂对象 产生 对象，再调用对象的函数
            ICalculator calculator = calFactory.GetCalculator();
            Console.WriteLine(calculator.GetResult(d1, d2));
        }

        /// <summary>
        /// 创建对象接口，把创建对象封装成抽象
        /// </summary>
        public interface ICalFactory
        {
            ICalculator GetCalculator();
        }

        /// <summary>
        /// 加法工厂
        /// </summary>
        public class AddFactory : ICalFactory
        {
            public ICalculator GetCalculator()
            {
                return new Add();
            }
        }

        /// <summary>
        /// 减法工厂
        /// </summary>
        public class SubFactory : ICalFactory
        {
            public ICalculator GetCalculator()
            {
                return new Sub();
            }
        }


        /// <summary>
        /// 运算抽象接口
        /// </summary>
        public interface ICalculator
        {
            double GetResult(double d1, double d2);
        }

        /// <summary>
        /// 加法类
        /// </summary>
        public class Add : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 + d2;
            }
        }

        /// <summary>
        /// 减法类
        /// </summary>
        public class Sub : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 - d2;
            }
        }
    }

    class ProgramUse_FactoryMethod_Reflection
    {
        void InvokeFactoryMethod()
        {
            // 0 初始化操作数操作符
            Console.WriteLine("请输入操作符1：");
            double d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符2：");
            double d2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();

            // 1 建立一个反射工厂，利用 Attribute 标记与反射
            //     建立一个 反射工厂ReflectionFactory
            ReflectionFactory reflectionFactory = new ReflectionFactory();

            // 2 利用反射工厂的 GetFactory 方法，依照反射工厂内部的键值表
            //     产生 对象产生工厂ICalFactory
            ICalFactory calFactory = reflectionFactory.GetFactory(oper);

            // 3 利用对象工厂的 GetCalculator 方法，
            //     获取 具体对象ICalculator
            ICalculator calculator = calFactory.GetCalculator();

            // 4 调用具体对象进行业务处理
            //     返回具体值并打印
            Console.WriteLine(calculator.GetResult(d1, d2));
        }


        // 1.1 自定义 Attribute
        public class OperToFactory : Attribute
        {
            public string OperStr { get; }// 不写 setter 因为值在引用特性时写好，无需赋值
                                          // 构造函数，在函数声明前加上 [OperToFactory(string s)] 以标记
            public OperToFactory(string s)
            {
                this.OperStr = s;
            }
        }


        // 1.2 建立反射工厂
        // 作用: 程序运行时，拿到描述关系，返回响应对象
        public class ReflectionFactory
        {
            // 1.2.1 存储 运算符-响应对象 的键值表
            Dictionary<string, ICalFactory> dic = new Dictionary<string, ICalFactory>();
            // 1.2.2 构造函数，在构造时建立键值表
            public ReflectionFactory()
            {   // 1. 拿到当前正在运行的程序集
                Assembly assembly = Assembly.GetExecutingAssembly();
                // 2. 建立所需的 string - ICalFactory
                foreach (var item in assembly.GetTypes())
                {   // 使用 Type.IsAssignableFrom() 来判断是否继承于 ICalFactory
                    // 需要额外去除 ICalFactory 这个接口本身，使用 Assembly.IsInterface 判断
                    // 只会有继承了 ICalFactory 的类进入此代码块
                    if (typeof(ICalFactory).IsAssignableFrom(item)
                        && !item.IsInterface)
                    {   // 实例化 Attribute 类
                        OperToFactory otf = item.GetCustomAttribute<OperToFactory>();
                        // 如果 otf 的 OperStr 属性非空（对应方法已经做过 Attribute 标记）
                        // 建立 otf.OperStr - item 键值对
                        if (otf.OperStr != null)
                        {
                            dic[otf.OperStr] = Activator.CreateInstance(item) as ICalFactory;
                        }
                    }
                }
            }


            // 2.1 反射工厂的对象返回函数
            // 基于 1.2.2 当前类构造时维护了在 1.2.1 中产生的键值表，
            // 返回一个 对象产生工厂ICalFactory
            public ICalFactory GetFactory(string s)
            {
                if (dic.ContainsKey(s))
                {
                    return dic[s];
                }
                return null;
            }
        }


        // 3.1 把创建对象封装成抽象
        public interface ICalFactory
        {
            ICalculator GetCalculator();
        }

        // 3.2 创建对象接口的实现类
        [OperToFactory("+")]
        public class AddFactory : ICalFactory
        {
            public ICalculator GetCalculator()
            {
                return new Add();
            }
        }
        [OperToFactory("-")]
        public class SubFactory : ICalFactory
        {
            public ICalculator GetCalculator()
            {
                return new Sub();
            }
        }


        // 4.1 运算抽象接口
        public interface ICalculator
        {
            double GetResult(double d1, double d2);
        }

        // 4.2 运算抽象接口的实现类
        public class Add : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 + d2;
            }
        }
        public class Sub : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 - d2;
            }
        }
    }
}
