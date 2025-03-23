using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Prototype
{

    public class Beginner
    {
        /// <summary>
        /// 浅复制，错误的复制方式
        /// </summary>
        public void Invoke_Beginner()
        {
            Resume_Beginner example1 = new Resume_Beginner();
            example1.SetInfo("张三", 35, '男');
            example1.SetWorkExperience("1998-2000", "XX公司");
            example1.ShowResume();

            Resume_Beginner example2 = example1;
            example2.ShowResume();
            Resume_Beginner example3 = example1;
            example3.ShowResume();
        }
    }

    public class Resume_Beginner
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public string TimeArea { get; set; }

        public string Company { get; set; }

        public void SetInfo(string name, int age, char gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public void SetWorkExperience(string timeArea, string company)
        {
            TimeArea = timeArea;
            Company = company;
        }

        public void ShowResume()
        {
            Console.WriteLine("{0}，{1}，{2}", Name, Age, Gender);
            Console.WriteLine("{0}，{1}", TimeArea, Company);
        }
    }
}
