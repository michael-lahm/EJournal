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
            DataSet ds = new DataSet();
            Handler dataTable = new Handler();
            dataTable.CreateSample();
            var classteacher = new InterfaceClassteacher(dataTable.DataClass);
            classteacher.Begin();
        }
    }
}
