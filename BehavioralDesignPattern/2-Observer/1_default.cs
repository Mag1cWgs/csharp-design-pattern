using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._2_Observer
{
    public class _1_default
    {
        void Invoke_default()
        {
            // 实例化订阅者和订阅号对象
            Subscriber LearningHardSub = new Subscriber("LearningHard");
            TenxunGame txGame = new TenxunGame();

            txGame.Subscriber = LearningHardSub;
            txGame.Symbol = "Observer_TenXun_Abstract Game";
            txGame.Info = "Have a new game published ....";

            txGame.Update();

            Console.ReadLine();
        }

        // TenxunGame 类和 Subscriber 类之间形成了一种双向依赖关系
        //     - TenxunGame 调用了 Subscriber 的 ReceiveAndPrintData 方法，
        //     - Subscriber 调用了 TenxunGame 类的属性。
        // 这样的实现，如果有其中一个类变化将引起另一个类的改变。

        // 当出现一个新的订阅者时，此时不得不修改TenxunGame代码
        //     - 即添加另一个订阅者的引用和在Update方法中调用另一个订阅者的方法。

        // 游戏订阅号类
        public class TenxunGame
        {
            // 订阅者对象
            public Subscriber Subscriber { get; set; }

            public String Symbol { get; set; }

            public string Info { get; set; }

            // 更新函数
            public void Update()
            {
                // 如果有订阅人
                if (Subscriber != null)
                {
                    // 调用订阅者对象来通知订阅者
                    Subscriber.Receive_And_PrintData(this);
                }
            }

        }

        // 订阅者类
        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            // 收到更新通知的处理函数
            public void Receive_And_PrintData(TenxunGame txGame)
            {
                Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, txGame.Symbol, txGame.Info);
            }
        }

    }
}
