using System;
using System.Collections.Generic;
using System.Data;

namespace EJournal
{
    /// <summary>
    /// Интерфейс для классного руководителя
    /// </summary>
    internal class InterfaceTeacher
    {
        public DataSet DataSchool { private get; set; }
        private DataTable DataClass;
        readonly private string Character;

        public InterfaceTeacher(string character, DataSet DataSchool)
        {
            this.DataSchool = DataSchool;
            Character = character;
        }

        /// <summary>
        /// Начальное меню для учителя
        /// </summary>
        public void Begin()
        {
            var listClass = new List<String>();                                     //Создание списка классов в которых есть предмет учителя
            for (int i = 0; i < DataSchool.Tables.Count; i++)
            {
                if (DataSchool.Tables[i].Columns.Contains(Character))
                    listClass.Add(DataSchool.Tables[i].TableName);
            }
            if (listClass.Count == 0)
            {
                Tool.Msg("Нет ни одного класса с вашим предметом");
                return;
            }

            while (true)
            {
                int subjNum;                                                            //Блок выбора нужного класса
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер нужного класса");
                    Console.WriteLine("для выхода нажмите esc");
                    for (int i = 0; i < listClass.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {listClass[i]}");
                    }

                    string line = Tool.InputWithEscape();
                    if (line == null)
                        return;
                    int.TryParse(line, out subjNum);
                    subjNum--;
                    if ((0 <= subjNum) && (subjNum < listClass.Count))
                        break;
                    Tool.Msg("Не верный ввод!");
                }

                for (int i = 0; i < DataSchool.Tables.Count; i++)                       //Сохранение выбора класса
                {
                    if (DataSchool.Tables[i].TableName == listClass[subjNum])
                    {
                        DataClass = DataSchool.Tables[i];
                        break;
                    }
                }

                HandlerClass();
            }
        }

        /// <summary>
        /// Для работы с выбранным классом
        /// </summary>
        private void HandlerClass()
        {
            while (true)                                                           //Выбор действий для обработки
            {
                Console.Clear();
                Console.WriteLine($"Класс: {DataClass.TableName}");
                Console.WriteLine("Выберите что хотите сделать");
                Console.WriteLine("1. Выбрать ученика");
                Console.WriteLine("2. Посмотреть оценки класса");
                Console.WriteLine("esc Выход");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        HandlerStudent();
                        break;

                    case (ConsoleKey.D2):
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

        /// <summary>
        /// Вывод оценок всех учеников
        /// </summary>
        private void PrintAll()
        {
            Console.Clear();
            for (int i = 1; i < DataClass.Rows.Count; i++)
            {
                Console.Write(DataClass.Rows[i][0] + "\t");
                ((List<byte>)DataClass.Rows[i][Character]).ForEach((byte x) => Console.Write($"{x} "));
                Console.WriteLine();
            }

            Console.WriteLine("\nДля выхода нажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод оценок выбранного ученика
        /// </summary>
        private void Print(int Id)
        {
            Console.Clear();
            Console.WriteLine($"Ученик: {DataClass.Rows[Id]["Имя"]}");
            Console.Write("Оценки: ");
            ((List<byte>)DataClass.Rows[Id][Character]).ForEach((byte x) => Console.Write($"{x} "));
            Console.WriteLine();
        }

        /// <summary>
        /// Для работы с выбранным учеником
        /// </summary>
        private void HandlerStudent()
        {
            int studNum;
            while (true)                                                        //Выбор требуемого ученика
            {
                Console.Clear();
                Console.WriteLine("Введите номер нужного ученика");
                Console.WriteLine("для выхода нажмите esc");
                for (int i = 1; i < DataClass.Rows.Count + 1; i++)
                {
                    Console.WriteLine($"{i}. {DataClass.Rows[i - 1]["Имя"]}");
                }

                string line = Tool.InputWithEscape();
                if (line == null)
                    return;
                int.TryParse(line, out studNum);
                if ((0 < studNum) && (studNum < DataClass.Rows.Count + 1))
                    break;
                Tool.Msg("Не верный ввод!");
            }
            studNum--;

            while (true)
            {
                Print(studNum);
                Console.WriteLine("Выберите что хотите сделать");
                Console.WriteLine("1. Добавить оценку");
                Console.WriteLine("2. Удалить оценку");
                Console.WriteLine("esc Выход");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        AddGrade(studNum);
                        break;

                    case (ConsoleKey.D2):
                        DeletGrade(studNum);
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

        /// <summary>
        /// Удаление оценки
        /// </summary>
        private void DeletGrade(int Id)
        {
            while (true)
            {
                Print(Id);
                Console.WriteLine("Введите оценку которую хотите удалить");
                Console.WriteLine("для выхода нажмите esc");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    return;
                else if (key == ConsoleKey.D2 || key == ConsoleKey.D3 || key == ConsoleKey.D4 || key == ConsoleKey.D5)
                {
                    if(!((List<byte>)DataClass.Rows[Id][Character]).Remove((byte)(Convert.ToByte(key) - 48)))
                        Tool.Msg("Нет такой оценки");
                }
                else
                    Tool.Msg("Оценки находятся в диапазоне от 2 до 5");
            }
        }

        /// <summary>
        /// Добавление оценки
        /// </summary>
        private void AddGrade(int Id)
        {
            while (true)
            {
                Print(Id);
                Console.WriteLine("Введите оценку которую хотите добавить");
                Console.WriteLine("для выхода нажмите esc");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    return;
                else if (key == ConsoleKey.D2 || key == ConsoleKey.D3 || key == ConsoleKey.D4 || key == ConsoleKey.D5)
                    ((List<byte>)DataClass.Rows[Id][Character]).Add((byte)(Convert.ToByte(key) - 48));
                else
                    Tool.Msg("Оценки ставяться в диапазоне от 2 до 5");
            }
        }
    }
}
