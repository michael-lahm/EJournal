using System;
using System.Data;

namespace EJournal
{
    internal class School
    {
        public DataSet DataSchool { get; }
        internal School()
        {
            DataSchool = new DataSet();
        }
    }
}
