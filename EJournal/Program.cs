using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace EJournal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = new DataTable();
            dataTable = Handler.Create(dataTable);
            InterfaceClassteacher.PrintAll(dataTable);
        }
    }
}
