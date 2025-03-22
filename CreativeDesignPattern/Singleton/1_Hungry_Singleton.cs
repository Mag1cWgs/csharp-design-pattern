using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Singleton
{
    class ProgramUseSingleHungry
    {
        static void InvokeSingleHungry()
        {
            SingleHungry singleHungry = SingleHungry.GetSingleHungry();
        }
    }

    /// <summary>
    /// 称之为饿汉式，不推荐使用，会造成资源浪费
    /// 会在调用之前就已经提前创建对象
    /// </summary>
    public class SingleHungry
    {
        // 1. 构造函数私有化
        private SingleHungry() { }

        // 2. 创建一个唯一的对象
        /* private: 迪米特原则，没有必要暴露给外部的成员都写为private
         * static: 静态成员，保证在内存的唯一性，会在类加载时直接创建
         * readonly: 不允许修改
         * 使用内部静态类优化，此处无需定义:
         *  如需使用原方案，需要将此处注释取消，然后去除 InnerClass */
        // private static readonly SingleHungry _singleHungry = new SingleHungry();


        // 3. 创建一个方法，实现对外提供获取类唯一对象的能力
        public static SingleHungry GetSingleHungry()
        {
            // 原方案: 返回 2. 中创建的唯一对象
            // return _singleHungry;
            // 现方案: 返回内部类
            return InnerClass.hungryClass;
        }

        ///<summary>
        // 内部类的优点: 不会跟着外部类一起加载到内存中，只有在外部调用 GetSingleHungry() 时才会加载，但是仍然是多线程不安全/反射危险的
        // </summary>
        private static class InnerClass
        {
            public static readonly SingleHungry hungryClass = new SingleHungry();
        }
    }

}
