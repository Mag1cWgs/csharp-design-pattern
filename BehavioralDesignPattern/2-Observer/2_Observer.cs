using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._2_Observer
{
    public class _2_Observer
    {
        void Invoke_Observer()
        {
            Observer_TenXun_Abstract observer = new TenXunGame("Observer_TenXun_Abstract Game", "Have a new game published ....");

            // 添加订阅者
            observer.AddSubscriber(new Subscriber("Learning Hard"));
            observer.AddSubscriber(new Subscriber("Tom"));

            observer.Update();

            Console.ReadLine();
        }

        // 订阅号抽象类
        public abstract class Observer_TenXun_Abstract
        {
            // 保存订阅者列表
            private List<ISubscriber> observers = new List<ISubscriber>();

            public string Symbol { get; set; }
            public string Info { get; set; }
            public Observer_TenXun_Abstract(string symbol, string info)
            {
                this.Symbol = symbol;
                this.Info = info;
            }

            #region 新增对订阅号列表的维护操作
            public void AddSubscriber(ISubscriber ob)
            {
                observers.Add(ob);
            }
            public void RemoveSubscriber(ISubscriber ob)
            {
                observers.Remove(ob);
            }
            #endregion

            public void Update()
            {
                // 遍历订阅者列表进行通知
                foreach (ISubscriber ob in observers)
                {
                    if (ob != null)
                    {
                        ob.ReceiveAndPrint(this);
                    }
                }
            }
        }

        // 具体订阅号类
        public class TenXunGame : Observer_TenXun_Abstract
        {
            public TenXunGame(string symbol, string info)
                : base(symbol, info)
            {
            }
        }

        // 订阅者接口
        public interface ISubscriber
        {
            void ReceiveAndPrint(Observer_TenXun_Abstract tenxun);
        }

        // 具体的订阅者类
        public class Subscriber : ISubscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            public void ReceiveAndPrint(Observer_TenXun_Abstract tenxun)
            {
                Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
            }
        }
    }
}
