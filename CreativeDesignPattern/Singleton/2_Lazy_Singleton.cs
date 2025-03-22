using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Singleton
{
    /// <summary>
    /// 调用示例
    /// </summary>
    class ProgramUse
    {
        static void InvokeLazySingle()
        {
            // 正常调用
            LazySingle lazySingle = LazySingle.GetLazySingle();
            //TestMultThread();
            //UseReflectionToBreakSingletons();

            /// <summary>
            /// 测试函数，配合 GetLazySingle() 中的 
            /// 	<c>Console.WriteLine("创建一个新实例");</c>
            /// 使用
            /// </summary>
            [Conditional("DEBUG")]
            static void TestMultThread()
            {
                for (int i = 0; i < 10; i++)
                    new Thread(() => LazySingle.GetLazySingle()).Start();
            }

            /// <summary>
            /// 使用反射去破坏单例性的一种方法，
            /// 	解决方法：在私有构造函数中抛出异常
            /// </summary>
            void UseReflectionToBreakSingletons()
            {
                Type t = Type.GetType("LazySingle");
                ConstructorInfo[] cons = t.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                // 直接调用私有的构造函数，避免调用 GetLazySingle()
                LazySingle lz = (LazySingle)cons[0].Invoke(null);
                //Console.WriteLine(single.GetHashCode() == lz.GetHashCode());

                // 使用标记位来记录是否单例化过，防止直接调用构造函数时抛出错误
                // 解决方法：找到标记位，在创建第二个单例对象之前修改值
                FieldInfo fieldInfo = t.GetField("isOK", BindingFlags.NonPublic | BindingFlags.Static);
                fieldInfo.SetValue("isOK", false);

                // 通过反射创建两个不同对象
                // 破坏的原因：new没有执行，直接跨过new，直接调用构造函数
                LazySingle lzAno = (LazySingle)cons[0].Invoke(null);
                Console.WriteLine(lz.GetHashCode() == lzAno.GetHashCode());
            }
        }
    }


    /// <summary>
    /// 懒汉式单例
    /// 当需要创建对象时才会创建对象，不会造成内存浪费
    /// </summary>
    public class LazySingle
        {
            // 1. 私有化构造函数
            private LazySingle()
            {
                lock (lockObj)
                    if (isOK == false)
                        isOK = true;
                    else
                        throw new Exception("已经存在一个单例。");
                // 原方案:
                // 如果 if 被执行，说明使用反射直接调用了私有函数
                // if(lazy != null)
                // throw new Exception("已经存在一个单例。");
                // 使用标记位来保证使用反射来创建多个单例时抛出异常
            }
            // 标记位
            private static bool isOK = false;

            // 2. 声明静态字段，存储我们唯一的对象实例
            // 不使用 readonly
            // 不直接 new
            // 不使用静态类的原因：
            //     - Form类不能静态
            //     - 静态类要求所有字段都有值(会出现饿汉式同款问题)
            // 使用 volatile 做易失性标记
            private volatile static LazySingle lazy;

            // 创建静态私有的 object 字段，用于加互斥锁
            private static readonly object lockObj = new object();

            // 3. 通过方法创建对象并返回
            public static LazySingle GetLazySingle()
            {
                // 如果 lazy 未绑定实例，当前线程进入并加锁
                // 双重锁定检查（节约资源）:
                //   在首个单例创建完成后，其他线程访问下面锁定块时就无需访问锁
                if (lazy == null)
                {
                    // lock : c#提供的一个语法糖，提供互斥锁来解决多线程的安全问题
                    // 实际调用方法: Monitor.Enter() 、 Monitor.Exit() 
                    lock (lockObj)
                    {   // 对互斥锁的等待线程中所有线程，同样需要判断一次是否为空
                        if (lazy == null)
                        {
                            // new : 开辟空间 -> 构造实例 -> 绑定非null实例
                            // 可能会出现指令重排: 开辟空间 -> 绑定未知地址实例 -> 构造实例
                            // 对 lazy 加上 volatile 关键字标识避免指令重排优化
                            lazy = new LazySingle();
                            // Console.WriteLine("创建一个新实例");
                        }
                    }
                }
                return lazy;
                // 也可以使用null合并运算符写成:
                //return lazy ?? new LazeSingle();
            }
        }
}
