using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EJournal
{
    /// <summary>
    /// Интерфейс для классного учителя
    /// </summary>
    internal static class InterfaceClassteacher
    {
        /// <summary>
        /// Вывод оценок всех учеников по всем предметам
        /// </summary>
        public static void PrintAll(DataTable dataTable)
        {
            while (true)
            {
                int subjNum;
                while (true)                                                        //Ожидаем выбор нужного предмета
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер нужного предмета");
                    Console.WriteLine("для выхода нажмите esc");
                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        Console.WriteLine($"{i}. {dataTable.Columns[i]}");
                    }
                    string line = Tool.InputWithEscape();
                    if (line == null)
                        return;
                    int.TryParse(line, out subjNum);
                    if ((0 < subjNum) && (subjNum < dataTable.Columns.Count))
                        break;
                    Tool.Msg("Не верный ввод!");
                }

                Console.Clear();                                                        //Вывод оценок по предмету
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.Write(row[0] + "\t");
                    ((List<byte>)row[subjNum]).ForEach((byte x) => Console.Write($"{x} "));
                }

                Console.WriteLine("\nДля выхода нажмите любую клавишу");
                Console.ReadKey();
            }
        }
        public static void PrintAllS(DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
                Console.Write($"{column.ColumnName}\t");
            Console.WriteLine();
            // перебор всех строк таблицы
            foreach (DataRow row in dataTable.Rows)
            {
                // получаем все ячейки строки
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    if (cell.GetType() == typeof(string))
                        Console.Write($"{cell}\t");
                    else
                        ((List<byte>)cell).ForEach((byte x) => Console.Write($"{x} "));
                }
                
                Console.WriteLine();
            }
        }
        public static void Begin()
        {
            Console.Clear();
            Console.WriteLine("Выберите что хотите сделать");
            Console.WriteLine("1. Добавить ученика");
            Console.WriteLine("2. Удалить ученика");
            Console.WriteLine("3. Добавить предмет");
            Console.WriteLine("4. Удалить предмет");
            Console.WriteLine("esc Выход из программы");
            Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

            switch (Console.ReadKey().Key)
            {
                case (ConsoleKey.D1):
                    {
                        
                        break;
                    }

                case (ConsoleKey.D2):
                    {
                        
                        break;
                    }

                case (ConsoleKey.D3):
                    {
                        
                        break;
                    }

                case (ConsoleKey.D4):
                    
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

    internal static class InterfaceTeacher
    {

    }

    internal static class InterfaceStudent
    {

    }
}
