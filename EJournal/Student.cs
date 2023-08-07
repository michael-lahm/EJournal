using System;
using System.Collections.Generic;
using System.Data;

namespace EJournal
{
    internal class InterfaceStudent
    {
        readonly private DataRow Data;

        public InterfaceStudent(DataRow Data)
        {
            this.Data = Data;
        }

        /// <summary>
        /// Выводит всю информацию об ученике
        /// </summary>
        public void Print()
        {
            Console.Clear();
            Console.WriteLine($"Ученик: {Data["Имя"]}");
            for (int i = 1; i < Data.Table.Columns.Count; i++)
            {
                Console.Write($"{Data.Table.Columns[i].ColumnName}");
                Console.CursorLeft = 20;
                ((List<byte>)Data[i]).ForEach((byte x) => Console.Write($"{x} "));
                Console.WriteLine();
            }
            Console.WriteLine("\nДля выхода нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
