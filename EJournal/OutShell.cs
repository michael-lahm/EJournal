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
    internal static class InterfaceClassteacher
    {
        /// <summary>
        /// Вывод оценок всех учеников по всем предметам
        /// </summary>
        public static void PrintAll(DataTable DataClass)
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
                foreach (DataRow row in DataClass.Rows)
                {
                    Console.Write(row[0] + "\t");
                    if(row[subjNum].GetType() == typeof(List<byte>))
                        ((List<byte>)row[subjNum]).ForEach((byte x) => Console.Write($"{x} "));
                    Console.WriteLine();
                }

                Console.WriteLine("\nДля выхода нажмите любую клавишу");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Создание нового предмета
        /// </summary>
        public static void CreateSubj(DataTable DataClass)
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
        public static void DeletSubj(DataTable DataClass)
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
        public static void CreateStudent(DataTable DataClass)
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
        public static void DeletStudent(DataTable DataClass)
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
        public static void Begin(DataTable DataClass)
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
                        CreateSubj(DataClass);
                        break;

                    case (ConsoleKey.D2):
                        DeletSubj(DataClass);
                        break;

                    case (ConsoleKey.D3):
                        CreateStudent(DataClass);
                        break;

                    case (ConsoleKey.D4):
                        DeletStudent(DataClass);
                        break;

                    case (ConsoleKey.D5):
                        PrintAll(DataClass);
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
