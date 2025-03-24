using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public class _1_Adapter
    {
        void Invoke_Adapter()
        {
            // 客户端调用
            IPhoneCharge iPhoneCharge = new PhoneChargeAdapter();
            iPhoneCharge.ChargePhone();
        }

        /// <summary>
        /// Adaptee 原生对象
        /// </summary>
        public class AndroidChargeAdaptee
        {
            public void AndroidCharge()
            {
                Console.WriteLine("Android 手机充电");
            }
        }

        /// <summary>
        /// Target 目标接口
        /// </summary>
        public interface IPhoneCharge
        {
            void ChargePhone();
        }

        /// <summary>
        /// Adapter 适配器 / 转接口
        /// </summary>
        public class PhoneChargeAdapter : IPhoneCharge
        {
            // 适配器中持有原生对象，在 Adapter 中封装了原生对象
            private AndroidChargeAdaptee androidChargeAdaptee = new AndroidChargeAdaptee();

            // 适配器中实现目标接口，调用原生对象的方法
            public void ChargePhone()
            {
                androidChargeAdaptee.AndroidCharge();
            }
        }

    }
}
