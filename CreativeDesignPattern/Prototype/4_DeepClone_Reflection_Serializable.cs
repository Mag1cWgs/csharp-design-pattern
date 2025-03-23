using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace CSharpDesignPattern.CreativeDesignPattern.Prototype
{
    public class DeepClone_Reflection_Serializable
    {

        class Extra
        {
            static void Invoke_Extra()
            {
                Person original = new Person
                {
                    Name = "John",
                    Age = 30,
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Anytown"
                    }
                };

                Person copy = DeepCopy(original);

                // 修改原始对象以验证深拷贝是否成功
                original.Name = "Jane";
                original.Address.City = "Othertown";

                Console.WriteLine("Original: " + original.Name + ", " + original.Address.City);
                Console.WriteLine("Copy: " + copy.Name + ", " + copy.Address.City);
            }
        }

        // 在 .Net 5.0 中，BinaryFormatter 已经被弃用，建议使用 System.Text.Json.JsonSerializer
        //public static T DeepCopy<T>(T obj)
        //{   // 检查对象是否为空
        //    if (obj == null)
        //    {
        //        throw new ArgumentNullException("obj");
        //    }
        //    // 使用反射检查对象是否可序列化，如果不可序列化则抛出异常
        //    Type type = obj.GetType();
        //    if (!typeof(ISerializable).IsAssignableFrom(type))
        //    {
        //        throw new ArgumentException("The object must be serializable");
        //    }
        //   // 使用二进制序列化和反序列化复制对象
        //    IFormatter formatter = new BinaryFormatter();
        //    using (Stream stream = new MemoryStream())
        //    {
        //        formatter.Serialize(stream, obj);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        return (T)formatter.Deserialize(stream);
        //    }
        //}


        public static T DeepCopy<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // 将对象序列化为JSON字符串
            string jsonString = JsonSerializer.Serialize(obj);

            // 从JSON字符串反序列化为新的对象实例
            return JsonSerializer.Deserialize<T>(jsonString);
        }



        //[Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Address Address { get; set; }
        }



        //[Serializable]
        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
        }
    }
}
