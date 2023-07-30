using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EJournal
{
    internal class Handler
    {
        public DataTable DataClass { get;}
        internal Handler()
        {
            DataClass = new DataTable();
        }

        internal void CreateSample()
        {
            DataClass.Columns.Add(new DataColumn("Имя", typeof(string)));
            DataClass.Columns.Add(new DataColumn("Русский", typeof(List<byte>)));
            DataClass.Columns.Add(new DataColumn("Математика", typeof(List<byte>)));
            DataClass.Columns.Add(new DataColumn("Физика", typeof(List<byte>)));
            DataClass.Columns.Add(new DataColumn("Информатика", typeof(List<byte>)));
            
            DataRow row = DataClass.NewRow();
            row["Имя"] = "Вася";
            row["Русский"] = new List<byte> { 5, 2, 4 };
            row["Математика"] = new List<byte> { 4, 2, 5, 5 };
            row["Физика"] = new List<byte> { 5, 5, 5 };
            row["Информатика"] = new List<byte> { 2, 2 };
            DataClass.Rows.Add(row);
        }
    }
}
