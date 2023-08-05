using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EJournal
{
    /// <summary>
    /// Интерфейс для классного руководителя
    /// </summary>
    internal class InterfaceTeacher
    {
        public DataTable DataClass { private get; set; }
        readonly private string Character;

        public InterfaceTeacher(string character, DataTable dataClass)
        {
            DataClass = dataClass;
            Character = character;
        }

        /// <summary>
        /// Вывод оценок всех учеников по всем предметам
        /// </summary>
        public void PrintAll()
        {
            
        }


        /// <summary>
        /// Начальное меню для учителя
        /// </summary>
        public void Begin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите что хотите сделать");
                Console.WriteLine("1. Добавить оценку");
                Console.WriteLine("2. Удалить оценку");
                Console.WriteLine("3. Посмотреть оценки");
                Console.WriteLine("esc Выход");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):

                        break;

                    case (ConsoleKey.D2):

                        break;

                    case (ConsoleKey.D3):
                        PrintAll();
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
