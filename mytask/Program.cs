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

        }

        class Bicycle
        {
            private DateTime year;
            //повреждение от 0 до 100.
            private int damage;

            private bool owner;

            private int price;
            private string Company;

            public DateTime Year
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


            public override string ToString()
            {
                string tmp = Owner ? "Есть" : "Нет";
                return string.Format(
                    $"Степерь повреждений:{Damage}%\tПроизводитель{Company}\t{Year.Year}\tВладелец:{tmp}");
            }
        }

        class Bicycler
        {
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
                get{return name;}
                set{name = value;}
            }

            public Bicycler(Bicycle bike,int skill)
            {
                Bike = bike;
                Skill = skill;
            }

            public override string ToString()
            {
                return String.Format($"Имя:{Name} Навык:{Skill}") + Bike.ToString();
            }
        }


    }

    //каждый велосипедист выбирает себе велик из числа великов, причем выбирать велик у которого уже естьв ладелец нельзя.


}
