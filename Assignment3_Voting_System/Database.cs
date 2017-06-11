using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Voting_System
{
    public class Database
    {
        public DataTable table { get; set; }

        public Database()
        {
            this.table = new DataTable();
        }

        /// <summary>
        /// Copy costructor
        /// </summary>
        /// <param name="d">Database to copy from</param>
        public Database(Database d)
        {
            this.table = new DataTable();
            this.addColumns(d.getCandidates());
            for (int i = 0; i < d.getRowCount(); i++)
            {
                this.addRow(d.getRow(i));
            }
        }

        /// <summary>
        /// Add a single column
        /// </summary>
        /// <param name="column">Column to add</param>
        public void addColumn(string column)
        {
            this.table.Columns.Add(column);
        }

        /// <summary>
        /// Add a list of columns to the table
        /// </summary>
        /// <param name="columns">Columns to add</param>
        public void addColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                this.addColumn(column);
            }
        }

        /// <summary>
        /// Add a row the table
        /// </summary>
        /// <param name="row"></param>
        public void addRow(string[] row)
        {
            this.table.Rows.Add(row);
        }

        /// <summary>
        /// Delete a row from the table
        /// </summary>
        /// <param name="index"></param>
        public void removeRow(int index)
        {
            if (index >= 0) {
                this.table.Rows.RemoveAt(index);
            }
            
        }

        /// <summary>
        /// Return row at a given index in a string []
        /// </summary>
        /// <param name="index">Index of the row</param>
        /// <returns>String array</returns>
        public string[] getRow(int index)
        {
            try
            {
                //Row is stored as an object initially
                Object[] obj = this.table.Rows[index].ItemArray;

                string[] row = new string[obj.Length];
                //Loop through the row
                for (int i = 0; i < row.Length; i++)
                {
                    //Cast the object to strings
                    if (!obj[i].ToString().Equals(""))
                    {
                        row[i] = obj[i].ToString();
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
                //Return a blank array incase something goes wrong
                return new string[0];

            }
        }

        /// <summary>
        /// Updates the preferences of a given vote
        /// Preference 2 becomes 1, 3 becomes 2 etc.
        /// Preference 1 becomes infinity
        /// </summary>
        /// <param name="rowIndex">Row to update</param>
        public void updatePreferences(int rowIndex, List<int> precluded)
        {
            //Loop through the preferences in the row
            for (int i = 0; i < this.table.Rows[rowIndex].ItemArray.Length; i++)
            {
                int pref = int.Parse(this.table.Rows[rowIndex][i].ToString());
                //Decrement the preference
                this.table.Rows[rowIndex][i] = pref - 1;
                if (int.Parse(this.table.Rows[rowIndex][i].ToString()) == 0)
                {
                    //If the preference was 1, set it to infinity
                    this.table.Rows[rowIndex][i] = int.MaxValue;
                }
                if (this.table.Rows[rowIndex][i].ToString().Equals("1") && precluded.Contains(i))
                {
                    updatePreferences(rowIndex, precluded);
                }
            }
        }

        /// <summary>
        /// Check if the votes in a row are valid
        /// </summary>
        /// <param name="row">Row to check</param>
        /// <returns>true if valid</returns>
        public Boolean isValid(string[] row)
        {
            if (row.Length == getCandidates().Length)
            {
                for (int i = 1; i <= row.Length; i++)
                {
                    if (!row.Contains(i.ToString()))
                    {
                        if (!row.Contains(int.MaxValue.ToString()))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the number of columns in the table
        /// </summary>
        /// <returns></returns>
        public int getColumnCount()
        {
            return this.table.Columns.Count;
        }

        /// <summary>
        /// Returns the number of rows in the table
        /// </summary>
        /// <returns></returns>
        public int getRowCount()
        {
            return this.table.Rows.Count;
        }

        /// <summary>
        /// Returns the column at a specific index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string getColumn(int index)
        {
            return this.table.Columns[index].ToString();
        }

        /// <summary>
        /// Returns the column headers in a string[]
        /// </summary>
        /// <returns>String array</returns>
        public string[] getCandidates()
        {
            string[] headers = new string[this.getColumnCount()];
            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = this.table.Columns[i].ToString();
            }
            return headers;
        }

        /// <summary>
        /// Calculate the total number of first preferences
        /// </summary>
        /// <returns>Count of total votes</returns>
        public int getTotalVotes()
        {
            int count = 0;

            for (int i = 0; i < this.table.Rows.Count; i++)
            {
                count += int.Parse(this.getRow(i)[1]);
            }

            return count;
        }
        
        /// <summary>
        /// Calculate the first preferences
        /// </summary>
        /// <param name="votesDatabase">Database containing the votes</param>
        public void calculateFirstPreferences(Database votesDatabase)
        {
            //Clear any present values
            this.table.Rows.Clear();
            //First preferences count
            int[] firstCounts = new int[votesDatabase.getColumnCount()];
            for (int i = 0; i < votesDatabase.getRowCount(); i++)
            {
                //Current row in the loop
                string[] currentRow = votesDatabase.getRow(i);

                if (votesDatabase.isValid(currentRow))
                {
                    //Look for first preferences in the votes table
                    for (int j = 0; j < currentRow.Length; j++)
                    {
                        if (currentRow[j].Equals("1"))
                        {
                            //Increment the first preferences count
                            firstCounts[j]++;
                        }
                    }
                }
            }
            //Name of candidates
            string[] columns = votesDatabase.getCandidates();
            for (int i = 0; i < firstCounts.Length; i++)
            {
                //Populate the preferences table
                this.addRow(new string[] { columns[i], firstCounts[i].ToString() });
            }
        }

    }
}
