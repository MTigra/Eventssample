using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytask
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Bicycle[] bikes = new Bicycle[8];
            for (int i = 0; i < bikes.Length; i++)
            {
                bikes[i] = new Bicycle(rnd.Next(1990, 2018), rnd.Next(10, 100) * 10, "KEK");
            }

            Bicycler[] players = new Bicycler[5];
            for (int i = 0; i < players.Length; i++)
            {
                var list = bikes.Select(x => !x.Owner);
                players[i] = new Bicycler(bikes[rnd.Next(list.Count())], rnd.Next(100));
            }

            Console.WriteLine("*****START*****");
            Array.ForEach(players, Console.WriteLine);

        }
    }

    class Bicycle
    {
        private int year;
        //повреждение от 0 до 100.
        private int damage;

        private bool owner;

        private int price;
        private string company;

        public void onOwnedEvenHendler(object sender, EventArgs e)
        {
            owner = true;
        }

        public void onOwnedEventHendler(object sender, EventArgs e)
        {
             int skill =  (sender as Bicycler).Skill;

            int lapdamage = (int)( (100-skill)*0.2 );
            damage += lapdamage;
        }

        public Bicycle(int year, int price, string company, int damage = 0, bool owner = false)
        {
            Year = year;
            Price = price;
            Company = company;
            Damage = damage;
            Owner = owner;
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                price = value;
            }
        }

        public int Damage
        {
            get { return damage; }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException();
                else
                {
                    damage = value;
                }
            }
        }

        public bool Owner
        {
            get { return owner; }

            set { owner = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }


        public override string ToString()
        {
            string tmp = Owner ? "Есть" : "Нет";
            return string.Format(
                $"Степерь повреждений:{Damage}%\tПроизводитель{Company}\tГод выпуска:{Year}\tВладелец:{tmp}");
        }
    }

   

    class Bicycler
    {
        event EventHandler OwnedEvent;
        event EventHandler MakeLapEvent;

        private int skill;
        private string name;
        private Bicycle bike;

        public int Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        public Bicycle Bike
        {
            get { return bike; }
            set { bike = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Bicycler(Bicycle bike, int skill)
        {
            Bike = bike;
            Skill = skill;
            OwnedEvent(this,new EventArgs());
        }

        public void MakeLap()
        {
            MakeLapEvent(this,new EventArgs());
        }

        public override string ToString()
        {
            return String.Format($"Имя:{Name} Навык:{Skill}") + Bike.ToString();

        }
    }
//каждый велосипедист выбирает себе велик из числа великов, причем выбирать велик у которого уже естьв ладелец нельзя.


}
