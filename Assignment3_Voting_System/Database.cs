using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Voting_System
{
    class Database
    {
        public DataTable table { get; set; }

        public Database()
        {
            this.table = new DataTable();
        }

        public void addColumn(string column)
        {
            this.table.Columns.Add(column);
        }

        public void addColumns(DataColumn[] columns)
        {
            this.table.Columns.AddRange(columns);
        }

        public void addRow(string[] row)
        {
            this.table.Rows.Add(row);
        }
    }
}
