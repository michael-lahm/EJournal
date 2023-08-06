using System;
using System.Collections.Generic;
using System.Data;

namespace EJournal
{
    /// <summary>
    /// Интерфейс для классного руководителя
    /// </summary>
    internal class InterfaceClassteacher
    {
        readonly private DataTable DataClass;

        public InterfaceClassteacher(DataTable dataClass)
        {
            DataClass = dataClass;
        }

        /// <summary>
        /// Вывод оценок всех учеников по всем предметам
        /// </summary>
        private void PrintAll()
        {
            while (true)
            {
                int subjNum;
                while (true)                                                        //Ожидаем выбор нужного предмета
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер нужного предмета");
                    Console.WriteLine("для выхода нажмите esc");
                    for (int i = 1; i < DataClass.Columns.Count; i++)
                    {
                        Console.WriteLine($"{i}. {DataClass.Columns[i]}");
                    }

                    string line = Tool.InputWithEscape();
                    if (line == null)
                        return;
                    int.TryParse(line, out subjNum);
                    if ((0 < subjNum) && (subjNum < DataClass.Columns.Count))
                        break;
                    Tool.Msg("Не верный ввод!");
                }

                Console.Clear();                                                        //Вывод оценок по предмету
                for (int i = 1; i < DataClass.Rows.Count; i++)
                {
                    Console.Write(DataClass.Rows[i][0] + "\t");
                    ((List<byte>)DataClass.Rows[i][subjNum]).ForEach((byte x) => Console.Write($"{x} "));
                    Console.WriteLine();
                }

                Console.WriteLine("\nДля выхода нажмите любую клавишу");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Создание нового предмета
        /// </summary>
        private void CreateSubj()
        {
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите название предмета, который хотите добавить");
                Console.WriteLine("для выхода нажмите esc");
                name = Tool.InputWithEscape();
                if (name == null)
                    return;
                else if (!DataClass.Columns.Contains(name))
                    break;
                Tool.Msg("Такой предмет уже есть!");
            }
            DataClass.Columns.Add(new DataColumn(name, typeof(List<byte>)));
        }

        /// <summary>
        /// Удаление выбраного предмета
        /// </summary>
        private void DeletSubj()
        {
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите название предмета, который хотите удалить");
                Console.WriteLine("для выхода нажмите esc");
                name = Tool.InputWithEscape();
                if (name == null)
                    return;
                else if (DataClass.Columns.Contains(name))
                    break;
                Tool.Msg("Такого предмета нет!");
            }
            DataClass.Columns.Remove(name);
        }

        /// <summary>
        /// Добавить нового ученика
        /// </summary>
        private void CreateStudent()
        {
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите имя ученика, которого хотите добавить");
                Console.WriteLine("для выхода нажмите esc");
                name = Tool.InputWithEscape();
                if (name == null)
                    return;
                else if (DataClass.Rows.Find(name) == null)
                    break;
                else
                    Tool.Msg("Ученик с таким именем уже есть!");
            }
            DataRow row = DataClass.NewRow();
            row["Имя"] = name;
            DataClass.Rows.Add(row);
        }

        /// <summary>
        /// Удалить нового ученика
        /// </summary>
        private void DeletStudent()
        {
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите имя ученика, которого хотите удалить");
                Console.WriteLine("для выхода нажмите esc");
                name = Tool.InputWithEscape();
                if (name == null)
                    return;
                var student = DataClass.Rows.Find(name);
                if (student != null)
                {
                    DataClass.Rows.Remove(student);
                    break;
                }
                else
                    Tool.Msg("Ученик с таким именем не существует!");
            }
        }

        /// <summary>
        /// Начальное меню для классного руководителя
        /// </summary>
        public void Begin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите что хотите сделать");
                Console.WriteLine("1. Добавить предмет");
                Console.WriteLine("2. Удалить предмет");
                Console.WriteLine("3. Добавить ученика");
                Console.WriteLine("4. Удалить ученика");
                Console.WriteLine("5. Посмотреть оценки");
                Console.WriteLine("esc Выход");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        CreateSubj();
                        break;

                    case (ConsoleKey.D2):
                        DeletSubj();
                        break;

                    case (ConsoleKey.D3):
                        CreateStudent();
                        break;

                    case (ConsoleKey.D4):
                        DeletStudent();
                        break;

                    case (ConsoleKey.D5):
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
