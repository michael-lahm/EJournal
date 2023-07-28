using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EJournal
{
    internal class City
    {
        private List<School> school = new List<School>();

        public bool NewSchool(string name, int number)
        {
            for (int i = 0; i < school.Count(); i++)
            {
                if (school[i].Name == name || school[i].Number == number)
                {
                    Tool.Msg("Школа с указанными данными уже существует");
                    return false;
                }
            }
            school.Add(new School { Name = name, Number = number }) ;
            return true;
        }

        public bool DestroySchool(int number)
        {
            for(int i = 0; i < school.Count; i++)
            {
                if (school[i].Number == number)
                {
                    school.RemoveAt(i);
                    return true;
                }
            }

            Tool.Msg("Школа с указанным номером не найдена");
            return false;
        }

        public bool PrintSchool(int number)
        {
            for (int i = 0; i < school.Count; i++)
            {
                if (school[i].Number == number)
                {
                    Console.Clear();
                    Console.WriteLine("Название:" + school[i].Name);
                    Console.WriteLine("Номер:" + school[i].Number + '\n');
                    return true;
                }
            }

            Tool.Msg("Школа с указанным номером не найдена");
            return false;
        }

        public void PrintAllSchool()
        {
            Console.Clear();
            for (int i = 0; i < school.Count; i++)
            {
                Console.WriteLine("Название:" + school[i].Name);
                Console.WriteLine("Номер:" + school[i].Number + '\n');
            }
        }
    }
}
