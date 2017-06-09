using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3_Voting_System
{
    public partial class MainForm : Form
    {
        //Table Databases
        Database votesDatabase;
        Database preferencesDatabase;

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            this.votesDatabase = new Database();
            this.preferencesDatabase = new Database();
            this.preferencesDatabase.addColumns(new string[]{ "Candidates", "Votes" });
            this.firstPreferencesGridView.DataSource = this.preferencesDatabase.table;
        }

        #endregion

        #region Importing and Exporting Files

        private void importMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //Allow the user to import csv files only
            dialog.Filter = "CSV Files|*.CSV";
            //Allow the user to select a file
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName; //Filename
                //Check if the file exists
                if (File.Exists(filename))
                {
                    FileStream stream = File.OpenRead(filename);
                    StreamReader reader = new StreamReader(stream); //Readed to read lines from the file

                    string[] headers = reader.ReadLine().Split(','); //The first line which contains the headers of the columns
                    this.votesDatabase = new Database();
                    string[] columns = new string[headers.Length];

                    for (int i = 0; i < headers.Length; i++)
                    {
                        columns[i] = headers[i].Trim('\"');
                    }

                    this.votesDatabase.addColumns(columns);

                    //Read lines until the file comes to an end
                    while (!reader.EndOfStream)
                    {
                        // Create and populate the datatable
                        string[] row = reader.ReadLine().Split(',');
                        this.votesDatabase.addRow(row);
                    }

                    //Set the data source
                    votesGridView.DataSource = this.votesDatabase.table;
                    votesGridView.AutoResizeColumns();
                    this.votesDatabase.getCandidates(); 
                }
            }
        }

        private void exportMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion
 
        #region Add Candidate

        private void addCandidate_Click(object sender, EventArgs e)
        {
            this.votesDatabase.addColumn(this.candidateTextBox.Text.TrimEnd());
            votesGridView.DataSource = this.votesDatabase.table;
            votesGridView.AutoResizeColumns();
            this.candidateTextBox.Text = "";

        }

        private void candidateTextBox_TextChanged(object sender, EventArgs e)
        {
            this.candidateTextBox.Text = this.candidateTextBox.Text.TrimStart();
            if (!this.candidateTextBox.Text.Equals(""))
            {
                this.addCandidate.Enabled = true;
            }
            else
            {
                this.addCandidate.Enabled = false;
            }
        }

        #endregion

        #region Update First Preferences Table

        private void votesGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            calculateFirstPreferences();
            validateTable();
        }

        private void calculateFirstPreferences()
        {
            preferencesDatabase.table.Clear();
            int[] firstCounts = new int[votesDatabase.getColumnCount()];
            for (int i = 0; i < votesDatabase.getRowCount(); i++)
            {
                string[] currentRow = votesDatabase.getRow(i);

                if (votesDatabase.isValid(currentRow))
                {
                    for (int j = 0; j < currentRow.Length; j++)
                    {
                        if (currentRow[j].Equals("1"))
                        {
                            firstCounts[j]++;
                        }
                    }
                }
            }
            string[] columns = votesDatabase.getCandidates();
            for (int i = 0; i < firstCounts.Length; i++)
            {
                preferencesDatabase.addRow(new string[] { columns[i], firstCounts[i].ToString() });
            }
        }

        #endregion

        public void validateTable()
        {
            for (int i = 0; i < this.votesGridView.Rows.Count - 1; i++)
            {
                string[] row = this.votesDatabase.getRow(i);
                if(!votesDatabase.isValid(row)){
                    this.votesGridView.Rows[i].HeaderCell.Style.BackColor = Color.Red;
                }
                else
                {
                    this.votesGridView.Rows[i].HeaderCell.Style.BackColor = SystemColors.Control;
                }
            }
        }

        #region Quit Application

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Update Row Headers

        private void updateRowHeaders()
        {
            for (int i = 0; i < this.votesGridView.Rows.Count - 1; i++)
            {
                this.votesGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            this.votesGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void votesGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateRowHeaders();
        }

        private void votesGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateRowHeaders();
        }

        #endregion

        private void countButton_Click(object sender, EventArgs e)
        {
            List<int> count = new List<int>();
            
            for (int i = 0; i < this.preferencesDatabase.getRowCount(); i++)
            {
                count.Add(int.Parse(this.preferencesDatabase.getRow(i)[1]));
            }

            

        }
        /// <summary>
        /// ///////////////////////////////////
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<int> countVotes(List<int> count)
        {
            int winner = -1;
            bool tie = true;
            int min = count.Min();
            List<int> minCandidates = new List<int>();
            
            for (int i = 0; i < count.Count; i++)
            {
                if (count[i] > this.votesDatabase.getRowCount() / 2)
                {
                    winner = i;
                }
                else if (i != 0 && count[i] != count[i - 1])
                {
                    tie = false;
                }
                else if (count[i] == min)
                {
                    minCandidates.Add(i);
                }
            }

            if (minCandidates.Count > 1)
            {
                int index = new Random(minCandidates.Count).Next();
                distributeVotes(minCandidates[index]);
            }
            
        }

        private void distributeVotes(int candidate)
        {
            for (int i = 0; i < this.votesDatabase.getRowCount(); i++)
            {
                string[] row = this.votesDatabase.getRow(i);
                if (row[candidate].Equals("1"))
                {
                    for (int j = 0; j < row.Length; j++)
                    {
                        if (row[j].Equals("2"))
                        {
                            int votes= int.Parse(this.preferencesDatabase.getRow(j)[1]);
                            votes+=1;
                            this.preferencesDatabase.updateVotes(j, votes);
                        }
                    }
                }
            }
        }
    }
}
