using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

/*
Мартиросян Тигран.
Вариант 3.
Программирование.
176(1)    
*/
namespace var3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Transformer tr = new Transformer();

                Figure[] figuresArr = new Figure[10];
                for (int i = 0; i < figuresArr.Length; i++)
                {
                    if (Randomizer.Next(0, 2) == 0)
                    {
                        figuresArr[i] = new Square(Randomizer.Next(10, 25));
                    }
                    else
                    {
                        figuresArr[i] = new Triangle(Randomizer.Next(10, 25));
                    }
                    //пожписали обработчик на вот это событие, которое происходит в Transormer'e
                    tr.IsIncreasedEvent += figuresArr[i].IsIncreasedEventHendler;
                }

                int n;
                do
                {
                    Console.WriteLine("Введите количество трансформаций:");
                } while (!int.TryParse(Console.ReadLine(), out n));

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nTransform: {i + 1}");
                    tr.Increase();
                    for (int j = 0; j < figuresArr.Length; j++)
                    {
                        Console.WriteLine(figuresArr[j]);
                    }
                }
                Console.WriteLine("\nВот и программе конец, а кто пользовался молодец.");
                Console.WriteLine("ESC чтобы выйти, все что угодно, чтобы оперировать фигурами заново. ");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        
    }
}


