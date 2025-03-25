using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public class _5_Bridge
    {
        void Invoke_Bridge()
        {
            Car bmw = new BMW();
            bmw.Move(new Red());

            Car benz = new Benz();
            benz.Move(new White());
        }

        // “实现”
        public interface IColor
        {
            string GetColor();
        }

        public class Red : IColor
        {
            public string GetColor()
            {
                return "Red";
            }
        }
        public class White : IColor
        {
            public string GetColor()
            {
                return "White";
            }
        }
        public class Black : IColor
        {
            public string GetColor()
            {
                return "Black";
            }
        }


        // “抽象”
        // 通常会有需要子类继承的成员，需要使用抽象类
        // 对 Color 的引用方法
        //     1. 添加 _color 字段，在构造函数初始化
        //     2. 在调用函数中添加 IColor 参数
        public abstract class Car
        {
            public abstract void Move(IColor color);
        }

        public class BMW : Car
        {
            public override void Move(IColor color)
            {
                Console.WriteLine(color.GetColor()+ "色的 BMW 在行驶");
            }
        }

        public class Benz : Car
        {
            public override void Move(IColor color)
            {
                Console.WriteLine(color.GetColor() + "色的 Benz 在行驶");
            }
        }
    }
}
