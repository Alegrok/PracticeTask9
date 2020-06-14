using System;

namespace PracticeTask9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение по работе с двунаправленным списком!");

            // Ввод количества элементов в двунаправленном списке
            Console.WriteLine("\nВведите количество элементов в списке");
            uint size = Input();

            // Создание двунаправленного списка
            BiList beg = BiList.MakeList(size);

            // Подсчет количества элементов
            Console.WriteLine("\nПодсчитаем количество элементов в списке с помощью двух разных функций");

            // Подсчет элементов с помощью обычной функции и вывод результата
            int count = BiList.GetCount(beg);
            Console.WriteLine($"Количество элементов с помощью нерекурсивной функции равно {count}");

            // Подсчет элементов с помощью рекурсивной функции и вывод результата
            int recount = BiList.GetCountRecurent(beg);
            Console.WriteLine($"Количество элементов с помощью рекурсивной функции равно {recount}");

            Console.WriteLine("\nЗавершение работы в приложении по работе с двунаправленным списком");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        // Ввод целого неотрицательного числа
        private static uint Input()
        {
            uint number;
            bool check;
            do
            {
                Console.Write("Ввод: ");
                check = uint.TryParse(Console.ReadLine(), out number);
                if (!check) Console.WriteLine("Ошибка! Введите целое неотрицательное число");
            } while (!check);
            return number;
        }

        // Класс двунаправленного списка
        public class BiList
        {
            public int data;    // Информационное поле
            public BiList next; // Следующий элемент
            public BiList pred; // Предыдущий элемент

            public BiList(int d)
            {
                data = d;
                next = null;
                pred = null;
            }

            // Создание элемента списка
            private static BiList MakePoint(int d)
            {
                BiList p = new BiList(d);
                return p;
            }

            // Создание двунаправленного списка
            public static BiList MakeList(uint size)
            {
                Random random = new Random();
                int d = random.Next(1, 100);
                BiList beg = MakePoint(d);
                for (int i = 1; i < size; i++)
                {
                    d = random.Next(1, 100);
                    BiList p = MakePoint(d);
                    p.next = beg;
                    beg.pred = p;
                    beg = p;
                }
                return beg;
            }

            // Поиск количества элементов списка без рекурсии
            public static int GetCount(BiList beg)
            {
                int i = 0;
                BiList p = beg;
                while (p != null)
                {
                    i++;
                    p = p.next;
                }
                return i;
            }

            // Поиск количества элементов списка с рекурсией
            public static int GetCountRecurent(BiList elem)
            {
                BiList p = elem;
                if (p == null) return 0;
                return GetCountRecurent(p.next) + 1;
            }
        }
    }
}
