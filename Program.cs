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
        static List<string> allMonths = new List<string> {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        struct plant 
        {
            string name;
            int month;
            int seedsAmount;
            double price;
            public override string ToString() 
            {
                return $"{name, 5} | {allMonths[month], 8} | {seedsAmount} | {price} ";
            }
        }
        static void Main(string[] args) 
        {
            string filename = GetFilename(); // получаем имя 
            FileStream sourceStream = new FileStream(filename, FileMode.OpenOrCreate); // открываем или создаём файл.
            Stack<plant> stack = new Stack<plant>(); // создаём стэк
            ReadFile(ref sourceStream, ref stack); // читаем данные из файла
            int menu;
            do
            {
                Console.Clear();
                Console.WriteLine("1.Отобразить содержимое стека");
                Console.WriteLine("2.Записать данные в обратном порядке");
                Console.WriteLine("3.Добавить новый элемент в конец (в вершину стека)");
                Console.WriteLine("4.Удалить элемент по индексу");
                Console.WriteLine("5.Удалить последний элемент (из вершины стека)");
                Console.WriteLine("6.Корректировать элемент");
                Console.WriteLine("7.Высаживать весной");
                Console.WriteLine("8.Корректировать цену");
                Console.WriteLine("9.Выход");
                Int32.TryParse(Console.ReadLine(), out menu);
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Содержимое стека:");
                        Show(ref stack);
                        break;
                    case 2: 
                        Console.WriteLine("Записали в обратном порядке");
                        Exit();
                        break;
                    case 3:
                        Console.WriteLine("Добавляем элемент в вершину стека(в конец)");
                        Exit();
                        break;
                    case 4:
                        Console.WriteLine("Удаляем элемент");
                        Exit();
                        break;
                    case 5:
                        Console.WriteLine("Удаляем элемент из вершины стека(с конца)");
                        Exit();
                        break;
                    case 6:
                        Console.WriteLine("Корректируем элемент");
                        Exit();
                        break;
                    case 7:
                        Console.WriteLine("Высаживаем весной");
                        Exit();
                        break;
                    case 8:
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

        private static void ReadFile(ref FileStream sourceStream,ref Stack<plant> stack) 
        {
            Console.WriteLine("Прочитали файл");
            Exit();
        }

        private static void WriteFile(ref FileStream sourceStream, ref Stack<plant> stack) 
        {
            Console.WriteLine("Записали в файл");
            Exit();
        }

        private static void Show(ref Stack<plant> stack) 
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

        public static void Exit() 
        {
            Console.WriteLine("Для возврата в меню нажмите любую кнопку (кроме отключения питания устройства)");
            Console.ReadKey();
        }
    }
}
