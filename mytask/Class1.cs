using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytask
{
    class Library
    {
        private List<Literature> litList;

        public Library()
        {
            litList = new List<Literature>();
        }

        public Library(Library a)
        {
            for (int i = 0; i < a.litList.Count; i++)
            {
                this.litList.Add(a.litList[i]);
            }
        }

        public string Show(int x, int y)
        {
            if (x <= 0 || y <= 0 || x >= y || y >= litList.Count)
                throw new ArgumentOutOfRangeException("Указаны неверные границы для вывода.");
            string str = "";
            for (int i = x; i < y; i++)
            {
                str += $"[{i}] " + litList[i].ToString() + "\n";
            }
            return str;
        }

        public string Show(int y)
        {
            return Show(0, y);
        }
    }


    abstract class Literature
    {
        private string title;
        private DateTime year;
    }

    class Book : Literature
    {

    }

    class Paper : Literature
    {


    }

    class Magazine : Literature
    {

    }

}
