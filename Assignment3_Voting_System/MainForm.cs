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
        Database tempPreferences;
        Database tempVotes;

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            this.votesDatabase = new Database();
            this.preferencesDatabase = new Database();
            this.resultsDatabase = new Database();
            this.tempPreferences = new Database();
            this.tempVotes = new Database();
            this.preferencesDatabase.addColumns(new string[] { "Candidates", "Votes" });
            this.tempPreferences.addColumns(new string[] { "Candidates", "Votes" });
            this.firstPreferencesGridView.DataSource = this.preferencesDatabase.table;
        }

        #endregion

        #region Importing Files

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
                    try
                    {
                        FileStream stream = File.OpenRead(filename);
                        StreamReader reader = new StreamReader(stream); //Readed to read lines from the file

                        this.votesDatabase = new Database();

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
                        validateTable();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Oops! Something went wrong while opening the file.\nPlease check the format of the file.", "Error!");
                    }
                }
            }
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
            this.preferencesDatabase.calculateFirstPreferences(this.votesDatabase);
            validateTable();
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
            countClick();
            /*
            List<Candidate> candidates = new List<Candidate>();
            this.tempPreferences = new Database(this.preferencesDatabase);
            this.tempVotes = new Database(this.votesDatabase);
            
            String[] resultsColumns = new string[this.tempPreferences.getRowCount()];   // to get columns of result 
            String[] resultsRow = new string[this.tempPreferences.getRowCount()];
            
            
            for (int i = 0; i < this.tempPreferences.getRowCount(); i++)
            {

                String name = this.tempPreferences.getRow(i)[0];
                int votes = int.Parse(this.tempPreferences.getRow(i)[1]);


                candidates.Add(new Candidate(name, votes));
                // create header for the result database
                resultsColumns[i] = name;
                // create first row by copying all items
                resultsRow[i] = votes.ToString();


            }

            this.resultsDatabase.addColumns(resultsColumns);
            this.resultsDatabase.addRow(resultsRow);





            // calculation starts from here
            Boolean isTied = false;
            Candidate winner = null;
            do
            {

                // update candidates 
                if (candidates.Count != 0)
                {
                    winner = countVotes(candidates, isTied);


                    candidates.Clear();
                    candidates = new List<Candidate>();

                    for (int i = 0; i < this.tempPreferences.getRowCount(); i++)
                    {

                        String name = this.tempPreferences.getRow(i)[0];
                        int votes = int.Parse(this.tempPreferences.getRow(i)[1]);

                        if (name != "" && votes != -1)
                        {

                            candidates.Add(new Candidate(name, votes));
                            // create header for the result database
                            resultsColumns[i] = name;
                            // create first row by copying all items
                            resultsRow[i] = votes.ToString();
                        }
                        else
                        {
                            resultsRow[i] = "P";
                        }
                    }

                    this.resultsDatabase.addRow(resultsRow);
                }
                else
                {
                    break;
                }


            } while (winner == null && isTied == false);

            */
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

                /*
                // set everone else as precued 
                for (int i = 0; i < resultsRow.Length; i++)
                {
                    if (i != indexOfWinner)
                    {
                        resultsRow[i] = "P";
                    }
                }
                */

                Console.WriteLine("WINNER FOUND: " + candidatWithMaxVotes.name);
            }



            ///////////////////////////Tie
            int votes = candidates.Max().votes;    // get the votes of one of the candidates
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
                //distributeVotes(indexToRemove);
                this.preferencesDatabase.updateCandidates(indexToRemove, "");
                this.preferencesDatabase.updateVotes(indexToRemove, -1);    // when the candidate is precluded set his vots to be -1 and name to be empty in the database
                // need to remove the row 
                //this.preferencesDatabase.removeRow(new string[] { candidateToPreclude.name, candidateToPreclude.votes.ToString() });


            }
            return winner;
        }




        private void countClick()
        {
            this.tempVotes = new Database(this.votesDatabase);
            this.tempPreferences = new Database();
            this.tempPreferences.addColumns(new string[] { "Candidates", "Votes" });
            this.tempPreferences.calculateFirstPreferences(this.tempVotes);
            this.resultsDatabase = new Database();
            this.resultsDatabase.addColumns(this.tempVotes.getCandidates());
            String[] initialVotes = new String[this.tempPreferences.getRowCount()];
            for (int i = 0; i < this.tempPreferences.getRowCount(); i++)
            {
                initialVotes[i] = this.tempPreferences.getRow(i)[1];
            }
            this.resultsDatabase.addRow(initialVotes);

            List<int> precluded = new List<int>();

            bool winnerFound = false;
            bool tie = false;
            bool votesCalculated = false;

            while (!votesCalculated)
            {
                tie = true;
                int minVotes = int.Parse(this.tempPreferences.getRow(0)[1]);

                String[] votes = resultsDatabase.getRow(resultsDatabase.getRowCount() - 1);

                for (int i = 0; i < votes.Length; i++)
                {
                    if (!votes[i].Equals("P"))
                    {
                        int vote = int.Parse(votes[i]);
                        if (vote > this.tempPreferences.getTotalVotes() / 2)
                        {
                            winnerFound = true;
                            Console.WriteLine("Winner Found: " + this.tempPreferences.getRow(i)[0]);
                        }
                        else
                        {
                            for (int j = 0; j < votes.Length && tie; j++)
                            {
                                if (!votes[j].Equals("P") && vote != int.Parse(votes[j]))
                                {
                                    tie = false;
                                }
                            }
                        }
                        if (vote < minVotes)
                        {
                            minVotes = vote;
                        }
                    }
                }

                List<int> minCandidates = new List<int>();
                if (!winnerFound && !tie)
                {
                    for (int i = 0; i < votes.Length; i++)
                    {
                        if (!votes[i].Equals("P"))
                        {
                            int vote = int.Parse(votes[i]);
                            if (minVotes == vote)
                            {
                                minCandidates.Add(i);
                            }
                        }
                    }
                    Random rand = new Random();
                    int index = rand.Next(0, minCandidates.Count);
                    precluded.Add(minCandidates[index]);
                    this.resultsDatabase.addRow(distributeVotes(minCandidates[index], precluded));
                }
                Console.WriteLine("Tie: " + tie + "\nWinner: " + winnerFound);
                if(winnerFound || tie)
                {
                    votesCalculated = true;
                }
            }

        }

        private String[] distributeVotes(int candidate, List<int> precluded)
        {
            for (int i = 0; i < this.tempVotes.getRowCount(); i++)
            {
                String[] row = this.tempVotes.getRow(i);
                if (row[candidate].Equals("1"))
                {
                    this.tempVotes.updatePreferences(i);
                }
            }
            

            this.tempPreferences.calculateFirstPreferences(this.tempVotes);

            String[] newRow = new String[this.tempVotes.getColumnCount()];

            for (int i = 0; i < newRow.Length; i++)
            {
                if (!precluded.Contains(i))
                {
                    newRow[i] = this.tempPreferences.getRow(i)[1];
                }
                else
                {
                    newRow[i] = "P";
                }
                Console.Write(newRow[i]);
            }
            Console.WriteLine();
            return newRow;








            /*
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
                                if (this.preferencesDatabase.getRow(indexOfCandidate)[1] != "-1")
                                {
                                    int votes = int.Parse(this.preferencesDatabase.getRow(indexOfCandidate)[1]);
                                    votes += 1;
                                    this.preferencesDatabase.updateVotes(indexOfCandidate, votes);
                                    Console.WriteLine("Vote at " + (i + 1) + " transfered to: " + this.preferencesDatabase.getRow(indexOfCandidate)[0]);
                                    break; // break when the votes are updated
                                }


                            }
                            else
                            {
                                pref += 1;
                                j = j - 1;
                            }



                        }
                    }
                }
            }*/
        }
    }
}
