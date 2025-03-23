using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Prototype
{
    public class Competent
    {
        public void Invoke_Competent()
        {
            Resume resume1 = new Resume("张三");
            // 尝试浅克隆，需要强制转换
            Resume resume2 = (Resume)resume1.Clone();
            // 通过 Clone() 方法克隆得来的对象，与 Beginner.cs 中的例子不同
            //  - 使用 Clone(): 两个对象的引用不同，但是值相同
            //  - 使用 Beginner.cs: 两个对象的引用相同，值共用
        }
    }

    /// <summary>
    /// 抽象原型类
    /// </summary>
    public abstract class ResumePrototype
    {
        public string Name { get; set; }

        public ResumePrototype(string name)
        {
            Name = name;
        }

        public abstract ResumePrototype Clone();
    }

    /// <summary>
    /// 具体原型类
    /// </summary>
    public class Resume : ResumePrototype
    {
        /// <summary>
        /// 构造函数，继承自父类
        /// </summary>
        /// <param name="name"></param>
        public Resume(string name) : base(name)
        { }

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public override ResumePrototype Clone()
        {
            ///<remarks>
            ///  <c>MemberwiseClone()</c> 方法是 浅复制/浅克隆
            ///     是 <c>Object</c> 类的一个 <c>protected</c> 方法，只有在派生类中才能调用
            /// - 值类型的字段会被复制
            ///  - 引用类型的字段只复制引用，不复制引用的对象
            ///  也可以用 <c>this.MemberwiseClone() as ResumePrototype</c>
            /// </remarks>
            return (ResumePrototype)MemberwiseClone();
        }


    }


}
