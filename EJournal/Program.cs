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
            Handler dataTable = new Handler();
            dataTable.CreateSample();
            InterfaceClassteacher.Begin(dataTable.DataClass);
        }
    }
}
