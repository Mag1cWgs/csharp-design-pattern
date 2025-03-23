using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory.Example_ChangeDataBase
{
    public class Beginner
    {
        /// <summary>
        /// 通过调用SqlServerUser的方法，实现对数据库的操作
        ///     但是如果要更换数据库，就需要修改代码，不符合开闭原则
        ///     不方便修改，不符合依赖倒置原则
        /// </summary>
        public void Invoke_Beginner()
        {
            User user = new User();
            user.Name = "张三";
            user.ID = 1;
            SqlServerUser sqlServerUser = new SqlServerUser();
            sqlServerUser.InsertUser(user);
            sqlServerUser.GetUser(1);
        }

        public class User
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public class SqlServerUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine("插入了" + user.Name);
            }
            public User GetUser(int id)
            {
                Console.WriteLine("获取了ID是" + id + " 的用户 ");
                return null;
            }
        }
    }
}
