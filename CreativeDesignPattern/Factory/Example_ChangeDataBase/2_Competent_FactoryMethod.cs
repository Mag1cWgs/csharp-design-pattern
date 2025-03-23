using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory.Example_ChangeDataBase
{
    /// <summary>
    /// 2. 工厂方法模式
    ///     不方便拓展，每次增加一个数据库，都需要增加一个工厂类
    ///     会导致类爆炸
    /// </summary>
    public class Competent
    {
        /// <summary>
        /// 使用工厂模式，实现对数据库的操作
        /// </summary>
        public void Invoke_Competent()
        {
            User user = new User();
            user.Name = "张三";
            user.ID = 1;

            // 如果使用其他数据库，只需要修改这里
            IDatabaseFactory databaseFactory = new SqlServerFactory();

            // 建立工厂产品，实例化 SqlServerUser
            IDatabaseUser databaseUser = databaseFactory.GetDatabaseUser();
            databaseUser.InsertUser(user);
            databaseUser.GetUser(1);
        }

        public class User
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public interface IDatabaseFactory
        {
            IDatabaseUser GetDatabaseUser();
        }

        public class SqlServerFactory : IDatabaseFactory
        {
            public IDatabaseUser GetDatabaseUser()
            {
                return new SqlServerUser();
            }
        }

        public class MySqlFactory : IDatabaseFactory
        {
            public IDatabaseUser GetDatabaseUser()
            {
                return new MySqlUser();
            }
        }

        public class SQLiteFactory : IDatabaseFactory
        {
            public IDatabaseUser GetDatabaseUser()
            {
                return new SQLiteUser();
            }
        }


        public interface IDatabaseUser
        {
            void InsertUser(User user);
            User GetUser(int id);
        }


        public class SqlServerUser : IDatabaseUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine("SqlServer 插入了" + user.Name);
            }
            public User GetUser(int id)
            {
                Console.WriteLine("SqlServer 获取了ID是" + id + " 的用户 ");
                return null;
            }
        }

        public class MySqlUser : IDatabaseUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine("MySql 插入了" + user.Name);
            }
            public User GetUser(int id)
            {
                Console.WriteLine("MySql 获取了ID是" + id + " 的用户 ");
                return null;
            }
        }


        public class SQLiteUser : IDatabaseUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine("SQLite 插入了" + user.Name);
            }
            public User GetUser(int id)
            {
                Console.WriteLine("SQLite 获取了ID是" + id + " 的用户 ");
                return null;
            }
        }

    }
}
