using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Prototype
{
    public class Expert
    {
        public void Invoke_Expert()
        {
            Resume_Expert a = new Resume_Expert();
            a.SetInfo("小李", 25, '男');
            a.SetWorkExperience("2010-2014", "XX公司");

            // 对返回的 Object 进行强制类型转换到 Resume_Expert 类型
            Resume_Expert b = (Resume_Expert)a.Clone();
        }

    }

    /// <summary>
    /// 只需要继承 ICloneable 接口，实现 Clone() 方法即可
    /// </summary>
    public class Resume_Expert : ICloneable
    {
        /// <summary>
        /// 值类型
        /// </summary>
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

        /// <summary>
        /// 引用类型
        /// </summary>
        public WorkExperience workExperience;

        /// <summary>
        /// 构造函数，初始化引用类型
        /// </summary>
        public Resume_Expert()
        {
            workExperience = new WorkExperience();
        }

        /// <summary>
        /// 构造函数，深拷贝
        /// </summary>
        /// <param name="workExperienceImport">用于深拷贝</param>
        private Resume_Expert(WorkExperience workExperienceImport)
        {
            workExperience = (WorkExperience)workExperienceImport.Clone();
        }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            //// 浅拷贝: 引用类型只会拷贝引用，不会拷贝引用的对象
            //return this.MemberwiseClone();

            // 深拷贝: 引用类型对应对象也会被调用 Clone 进行深拷贝
            // 当前使用写在构造函数中的方法，可以不使用构造函数，直接在下面深拷贝
            return new Resume_Expert(workExperience)
            {
                // 值类型直接赋值
                Name = Name
                ,
                Age = Age
                ,
                Gender = Gender
                // 深拷贝的核心 : 引用类型使用 Clone() 方法进行拷贝
                //, workExperience = (WorkExperience)this.workExperience.Clone()
            };
        }

        /// <summary>
        /// 设置信息，值类型
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public void SetInfo(string name, int age, char gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// 设置工作经历，引用类型
        /// </summary>
        /// <param name="timeArea"></param>
        /// <param name="company"></param>
        public void SetWorkExperience(string timeArea, string company)
        {
            workExperience.TimeArea = timeArea;
            workExperience.TimeArea = company;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        public void ShowResume()
        {
            Console.WriteLine("{0}，{1}，{2}", Name, Age, Gender);
            Console.WriteLine("{0}，{1}", workExperience.TimeArea, workExperience.TimeArea);
        }

    }

    /// <summary>
    /// 引用类型的变量，如果也实现了 ICloneable 接口，那么就可以实现深拷贝
    /// </summary>
    public class WorkExperience : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }

        public string TimeArea { get; set; }
        public string Company { get; set; }
    }
}
