using System;
using System.Collections.Generic;
using System.Data;

namespace EJournal
{
    internal class StartMenu
    {
        private DataSet DataSchool;

        public StartMenu(DataSet DataSchool)
        {
            this.DataSchool = DataSchool;
        }

        private void Director()
        {
            var Director = new InterfaceDirector(DataSchool);  //Вход
            Director.Begin();
        }

        /// <summary>
        /// Вход для классного руководителя
        /// </summary>
        private void ClassTeacher()
        {
            int classNum;
            while (true)                                                        //Ожидаем выбор нужного класса
            {
                Console.Clear();
                Console.WriteLine("Введите номер нужного класса");
                Console.WriteLine("для выхода нажмите esc");
                for (int i = 0; i < DataSchool.Tables.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {DataSchool.Tables[i].TableName}");
                }

                string line = Tool.InputWithEscape();
                if (line == null)
                    return;
                int.TryParse(line, out classNum);
                classNum--;
                if ((0 <= classNum) && (classNum < DataSchool.Tables.Count))
                    break;
                Tool.Msg("Не верный ввод!");
            }

            var Cteacher = new InterfaceClassteacher(DataSchool.Tables[classNum]);  //Вход
            Cteacher.Begin();
        }

        /// <summary>
        /// Вход для учителя
        /// </summary>
        private void Teacher()
        {
            var listSubj = new List<String>();                                     //Создание списка всех предметов
            for (int i = 0; i < DataSchool.Tables.Count; i++)
            {
                for (int i2 = 1; i2 < DataSchool.Tables[i].Columns.Count; i2++)
                {
                    if (!listSubj.Contains(DataSchool.Tables[i].Columns[i2].ColumnName))
                        listSubj.Add(DataSchool.Tables[i].Columns[i2].ColumnName);
                }
            }

            int subjNum;
            while (true)                                                            //Ожидаем выбор нужного предмета
            {
                Console.Clear();
                Console.WriteLine("Введите номер вашего предмета");
                Console.WriteLine("для выхода нажмите esc");
                for (int i = 0; i < listSubj.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listSubj[i]}");
                }

                string line = Tool.InputWithEscape();
                if (line == null)
                    return;
                int.TryParse(line, out subjNum);
                subjNum--;
                if ((0 <= subjNum) && (subjNum < listSubj.Count))
                    break;
                Tool.Msg("Не верный ввод!");
            }

            var teacher = new InterfaceTeacher(listSubj[subjNum], DataSchool);  //Вход
            teacher.Begin();
        }

        /// <summary>
        /// Вход для ученика
        /// </summary>
        private void Student()
        {
            int classNum;
            while (true)                                                        //Ожидаем выбор нужного класса
            {
                Console.Clear();
                Console.WriteLine("Введите номер нужного класса");
                Console.WriteLine("для выхода нажмите esc");
                for (int i = 0; i < DataSchool.Tables.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {DataSchool.Tables[i].TableName}");
                }

                string line = Tool.InputWithEscape();
                if (line == null)
                    return;
                int.TryParse(line, out classNum);
                classNum--;
                if ((0 <= classNum) && (classNum < DataSchool.Tables.Count))
                    break;
                Tool.Msg("Не верный ввод!");
            }

            int studNum;
            while (true)                                                        //Ожидаем выбор нужного ученика
            {
                Console.Clear();
                Console.WriteLine("Введите номер нужного студента");
                Console.WriteLine("для выхода нажмите esc");
                for (int i = 0; i < DataSchool.Tables[classNum].Rows.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {DataSchool.Tables[classNum].Rows[i][0]}");
                }

                string line = Tool.InputWithEscape();
                if (line == null)
                    return;
                int.TryParse(line, out studNum);
                studNum--;
                if ((0 <= studNum) && (studNum < DataSchool.Tables[classNum].Rows.Count))
                    break;
                Tool.Msg("Не верный ввод!");
            }

            var Student = new InterfaceStudent(DataSchool.Tables[classNum].Rows[studNum]);  //Вход
            Student.Print();
        }

        /// <summary>
        /// Стартовое меню
        /// </summary>
        public void Begin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите роль");
                Console.WriteLine("1. Директор");
                Console.WriteLine("2. Классный руководитель");
                Console.WriteLine("3. Учитель");
                Console.WriteLine("4. Ученик");
                Console.WriteLine("esc Выход");
                Console.WriteLine("\nДля выбора, нажмите нужную цифру на клавиатуре");

                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        Director();
                        break;

                    case (ConsoleKey.D2):
                        ClassTeacher();
                        break;

                    case (ConsoleKey.D3):
                        Teacher();
                        break;

                    case (ConsoleKey.D4):
                        Student();
                        break;

                    case (ConsoleKey.Escape):
                        Console.Clear();
                        Console.WriteLine("Для подтверждения выхода из программы нажмите enter");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            return;
                        }
                        break;

                    default:
                        Tool.Msg("Нет такой команды");
                        break;
                }
            }
        }
    }
}
