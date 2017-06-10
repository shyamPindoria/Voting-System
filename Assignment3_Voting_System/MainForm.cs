using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Assignment3_Voting_System
{
    public partial class MainForm : Form
    {

        //Table Databases
        Database votesDatabase;
        Database preferencesDatabase;
        Database resultsDatabase;

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            this.votesDatabase = new Database();
            this.preferencesDatabase = new Database();
            this.resultsDatabase = new Database();
            this.preferencesDatabase.addColumns(new string[] { "Candidates", "Votes" });
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
                    validateTable();
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

        #region Validate Table

        public void validateTable()
        {
            for (int i = 0; i < this.votesGridView.Rows.Count - 1; i++)
            {
                string[] row = this.votesDatabase.getRow(i);
                if (!votesDatabase.isValid(row))
                {
                    this.votesGridView.Rows[i].HeaderCell.Style.BackColor = Color.Red;
                }
                else
                {
                    this.votesGridView.Rows[i].HeaderCell.Style.BackColor = SystemColors.Control;
                }
            }
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

        #region Quit Application

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void countButton_Click(object sender, EventArgs e)
        {


            String[] resultsColumns = new string[this.preferencesDatabase.getRowCount()];   // to get columns of result 
            String[] resultsRow = new string[this.preferencesDatabase.getRowCount()];


            this.resultsDatabase.addColumns(resultsColumns);






            // calculation starts from here
            Boolean isTied = false;
            Candidate winner = null;
            do
            {

                List<Candidate> candidates = new List<Candidate>();
                for (int i = 0; i < this.preferencesDatabase.getRowCount(); i++)
                {
                    String name = this.preferencesDatabase.getRow(i)[0];
                    int votes = int.Parse(this.preferencesDatabase.getRow(i)[1]);
                    candidates.Add(new Candidate(name, votes));

                    // create header for the result database
                    resultsColumns[i] = name;
                    // create first raw by copying all items
                    resultsRow[i] = votes.ToString();
               
                }
                this.resultsDatabase.addRow(resultsRow);

                if (candidates.Count!=0){
                    winner = countVotes(candidates, isTied);
                }
                else
                {
                    break;
                }


            } while (winner == null && isTied == false);


            ResultForm resultsForm = new ResultForm(this.resultsDatabase);
            resultsForm.ShowDialog();

        }




        private Candidate countVotes(List<Candidate> candidates, bool isTied)
        {
            String[] resultsRow = resultsDatabase.getRow(0);

            Candidate winner = null;
            isTied = false;


            Candidate candidatWithMaxVotes = candidates.Max();


            ///////////////Winner
            if (candidatWithMaxVotes.votes > this.votesDatabase.getRowCount() / 2)
            {
                winner = candidatWithMaxVotes;
                int indexOfWinner = candidates.IndexOf(winner);


                // set everone else as precued 
                for (int i = 0; i < resultsRow.Length; i++)
                {
                    if (i != indexOfWinner)
                    {
                        resultsRow[i] = "P";
                    }
                }

                Console.WriteLine("WINNER FOUND: " + candidatWithMaxVotes.name);
            }



            ///////////////////////////Tie
            int votes = candidates[0].votes;    // get the votes of one of the candidates
            int votesCount = 0; // counts the candidates that have same number of votes
            foreach (Candidate candidate in candidates)
            {
                if (candidate.votes == votes)
                {
                    votesCount++;
                }
            }
            if (votesCount == candidates.Count)
            {
                isTied = true;
            }



            //////////////////////////Min- Preclude   
            Candidate candidateToPreclude = candidates.Min();   // min needs to be precluded
            int count = 0;  // counts total number of candidates with lowest votes 
            List<Candidate> allCandidatesWithLowest = new List<Candidate>();

            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].votes == candidateToPreclude.votes)
                {
                    allCandidatesWithLowest.Add(candidates[i]);
                    count++;
                }
            }

            if (count > 1)
            {
                // update the candidat to preclude when there is more than one people with lowest votes
                Random rand = new Random();
                int index = rand.Next(0, allCandidatesWithLowest.Count - 1);
                candidateToPreclude = allCandidatesWithLowest[index];
            }

            int indexToRemove = this.preferencesDatabase.indexOf(candidateToPreclude.name);

            // remove the candidate and distribute the votes
            if (indexToRemove != -1)
            {
                distributeVotes(indexToRemove);
                this.preferencesDatabase.removeRow(indexToRemove);

                // need to remove the row 
                //this.preferencesDatabase.removeRow(new string[] { candidateToPreclude.name, candidateToPreclude.votes.ToString() });
                

            }


            return winner;


        }






        private void distributeVotes(int candidate)
        {
            //Still need to calculate for 2nd, 3rd, 4th etc.
            //Example:  a   b   c   d
            //          1   2   3   4
            //          4   1   3   2
            //          4   3   2   1
            //          4   2   1   3

            // first run - b gets removed randomly and it vote gets distributed to d
            // d now has 2 votes
            // Second run - a gets removed randomly - it had one vote which was to be transfered to b
            // but since b is deleted, its 3rd preference should be checked which is c so c now has 2 votes
            // both c and d have 2 - 2 votes (tie)

            int pref;
            for (int i = 0; i < this.votesDatabase.getRowCount(); i++)
            {
                pref = 1;
                string[] row = this.votesDatabase.getRow(i);
                if (row[candidate].Equals(pref.ToString()))
                {
                    
                    for (int j = 0; j < row.Length; j++)
                    {
                       
                        if (row[j].Equals((pref + 1).ToString()))
                        {
                            String candidateName = this.votesDatabase.getColumn(j);
                            int indexOfCandidate = this.preferencesDatabase.indexOf(candidateName);
                            if (indexOfCandidate != -1)
                            {
                                int votes = int.Parse(this.preferencesDatabase.getRow(indexOfCandidate)[1]);
                                votes += 1;
                                this.preferencesDatabase.updateVotes(indexOfCandidate, votes);
                                Console.WriteLine("Vote at " + (i + 1) + " transfered to: " + this.preferencesDatabase.getRow(indexOfCandidate)[0]);
                            }
                            else
                            {
                                pref += 1;
                            }

                            
                        }
                    }
                }
            }
        }
    }
}
