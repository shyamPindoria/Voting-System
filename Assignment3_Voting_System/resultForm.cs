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
    public partial class ResultForm : Form
    {

        Database resultsDatabse;


        public ResultForm(Database database)
        {
            InitializeComponent();
            this.resultsDatabse = database;
            this.resultGridView.DataSource = resultsDatabse.table;

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            //Stores the string to be exported as a csv file
            StringBuilder csv = new StringBuilder();

            //First line containing headers of the columns
            String headers = "\"Round\",";

            for (int i = 0; i < this.resultsDatabse.getColumnCount(); i++)
            {
                headers += "\"" + this.resultsDatabse.getColumn(i) + "\"";
                if(i != this.resultsDatabse.getColumnCount() - 1)
                {
                    headers += ",";
                }
            }

            //Add the line to the string
            csv.AppendLine(headers);

            for (int i = 0; i < this.resultsDatabse.getRowCount(); i++)
            {
                String[] round = this.resultsDatabse.getRow(i);
                String line = "" + (i + 1) + ",";
                for (int j = 0; j < round.Length; j++)
                {
                    line += round[j];
                    if (j != round.Length - 1)
                    {
                        line += ",";
                    }
                }
                line += "\n";
                csv.Append(line);
            }

            //Show a save file dialog to allow the user to select a location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".csv"; //Default extension of the file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                //Write the csv file to the path selected by the user
                File.WriteAllText(Path.GetFullPath(filename), csv.ToString());
            }
        }
    }
}
