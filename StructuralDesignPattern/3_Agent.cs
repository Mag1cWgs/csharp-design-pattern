using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public class _3_Agent_1
    {
        void Invoke_Agent()
        {
            // 目标 真实对象TargetPerson
            TargetPerson target = new TargetPerson() { Name = "Tom" };

            // 代理人Proxy，传入代理对象
            // 代理对象RealSubject_WantToSent 中持有 真实对象真实对象TargetPerson 的引用
            ISubject proxy = new Proxy(new RealSubject_WantToSent(target));

            // 代理人 调用 代理对象 的方法
            proxy.GiveFlowers();
            proxy.GiveDrinks();
            proxy.GiveChocolate();

        }

        /// <summary>
        /// 共用接口
        /// </summary>
        public interface ISubject
        {
            void GiveFlowers();
            void GiveDrinks();
            void GiveChocolate();
        }

        /// <summary>
        /// 真实对象
        /// </summary>
        public class TargetPerson
        {
            public string Name { get; set; }
        }

        /// <summary>
        /// 代理对象
        /// </summary>
        public class RealSubject_WantToSent : ISubject
        {
            private TargetPerson target;

            public RealSubject_WantToSent(TargetPerson person)
            {
                this.target = person;
            }

            public void GiveFlowers()
            {
                Console.WriteLine("Give Flowers To :{0}", this.target.Name);
            }
            public void GiveDrinks()
            {
                Console.WriteLine("Give Drinks To :{0}", this.target.Name);
            }
            public void GiveChocolate()
            {
                Console.WriteLine("Give Chocolate To :{0}", this.target.Name);
            }

        }


        /// <summary>
        /// 代理类
        /// </summary>
        public class Proxy : ISubject
        {
            // 代理类中持有一个真实对象的引用
            private RealSubject_WantToSent _realSubject;

            public Proxy(RealSubject_WantToSent realSubject)
            {
                this._realSubject = realSubject;
            }

            public void GiveFlowers()
            {
                this._realSubject.GiveFlowers();
            }

            public void GiveDrinks()
            {
                this._realSubject.GiveDrinks();
            }

            public void GiveChocolate()
            {
                this._realSubject.GiveChocolate();
            }
        }
    }


    public class _3_Agent_2
    {
        // 订单系统，要求:
        // 一旦订单被创建，只有订单的创建人才可以修改订单中的数据，其他人则不能修改
        void Invoke_Agent()
        {
            IOrder order = new ProxyOrder(new RealOrder("Apple", 10, "Tom"));
            // 成功操作
            order.SetOrderProductCount(20, "Tom");
            // 权限不足
            order.SetOrderProductCount(30, "Jerry");
        }


        // 钉单
        // 订单产品名称、订单产品数量、订单创建用户
        /// <summary>
        /// 封装了实体对象和代理对象的共用接口
        /// </summary>
        public interface IOrder
        {
            // 获取订单中产品名称
            public string GetProductName();

            /// <summary>
            /// 设置订单中产品名称
            /// </summary>
            /// <param name="productNameame">订单中的产品名</param>
            /// <param name="user">操作人</param>
            void SetProductName(string productNameame, string user);

            // 获取订单中产品数量
            int GetOrderProductCount();

            /// <summary>
            /// 设置订单中产品数量
            /// </summary>
            /// <param name="orderNumber">产品数量</param>
            /// <param name="user">操作人</param>
            void SetOrderProductCount(int orderNumber, string user);

            // 获取订单创建用户
            string GetOrderUser();

            /// <summary>
            /// 设置订单创建用户
            /// </summary>
            /// <param name="orderUser">创建订单的用户名</param>
            /// <param name="user">操作人</param>
            void SetOrderUser(string orderUser, string user);
        }


        /// <summary>
        /// 真正的订单对象
        /// </summary>
        public class RealOrder : IOrder
        {
            // 具体订单的属性
            public string ProductName { get; set; }
            public int ProductCount { get; set; }
            public string OrderUser { get; set; }

            // 构造函数
            public RealOrder(string productName, int productCount, string prderUser)
            {
                this.ProductName = productName;
                this.ProductCount = productCount;
                this.OrderUser = prderUser;
            }


            // 实现接口
            // 访问过程中，没有对操作人进行限定
            public string GetProductName()
            {
                return this.ProductName;
            }

            public int GetOrderProductCount()
            {
                return this.ProductCount;
            }
            public string GetOrderUser()
            {
                return this.OrderUser;
            }

            // 赋值过程中，没有对操作人进行限定
            public void SetProductName(string productNameame, string user)
            {
                this.ProductName = productNameame;
            }
            public void SetOrderProductCount(int orderNumber, string user)
            {
                this.ProductCount = orderNumber;
            }
            public void SetOrderUser(string orderUser, string user)
            {
                this.OrderUser = orderUser;

            }
        }


        /// <summary>
        /// 代理器
        /// </summary>
        public class ProxyOrder : IOrder
        {
            // 封装对实体对象引用
            private RealOrder _realOrder;
            public ProxyOrder(RealOrder realOrder)
            {
                this._realOrder = realOrder;
            }


            public int GetOrderProductCount()
            {
                return _realOrder.ProductCount;
            }

            public string GetOrderUser()
            {
                return _realOrder.OrderUser;
            }

            public string GetProductName()
            {
                return _realOrder.ProductName;
            }


            public void SetOrderProductCount(int orderNumber, string user)
            {
                // 判断是否是订单创建人
                // 订单创建人对应的是 传入的真实订单对象中的订单创建人属性OrderUser
                if (user != null && user.Equals(this._realOrder.OrderUser))
                    this._realOrder.SetOrderProductCount(orderNumber, user);
                else
                    Console.WriteLine("权限不足！无法设置！");
            }

            public void SetOrderUser(string orderUser, string user)
            {
                if (user != null && user.Equals(this._realOrder.OrderUser))
                    this._realOrder.SetOrderUser(orderUser, user);
                else
                    Console.WriteLine("权限不足！无法设置！");
            }

            public void SetProductName(string productNameame, string user)
            {
                if (user != null && user.Equals(this._realOrder.OrderUser))
                    this._realOrder.SetProductName(productNameame, user);
                else
                    Console.WriteLine("权限不足！无法设置！");
            }
        }
    }
}