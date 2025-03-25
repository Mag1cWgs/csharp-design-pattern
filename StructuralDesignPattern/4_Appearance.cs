using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public class _4_Appearance
    {
        void Invoke_Appearance()
        { 
            ShiZhengDaTing szdt = new ShiZhengDaTing();
            szdt.KaiZhengMing();
        }

        public class ShiZhengDaTing
        {
            private Police police = new Police();
            private Street street = new Street();
            private Hospital hospital = new Hospital();

            public void KaiZhengMing()
            {
                this.police.GetHuJi();
                this.street.GetHuKou();
                this.hospital.GetBorn();
            }
        }


        public class Police
        {
            public void GetHuJi()
            {
                Console.WriteLine("开具户籍证明");
            }
        }

        public class Street
        {
            public void GetHuKou()
            {
                Console.WriteLine("开具户口证明");
            }
        }
        
        public class Hospital
        {
            public void GetBorn()
            {
                Console.WriteLine("开具出生证明");
            }
        }
    }
}
