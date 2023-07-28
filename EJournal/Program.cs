using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EJournal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var City = new City();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите что хотите сделать");
                Console.WriteLine("1. Добавить новую школу");
                Console.WriteLine("2. Удалить одну из школ");
                Console.WriteLine("3. Вывести информацию по выбраной школе");
                Console.WriteLine("4. Вывести информацию обо всех школах");
                Console.WriteLine("esc Выход из программы");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите название новой школы:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите номер новой школы:");
                                if (int.TryParse(Console.ReadLine(), out int number))
                                {
                                    if (City.NewSchool(name, number))
                                        break;
                                }
                                else
                                    Tool.Msg("Номер должен состоять только из цифр!");
                            }
                            break;
                        }

                    case (ConsoleKey.D2):
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите номер школы:");
                                if (int.TryParse(Console.ReadLine(), out int number))
                                {
                                    if (City.DestroySchool(number))
                                        break;
                                }
                                else
                                    Tool.Msg("Номера состоят только из цифр!");
                            }
                            break;
                        }

                    case (ConsoleKey.D3):
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите номер школы:");
                                if (int.TryParse(Console.ReadLine(), out int number))
                                {
                                    if (City.PrintSchool(number))
                                    {
                                        Tool.WaitStart();
                                        break;
                                    }
                                }
                                else
                                    Tool.Msg("Номера состоят только из цифр!");
                            }
                            break;
                        }

                    case (ConsoleKey.D4):
                        City.PrintAllSchool();
                        Tool.WaitStart();
                        break;

                    case (ConsoleKey.Escape):
                        Console.Clear();
                        return;

                    default:
                        Tool.Msg("Нет такой команды");
                        break;
                }
            }
        }
    }
}
