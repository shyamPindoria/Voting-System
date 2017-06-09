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

        public void addColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                this.addColumn(column);
            }
        }

        public void addRow(string[] row)
        {
            this.table.Rows.Add(row);
        }

        public string[] getRow(int index)
        {
            try
            {
                Object[] obj = this.table.Rows[index].ItemArray;
                String[] row = new String[obj.Length];

                for (int i = 0; i < row.Length; i++)
                {
                    if (!obj[i].ToString().Equals(""))
                    {
                        row[i] = (String)obj[i];
                    }
                    else
                    {
                        row[i] = "";
                    }
                }

                return row;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new string[0];

            }
        }

        public void updateVotes(int index, int value)
        {
            this.table.Rows[index][1] = value;
        }

        public Boolean isValid(string[] row)
        {
            if (row.Length == getCandidates().Length)
            {
                for (int i = 1; i <= row.Length; i++)
                {
                    if (!row.Contains(i.ToString()))
                    {
                        return false;
                    }

                }
                return true;
            }




            return false;
        }


        public int getColumnCount()
        {
            return this.table.Columns.Count;
        }

        public int getRowCount()
        {
            return this.table.Rows.Count;
        }



        public string[] getCandidates()
        {
            string[] headers = new string[this.getColumnCount()];
            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = this.table.Columns[i].ToString();
            }
            return headers;
        }

    }
}
