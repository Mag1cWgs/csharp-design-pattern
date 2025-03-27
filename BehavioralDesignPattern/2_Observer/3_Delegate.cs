using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._2_Observer
{
    public class _3_Delegate
    {

        void Invoke_Delegate(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");
            Subscriber lh = new Subscriber("Learning Hard");
            Subscriber tom = new Subscriber("Tom");

            // 添加订阅者
            // 对委托链添加新的函数
            tenXun.AddObserver(new NotifyEventHandler(lh.ReceiveAndPrint));
            tenXun.AddObserver(new NotifyEventHandler(tom.ReceiveAndPrint));

            // 触发函数
            tenXun.Update();

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除Tom订阅者");
            tenXun.RemoveObserver(new NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();

            Console.ReadLine();
        }

        // 委托充当订阅者接口类
        // 传入值为订阅号类的实例
        public delegate void NotifyEventHandler(object sender);

        // 抽象订阅号类
        public class TenXun
        {
            // 内部维护
            public NotifyEventHandler NotifyEvent;

            public string Symbol { get; set; }
            public string Info { get; set; }
            public TenXun(string symbol, string info)
            {
                this.Symbol = symbol;
                this.Info = info;
            }

            #region 新增对订阅号列表的维护操作
            // 向委托列表中追加一个新的委托
            // 实际就是添加了一个新的函数
            public void AddObserver(NotifyEventHandler ob)
            {
                NotifyEvent += ob;
            }
            // 从现有委托列表中去除相应委托
            public void RemoveObserver(NotifyEventHandler ob)
            {
                NotifyEvent -= ob;
            }
            #endregion

            public void Update()
            {   // 存在订阅者时，向委托列表传入自己作为参数
                if (NotifyEvent != null)
                {
                    NotifyEvent(this);
                }
            }
        }

        // 具体订阅号类
        public class TenXunGame : TenXun
        {
            public TenXunGame(string symbol, string info)
                : base(symbol, info)
            {
            }
        }

        // 无需单独抽象一个抽象订阅者类

        // 具体订阅者类
        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            public void ReceiveAndPrint(Object obj)
            {
                // 将传入的 obj 尝试转换为 TenXun 类
                TenXun tenxun = obj as TenXun;
                // 转换成功则执行
                if (tenxun != null)
                {
                    Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
                }
            }
        }
    }
}
