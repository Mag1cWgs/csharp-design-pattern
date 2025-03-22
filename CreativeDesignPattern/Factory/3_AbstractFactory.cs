using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory
{
    class ProgramUse_AbstractFactory_Example_Simple
    {
        // 问题：
        // 1. 所有创建对象并封装均集成在 KeyboardFactory
        // 2. 抽象依赖于细节，高耦合不方便拓展
        public class KeyboardFactory
        {
            public static IKeyboard GetKeyboard(string brand)
            {
                IKeyboard keyboard = null;
                switch (brand)
                {
                    case "DELL":
                        keyboard = new DellKeyboard();
                        break;
                    case "LENOVO":
                        keyboard = new LenovoKeyboard();
                        break;
                    case "HP":
                        keyboard = new HPKeyboard();
                        break;
                }
                return keyboard;
            }
        }


        public interface IKeyboard
        {
            void ShowBrand();
        }

        public class DellKeyboard : IKeyboard
        {
            public void ShowBrand()
            {
                Console.WriteLine("DELL");
            }
        }
        public class LenovoKeyboard : IKeyboard
        {
            public void ShowBrand()
            {
                Console.WriteLine("Lenovo");
            }
        }
        public class HPKeyboard : IKeyboard
        {
            public void ShowBrand()
            {
                Console.WriteLine("HP");
            }
        }
    }

    class ProgramUse_AbstractFactory_Example_FactoryMethod
    {
        // 添加新的需求对象时，会出现类爆炸

        // 工厂的抽象
        public interface IKeyboardFactory
        {
            IKeyboard GetKeyboard();
        }
        // 工厂的具体
        public class DellFactory : IKeyboardFactory
        {
            public IKeyboard GetKeyboard()
            {
                return new DellKeyboard();
            }
        }
        public class LenovoFactory : IKeyboardFactory
        {
            public IKeyboard GetKeyboard()
            {
                return new LenovoKeyboard();
            }
        }
        public class HPFactory : IKeyboardFactory
        {
            public IKeyboard GetKeyboard()
            {
                return new HPKeyboard();
            }
        }

        // 对象的抽象
        public interface IKeyboard
        {
            void ShowBrand();
        }
        // 对象的具体
        public class DellKeyboard : IKeyboard
        {
            public void ShowBrand()
            {
                Console.WriteLine("DELL");
            }
        }
        public class LenovoKeyboard : IKeyboard
        {
            public void ShowBrand()
            {
                Console.WriteLine("Lenovo");
            }
        }
        public class HPKeyboard : IKeyboard
        {
            public void ShowBrand()
            {
                Console.WriteLine("HP");
            }
        }
    }

    class ProgramUse_AbstractFactory
    {

        void InvokeAbstractFactory()
        {
            // 假设已经确定选择 Dell 品牌的产品
            // 实际参考工厂方法设计模式中的反射实现
            AbstractFactory abstractFactory = new DellFactory();
            // 使用抽象工厂的实例来直接生产产品
            //把 品牌 的选择取决于抽象工厂的实例
            IKeyboard keyboard = abstractFactory.GetKeyboard();
            IMouse mouse = abstractFactory.GetMouse();
        }


        // 抽象工厂、抽象产品
        public interface AbstractFactory
        {
            IKeyboard GetKeyboard();
            IMouse GetMouse();
        }
        public interface IKeyboard
        {
            void ShowKeyboardBrand();
        }
        public interface IMouse
        {
            void ShowMouseBrand();
        }


        // Dell 工厂 与 产品
        public class DellFactory : AbstractFactory
        {
            IKeyboard AbstractFactory.GetKeyboard()
            {
                return new DellKeyboard();
            }
            IMouse AbstractFactory.GetMouse()
            {
                return new DellMouse();
            }
        }
        public class DellKeyboard : IKeyboard
        {
            public void ShowKeyboardBrand()
            {
                Console.WriteLine("DELL");
            }
        }
        public class DellMouse : IMouse
        {
            public void ShowMouseBrand()
            {
                Console.WriteLine("DELL");
            }
        }


        // Lenovo 工厂 与 产品
        public class LenovoKeyboard : IKeyboard
        {
            public void ShowKeyboardBrand()
            {
                Console.WriteLine("Lenovo");
            }
        }
        public class LenovoMouse : IMouse
        {
            public void ShowMouseBrand()
            {
                Console.WriteLine("Lenovo");
            }
        }
        public class LenovoFactory : AbstractFactory
        {
            IKeyboard AbstractFactory.GetKeyboard()
            {
                return new LenovoKeyboard();
            }
            IMouse AbstractFactory.GetMouse()
            {
                return new LenovoMouse();
            }
        }


        // HP 工厂 与 产品
        public class HPFactory : AbstractFactory
        {
            IKeyboard AbstractFactory.GetKeyboard()
            {
                return new HPKeyboard();
            }
            IMouse AbstractFactory.GetMouse()
            {
                return new HPMouse();
            }
        }
        public class HPKeyboard : IKeyboard
        {
            public void ShowKeyboardBrand()
            {
                Console.WriteLine("HP");
            }
        }
        public class HPMouse : IMouse
        {
            public void ShowMouseBrand()
            {
                Console.WriteLine("HP");
            }
        }
    }
}
