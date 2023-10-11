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
        struct plant 
        {
            string name;
            int month;
            int seedsAmount;
            double price;
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
                Console.WriteLine("2.Добавить новый элемент");
                Console.WriteLine("3.Удалить элемент по индексу");
                Console.WriteLine("4.Корректировать элемент");
                Console.WriteLine("5.Высаживать весной");
                Console.WriteLine("6.Корректировать цену");
                Console.WriteLine("7.Выход");
                Int32.TryParse(Console.ReadLine(), out menu);
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Содержимое стека");
                        Exit();
                        break;
                    case 2:
                        Console.WriteLine("Добавляем элемент");
                        Exit();
                        break;
                    case 3:
                        Console.WriteLine("Удаляем элемент");
                        Exit();
                        break;
                    case 4:
                        Console.WriteLine("Корректируем элемент");
                        Exit();
                        break;
                    case 5:
                        Console.WriteLine("Высаживаем весной");
                        Exit();
                        break;
                    case 6:
                        Console.WriteLine("Корректируем цену");
                        Exit();
                        break;
                }
            }
            while (menu != 7);

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

        public static void Exit() 
        {
            Console.WriteLine("Для возврата в меню нажмите любую кнопку (кроме отключения питания устройства)");
            Console.ReadKey();
        }
    }
}
