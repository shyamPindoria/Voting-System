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

        Database votesDatabase;
        Database preferencesDatabase;

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            this.votesDatabase = new Database();
            this.preferencesDatabase = new Database();
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
                    votesTable = new DataTable();
                    DataColumn[] columns = new DataColumn[headers.Length];

                    for (int i = 0; i < headers.Length; i++)
                    {
                        columns[i] = new DataColumn(headers[i].Trim('\"'));
                    }

                    votesTable.Columns.AddRange(columns);
                    //Read lines until the file comes to an end

                    while (!reader.EndOfStream)
                    {
                        // Create and populate the datatable
                        string[] row = reader.ReadLine().Split(',');
                        votesTable.Rows.Add(row);
                    }

                    //Set the data source
                    votesGridView.DataSource = votesTable;
                    votesGridView.AutoResizeColumns();
                }
            }
        }

        private void exportMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Quit Application

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void addCandidate_Click(object sender, EventArgs e)
        {
            votesTable.Columns.Add(this.candidateTextBox.Text);
            votesGridView.DataSource = votesTable;
            votesGridView.AutoResizeColumns();
            this.candidateTextBox.Text = "";

        }

        private void candidateTextBox_TextChanged(object sender, EventArgs e)
        {
            this.candidateTextBox.Text = this.candidateTextBox.Text.Trim();
            if (!this.candidateTextBox.Text.Equals(""))
            {
                this.addCandidate.Enabled = true;
            }
            else
            {
                this.addCandidate.Enabled = false;
            }
        }

        private void votesTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }


    }
}
