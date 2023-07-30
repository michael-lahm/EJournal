using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EJournal
{
    internal static class Handler
    {
        static public DataTable Create(DataTable dataTable)
        {
            dataTable.Columns.Add(new DataColumn("Имя", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Русский", typeof(List<byte>)));
            dataTable.Columns.Add(new DataColumn("Математика", typeof(List<byte>)));
            dataTable.Columns.Add(new DataColumn("Физика", typeof(List<byte>)));
            dataTable.Columns.Add(new DataColumn("Информатика", typeof(List<byte>)));

            DataRow row = dataTable.NewRow();
            row["Имя"] = "Вася";
            row["Русский"] = new List<byte>{ 5, 2, 4};
            row["Математика"] = new List<byte> { 4, 2, 5 };
            row["Физика"] = new List<byte> { 5, 5, 5 };
            row["Информатика"] = new List<byte> { 2, 2, 2 };
            dataTable.Rows.Add(row);

            return dataTable;
        }


    }
}
