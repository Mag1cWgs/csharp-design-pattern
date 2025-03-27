using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._7_Strategy
{
    public class _7_Strategy
    {
        void Invoke_Strategy(string[] args)
        {
            // 个人所得税方式
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));

            // 企业所得税
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));

            Console.Read();
        }


        // Strategy 抽象策略类：所得税计算策略
        public interface ITaxStragety
        {
            double CalculateTax(double income);
        }

        // 操作类/环境角色/Context
        public class InterestOperation
        {
            // 持有策略类引用
            private ITaxStragety m_strategy;

            // 在构造时注入具体的策略
            public InterestOperation(ITaxStragety strategy)
            {
                this.m_strategy = strategy;
            }

            // 调用策略中的方法
            public double GetTax(double income)
            {
                return m_strategy.CalculateTax(income);
            }
        }

        #region ConcreteStrategy 具体策略类
        // 个人所得税
        public class PersonalTaxStrategy : ITaxStragety
        {
            public double CalculateTax(double income)
            {
                return income * 0.12;
            }
        }

        // 企业所得税
        public class EnterpriseTaxStrategy : ITaxStragety
        {
            public double CalculateTax(double income)
            {
                return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
            }
        }
        #endregion
    }
}
