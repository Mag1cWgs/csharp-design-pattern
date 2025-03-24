using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Builder
{
    public class Example_Beginner
    {
        public void Invoke_Example_Beginner()
        {
            Computer computer = new Computer();
            computer.AddPart("CPU");
            computer.AddPart("主板");
            computer.AddPart("16g 内存");
            computer.AddPart("SSD");
            computer.AddPart("显卡");
            computer.AddPart("电源");
            computer.AddPart("机箱");
            computer.ShowPart();
        }

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

    }
}
