using System;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pr2
{
    class Program
    {
        static List<string> allMonths = new List<string> {"январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
        public struct Plant 
        {
            string name;
            int month;
            int seedsAmount;
            double price;
            public Plant(string n, int m, int s, double p) 
            {
                name = n;
                month = m;
                seedsAmount = s;
                price = p;
            }
            public override string ToString() 
            {
                return $"{name, 5} | {allMonths[month], 8} | {seedsAmount} | {price} ";
            }
        }
        static void Main(string[] args) 
        {
            string filename = GetFilename(); // получаем имя 
            FileStream sourceStream = new FileStream(filename, FileMode.OpenOrCreate); // открываем или создаём файл.
            Stack<Plant> stack = new Stack<Plant>(); // создаём стэк
            ReadFile(ref sourceStream, ref stack); // читаем данные из файла
            int menu;
            ConsoleKey btn;
            do
            {
                Console.Clear();
                Console.WriteLine("1.Отобразить содержимое стека");
                Console.WriteLine("2.Записать данные в обратном порядке");
                Console.WriteLine("3.Добавить новый элемент в начало (в вершину стека)");
                Console.WriteLine("4.Удалить элемент по индексу");
                Console.WriteLine("5.Удалить первый элемент (из вершины стека)");
                Console.WriteLine("6.Корректировать элемент");
                Console.WriteLine("7.Что высаживать весной");
                Console.WriteLine("8.Корректировать цену");
                Console.WriteLine("9.Выход");
                Int32.TryParse(Console.ReadLine(), out menu);
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        //Console.WriteLine("Содержимое стека:");
                        Show(ref stack);
                        break;
                    case 2: 
                        //Console.WriteLine("Записали в обратном порядке");
                        stack.Reverse();
                        Exit();
                        break;
                    case 3:
                        //Console.WriteLine("Добавляем элемент в начало (в вершину стека)");
                        stack.Push(CreateNewPlant());
                        Exit();
                        break;
                    case 4:
                        //Console.WriteLine("Удаляем элемент из вершины стека(с конца)");
                        Console.WriteLine(stack.Pop());
                        Exit();
                        break;
                    case 5:
                        Console.WriteLine("Корректируем элемент");
                        Exit();
                        break;
                    case 6:
                        Console.WriteLine("Высаживаем весной");
                        int i = 0;
                        foreach (Plant item in stack) 
                        {
                            if (item.month > )
                                Console.WriteLine("{0}|{1}",++i,item);
                        }
                        Exit();
                        break;
                    case 7:
                        Console.WriteLine("Корректируем цену");
                        Exit();
                        break;
                }
            }
            while (menu != 9);

            WriteFile(ref sourceStream, ref stack);
        }

        public static string GetFilename() 
        {
            string filename;
            do 
            {
                Console.Clear();
                Console.WriteLine("Введите имя обрабатываемого файла:");
                filename = Console.ReadLine();
            } while (filename == null);
            return filename;
        }

        public static void ReadFile(ref FileStream sourceStream,ref Stack<Plant> stack) 
        {
            Console.WriteLine("Прочитали файл");
            Exit();
        }

        public static void WriteFile(ref FileStream sourceStream, ref Stack<Plant> stack) 
        {
            Console.WriteLine("Записали в файл");
            Exit();
        }

        public static void Show(ref Stack<Plant> stack) 
        {
            ConsoleKeyInfo action;
            Console.Clear();
            Console.WriteLine("Название|месяц|кол-во семян|цена");
            do
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Enter - для возврата в меню");
                action = Console.ReadKey();

            } while (action.Key != ConsoleKey.Enter);
        }
        public static Plant CreateNewPlant() 
        {
            string name, strTmp;
            int seedsAmount, month;
            double price;

            do
            {
                Console.Clear();
                Console.WriteLine("Введите название растения:");
                name = Console.ReadLine();
            } while ( name == null || name.Length == 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Введите месяц посадки (номер месяца / название месяца):");
                strTmp = Console.ReadLine();
            } while (strTmp == null || !(Int32.TryParse(strTmp, out month) && month > 0 && month < 13) || (month = allMonths.IndexOf(strTmp)) < 0 );

            do
            {
                Console.Clear();
                Console.WriteLine("Введите количество семян в упаковке:");
            } while (!Int32.TryParse(Console.ReadLine(), out seedsAmount) || seedsAmount < 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Введите цену упаковки:");
            } while (!Double.TryParse(Console.ReadLine(), out price) || price < 0);

            return new Plant(name, month, seedsAmount, price); ;
        }

        

        public static void Exit() 
        {
            Console.WriteLine("Для возврата в меню нажмите любую кнопку (кроме отключения питания устройства)");
            Console.ReadKey();
        }
    }
}
