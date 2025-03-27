using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._1_Mediator
{
    public class _1_Default
    {
        // A,B两个人打牌
        void Invoke_default()
        {
            AbstractCardPartner A = new ParterA();
            A.MoneyCount = 20;
            AbstractCardPartner B = new ParterB();
            B.MoneyCount = 20;

            // A 赢了则B的钱就减少
            A.ChangeCount(5, B);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            // B赢了A的钱也减少
            B.ChangeCount(10, A);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount); // 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
            Console.Read();
        }


        // 抽象牌友类
        public abstract class AbstractCardPartner
        {
            public int MoneyCount { get; set; }

            public AbstractCardPartner()
            {
                MoneyCount = 0;
            }

            public abstract void ChangeCount(int Count, AbstractCardPartner other);
        }


        #region
        // 牌友A类
        public class ParterA : AbstractCardPartner
        {
            public override void ChangeCount(int Count, AbstractCardPartner other)
            {
                this.MoneyCount += Count;
                other.MoneyCount -= Count;
            }
        }
        // 牌友B类
        public class ParterB : AbstractCardPartner
        {
            public override void ChangeCount(int Count, AbstractCardPartner other)
            {
                this.MoneyCount += Count;
                other.MoneyCount -= Count;
            }
        }
        #endregion
    }
}
