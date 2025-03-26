using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.StructuralDesignPattern
{
    public  class _7_Flyweight
    {
        void Invoke_Flyweight()
        {
            Factory_FlyWeight factory = new Factory_FlyWeight();
            Bike_Abstract_FlyWeight bike1 = factory.GetBike();
            Bike_Abstract_FlyWeight bike2 = factory.GetBike();
            Bike_Abstract_FlyWeight bike3 = factory.GetBike();


            bike1.Ride("User1");
            bike2.Ride("User2");

            bike1.Back("User1");
            bike1.Ride("User3");

        }


        public abstract class Bike_Abstract_FlyWeight
        {
            //内部状态:BikeID State->bool
            //外部状态:用户
            //骑行 锁定
            public string BikeID { get; set; }

            public bool State_IsUsing { get; set; }

            public abstract void Ride(string userName);

            public abstract void Back(string userName);
        }


        public class ConcreteBike_FlyWeight : Bike_Abstract_FlyWeight
        {
            public ConcreteBike_FlyWeight(string bikeID)
            {
                this.BikeID = bikeID;
            }
            public override void Ride(string userName)
            {
                if (State_IsUsing)
                    Console.WriteLine("Bike is using");
                else
                {
                    State_IsUsing = true;
                    Console.WriteLine("Bike is using by {0}, ID is {1}." + userName, this.BikeID);
                }
            }
            public override void Back(string userName)
            {
                if (State_IsUsing)
                {
                    State_IsUsing = false;
                    Console.WriteLine("Bike is BACK by {0}, ID is {1}." + userName, this.BikeID);
                }
                else
                    Console.WriteLine("Bike is not using");
            }
        }




        public class Factory_FlyWeight
        {
            // 此处使用字典存储对象，实际应用中可以使用数据库或者其他方式存储
            // 也可以使用线程安全的集合，如ConcurrentDictionary
            // 也可以 List<Bike_Abstract_FlyWeight> bikePool = new List<Bike_Abstract_FlyWeight>();
            private Dictionary<string, Bike_Abstract_FlyWeight> bikePool = new Dictionary<string, Bike_Abstract_FlyWeight>();

            //初始化对象池
            public Factory_FlyWeight()
            {
                bikePool.Add("001", new ConcreteBike_FlyWeight("001"));
                bikePool.Add("002", new ConcreteBike_FlyWeight("002"));
                bikePool.Add("003", new ConcreteBike_FlyWeight("003"));
            }

            public Bike_Abstract_FlyWeight GetBike()
            {
                foreach (var item in bikePool)
                {
                    if (!item.Value.State_IsUsing)
                        return item.Value;
                }
                return null;
            }
        }

    }
}
