using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Builder
{
    public class Builder
    {
        void Invoke_Builder()
        {
            // 要求 director 按照一定的顺序/过程创建产品
            Director director = new Director();
            // 创建两个不同的产品的建造者
            IBuilderComputer goodComputerBuilder = new GoodComputerBuilder();
            IBuilderComputer badComputerBuilder = new BadComputerBuilder();

            // 调用 Director.Construct() 方法创建商品
            director.Construct(goodComputerBuilder);
            // 通过 IBuilderComputer.GetComputer() 方法获取产品
            Computer computer1 = goodComputerBuilder.GetComputer();
            computer1.ShowPart();

            director.Construct(badComputerBuilder);
            Computer computer2 = badComputerBuilder.GetComputer();
            computer2.ShowPart();
        }


        /// <summary>
        /// 抽象建造者
        /// 1. 封装创建各个部件的过程
        /// 2. 将创建好的复杂对象返回
        /// </summary>
        public interface IBuilderComputer
        {
            void BuildPartCPU();
            void BuildPartMainBoard();
            void BuildPartMemory();
            void BuildPartOS();
            Computer GetComputer();
        }


        /// <summary>
        /// 具体建造者
        /// </summary>
        public class GoodComputerBuilder : IBuilderComputer
        {
            Computer computer = new Computer();
            public void BuildPartCPU()
            {
                computer.AddPart("CPU: I9-14900K");
            }
            public void BuildPartMainBoard()
            {
                computer.AddPart("MainBoard: Z790");
            }
            public void BuildPartMemory()
            {
                computer.AddPart("Memory: 128G-DDR5");
            }
            public void BuildPartOS()
            {
                computer.AddPart("OS: Windows-11");
            }
            public Computer GetComputer()
            {
                return this.computer;
            }
        }

        /// <summary>
        /// 具体建造者
        /// </summary>
        public class BadComputerBuilder : IBuilderComputer
        {
            Computer computer = new Computer();
            public void BuildPartCPU()
            {
                computer.AddPart("CPU: I3-8100");
            }
            public void BuildPartMainBoard()
            {
                computer.AddPart("MainBoard: H210");
            }
            public void BuildPartMemory()
            {
                computer.AddPart("Memory: 8G-DDR4");
            }
            public void BuildPartOS()
            {
                computer.AddPart("OS: Windows-10");
            }
            public Computer GetComputer()
            {
                return this.computer;
            }
        }



        /// <summary>
        /// 具体产品
        /// </summary>
        public class Computer
        {
            private List<string> parts = new List<string>();

            public void AddPart(string part)
            {
                parts.Add(part);
            }

            public void ShowPart()
            {
                Console.WriteLine("Computer parts:");
                foreach (var item in parts)
                {
                    Console.WriteLine(item);
                }
            }
        }


        /// <summary>
        /// 指挥者：
        ///     决定稳定创建各个 部件/产品 的 顺序/过程，
        ///     不由 IBuilderComputer 实现类来决定
        /// </summary>
        public class Director
        {
            public void Construct(IBuilderComputer builder)
            {
                builder.BuildPartCPU();
                builder.BuildPartMainBoard();
                builder.BuildPartMemory();
                builder.BuildPartOS();
            }
        }
    }
}
