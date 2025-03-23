using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.CreativeDesignPattern.Factory.Example_ChangeDataBase
{
    /// <summary>
    /// 抽象工厂模式
    /// </summary>
    public class Expert
    {
        public void Invoke_Expert()
        {
            User user = new User();
            user.Name = "张三";
            user.ID = 1;

            Department department = new Department();
            department.Name = "人事部";
            department.ID = 1;

            // 如果使用其他数据库，只需要修改这里
            AbstractFactory databaseFactory = new SqlServerFactory();

            // 建立工厂产品，实例化 SqlServerUser
            IDatabaseUser databaseUser = databaseFactory.GetDatabaseUser();
            databaseUser.InsertUser(user);
            databaseUser.GetUser(1);
            // 建立工厂产品，实例化 SqlServerDepartment
            IDatabaseDepartment databaseDepartment = databaseFactory.GetDatabaseDepartment();
            databaseDepartment.InsertDepartment(department);
            databaseDepartment.GetDepartment(1);
        }

        #region 实体类
        public class User
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public class Department
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        #endregion

        #region 工厂接口
        public interface AbstractFactory
        {
            IDatabaseUser GetDatabaseUser();
            IDatabaseDepartment GetDatabaseDepartment();
        }
        #endregion

        #region 抽象产物接口
        public interface IDatabaseDepartment
        {
            void InsertDepartment(Department department);
            Department GetDepartment(int id);
        }

        public interface IDatabaseUser
        {
            void InsertUser(User user);
            User GetUser(int id);
        }

        #endregion

        #region 工厂实例
        public class SqlServerFactory : AbstractFactory
        {
            public IDatabaseUser GetDatabaseUser()
            {
                return new SqlServerUser();
            }

            public IDatabaseDepartment GetDatabaseDepartment()
            {
                return new SqlServerDepartment();
            }
        }

        public class MySqlFactory : AbstractFactory
        {
            public IDatabaseUser GetDatabaseUser()
            {
                return new MySqlUser();
            }

            public IDatabaseDepartment GetDatabaseDepartment()
            {
                return new MySqlDepartment();
            }
        }

        public class SQLiteFactory : AbstractFactory
        {
            public IDatabaseUser GetDatabaseUser()
            {
                return new SQLiteUser();
            }

            public IDatabaseDepartment GetDatabaseDepartment()
            {
                return new SQLiteDepartment();
            }
        }

        #endregion

        #region 工厂实例，产物：User
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
        #endregion

        #region 工厂实例，产物：Department
        public class SqlServerDepartment : IDatabaseDepartment
        {
            public void InsertDepartment(Department department)
            {
                Console.WriteLine("SqlServer 插入了" + department.Name);
            }
            public Department GetDepartment(int id)
            {
                Console.WriteLine("SqlServer 获取了ID是" + id + " 的部门 ");
                return null;
            }
        }

        public class MySqlDepartment : IDatabaseDepartment
        {
            public void InsertDepartment(Department department)
            {
                Console.WriteLine("MySql 插入了" + department.Name);
            }
            public Department GetDepartment(int id)
            {
                Console.WriteLine("MySql 获取了ID是" + id + " 的部门 ");
                return null;
            }
        }

        public class SQLiteDepartment : IDatabaseDepartment
        {
            public void InsertDepartment(Department department)
            {
                Console.WriteLine("SQLite 插入了" + department.Name);
            }
            public Department GetDepartment(int id)
            {
                Console.WriteLine("SQLite 获取了ID是" + id + " 的部门 ");
                return null;
            }
        }

        #endregion

    }
}
