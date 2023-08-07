using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EJournal
{
    internal class InterfaceDirector
    {
        private readonly DataSet DataSchool;

        public InterfaceDirector(DataSet DataSchool)
        {
            this.DataSchool = DataSchool;
        }

        /// <summary>
        /// Создание нового класса
        /// </summary>
        private void CreateClass()
        {
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите название класса, который хотите добавить");
                Console.WriteLine("для выхода нажмите esc");
                name = Tool.InputWithEscape();
                if (name == null)
                    return;
                else if (!DataSchool.Tables.Contains(name))
                    break;
                Tool.Msg("Такой предмет уже есть!");
            }
            DataSchool.Tables.Add(new DataTable(name));
        }

        /// <summary>
        /// Удаление выбраного класса
        /// </summary>
        private void DeletClass()
        {
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите название класса, который хотите удалить");
                Console.WriteLine("для выхода нажмите esc");
                name = Tool.InputWithEscape();
                if (name == null)
                    return;
                else if (DataSchool.Tables.Contains(name))
                    break;
                Tool.Msg("Такого предмета нет!");
            }
            DataSchool.Tables.Remove(name);
        }

        /// <summary>
        /// Начальное меню для директора
        /// </summary>
        public void Begin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите что хотите сделать");
                Console.WriteLine("1. Добавить класс");
                Console.WriteLine("2. Удалить класс");
                Console.WriteLine("esc Выход");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        CreateClass();
                        break;

                    case (ConsoleKey.D2):
                        DeletClass();
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
