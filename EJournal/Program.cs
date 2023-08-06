using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace EJournal
{
    internal static class Program
    {
        
        static void Main(string[] args)
        {
            DataSet CSchool = new DataSet();

            var CClass = new Class(CSchool, "11А");
            CClass.CreateSample();
            CClass = new Class(CSchool, "11Б");
            CClass.CreateSample();
            CClass = new Class(CSchool, "11В");
            CClass.CreateSample();

            var menu = new StartMenu(CSchool);
            menu.Begin();
        }
    }
}
