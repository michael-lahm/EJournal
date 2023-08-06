using System;
using System.Collections.Generic;
using System.Data;

namespace EJournal
{
    internal class Class
    {
        public DataTable DataClass { get;}
        internal Class(DataSet School, string Name)
        {
            DataClass = new DataTable(Name);
            School.Tables.Add(DataClass);
        }

        /// <summary>
        /// Создание класса со случайными учениками, предметами и оценками
        /// </summary>
        internal void CreateSample()
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());

            string[] firstname = new string[] { "Вася", "Петя", "Андрей", "Миша", "Максим", "Ваня", "Костя", "Матвей", "Саша", "Кеша" };
            string[] subject = new string[] { "Русский", "Математика", "Информатика", "Физика", "Химия", "Биология", "Литература", "История", "Обществознание", "Иностранный" };
            
            DataColumn[] Name = new DataColumn[] { new DataColumn("Имя", typeof(string)) };
            DataClass.Columns.Add(Name[0]);
            DataClass.PrimaryKey = Name;

            for (int i = 0; i < subject.Length; i++)
            {
                if(rand.Next(0, 10) > DataClass.Columns.Count)
                    DataClass.Columns.Add(subject[i], typeof(List<byte>));
            }

            for (int i = 0; i < firstname.Length; i++)
            {
                if (rand.Next(0, 10) > DataClass.Rows.Count)
                {
                    DataRow student = DataClass.NewRow();
                    student["Имя"] = firstname[i];

                    for (int a = 1; a < DataClass.Columns.Count; a++)
                    {
                        var estimates = new List<byte>() {};
                        int quantity = rand.Next(3, 10);
                        for (int estimat = 0; estimat < quantity; estimat++)
                            estimates.Add((byte)rand.Next(2, 6));
                        student[DataClass.Columns[a].ColumnName] = estimates;
                    }

                    DataClass.Rows.Add(student);
                }
            }

            
        }
    }
}
