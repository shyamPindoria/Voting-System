using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Assignment3_Voting_System
{
    public partial class MainForm : Form
    {

        //Table Databases
        Database votesDatabase;
        Database preferencesDatabase;
        Database resultsDatabase;
        Database tempVotes; //working copy of votesDatabase
        Database tempPreferences; //working copy of preferencesDatabase
        
        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            this.votesDatabase = new Database();
            this.preferencesDatabase = new Database();
            this.resultsDatabase = new Database();
            this.tempPreferences = new Database();
            this.tempVotes = new Database();
            //Pre-add columns to both the preferences databases
            this.preferencesDatabase.addColumns(new string[] { "Candidates", "Votes" });
            this.tempPreferences.addColumns(new string[] { "Candidates", "Votes" });
            //Populate the preferences table
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
            //Add a new column to the data grid view
            this.votesDatabase.addColumn(this.candidateTextBox.Text.TrimEnd());
            //Set the source of the grid view
            votesGridView.DataSource = this.votesDatabase.table;
            //Clear the candidate box
            this.candidateTextBox.Text = "";

        }

        private void candidateTextBox_TextChanged(object sender, EventArgs e)
        {
            //Don't allow the user to enter a space at the begining
            this.candidateTextBox.Text = this.candidateTextBox.Text.TrimStart();
            //Enable the add button only if there is some text in the text box
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
            //Update the preferences table every time the current cell changes
            this.preferencesDatabase.calculateFirstPreferences(this.votesDatabase);
            //Validate the votes table
            validateTable();
        }


        #endregion

        #region Validate Table

        /// <summary>
        /// Validates the votes table and shows the rows which contain errors to the user
        /// </summary>
        public void validateTable()
        {
            //Loop through the rows
            for (int i = 0; i < this.votesGridView.Rows.Count - 1; i++)
            {
                string[] row = this.votesDatabase.getRow(i);
                //Check if a row is valid
                if (!votesDatabase.isValid(row))
                {
                    //Colour red if votes in the row are invalid
                    this.votesGridView.Rows[i].HeaderCell.Style.BackColor = Color.Red;
                }
                else
                {
                    //Reset to default colour if row is valid
                    this.votesGridView.Rows[i].HeaderCell.Style.BackColor = SystemColors.Control;
                }
            }
        }

        #endregion

        #region Update Row Headers

        /// <summary>
        /// Displays the row indexes in the row headers
        /// </summary>
        private void updateRowHeaders()
        {
            //Loop over the records
            for (int i = 0; i < this.votesGridView.Rows.Count - 1; i++)
            {
                //Display the index on the row headers
                this.votesGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            this.votesGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void votesGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Update row header every time a row is added
            updateRowHeaders();
            //Enable the count button when rows are added
            if (this.votesGridView.RowCount > 1)
            {
                countButton.Enabled = true;
            }
            else
            {
                countButton.Enabled = false;
            }
        }

        private void votesGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //Update row headers every time a row is removed
            updateRowHeaders();
            //Disable the count button when there is no data
            if (this.votesGridView.RowCount > 1)
            {
                countButton.Enabled = true;
            }
            else
            {
                countButton.Enabled = false;
            }
        }

        #endregion

        #region Count Votes

        private void countButton_Click(object sender, EventArgs e)
        {
            //Prepare the databases for use
            this.tempVotes = new Database(this.votesDatabase);
            this.tempPreferences = new Database();
            this.tempPreferences.addColumns(new string[] { "Candidates", "Votes" });
            this.tempPreferences.calculateFirstPreferences(this.tempVotes);
            this.resultsDatabase = new Database();
            //Add headers to the results database
            this.resultsDatabase.addColumns(this.tempVotes.getCandidates());
            //Initial votes without any calculation done
            String[] initialVotes = new String[this.tempPreferences.getRowCount()];
            for (int i = 0; i < this.tempPreferences.getRowCount(); i++)
            {
                initialVotes[i] = this.tempPreferences.getRow(i)[1];
            }
            //Add the initial votes to the results database
            this.resultsDatabase.addRow(initialVotes);

            //Contains candidates that are precluded
            List<int> precluded = new List<int>();
            //Index of the winner
            int winner = 0;
            bool winnerFound = false; //True if winner is found
            bool tie = false; //True if there is a tie
            //Loop control
            bool votesCalculated = false; //True if a winner is found or their is a tie

            //Loop while votes calculation is not finished
            while (!votesCalculated)
            {
                //Set tie to true initially
                tie = true;
                //Set the minimum vote infinity
                int minVotes = int.MaxValue;

                //Get the votes count from the last round in the results table
                String[] votes = resultsDatabase.getRow(resultsDatabase.getRowCount() - 1);

                //Loop over the votes
                for (int i = 0; i < votes.Length; i++)
                {
                    //Process the votes of participating candidates only
                    if (!votes[i].Equals("P"))
                    {
                        int vote = int.Parse(votes[i]);
                        //Check if there is a winner
                        if (vote > this.tempPreferences.getTotalVotes() / 2)
                        {
                            winnerFound = true;
                            winner = i;
                            Console.WriteLine("Winner Found: " + this.tempPreferences.getRow(i)[0]);
                        }
                        else
                        {
                            //Check if there is a tie
                            for (int j = 0; j < votes.Length && tie; j++)
                            {
                                //If votes are different, there is no tie
                                if (!votes[j].Equals("P") && vote != int.Parse(votes[j]))
                                {
                                    tie = false;
                                }
                            }
                        }
                        //Find the minimum vote
                        if (vote < minVotes)
                        {
                            minVotes = vote;
                        }
                    }
                }

                //Do the calculation if there is no winner or tie
                if (!winnerFound && !tie)
                {
                    //List containing candidates with the minimum votes
                    List<int> minCandidates = new List<int>();
                    //Look for min candidates
                    for (int i = 0; i < votes.Length; i++)
                    {
                        if (!votes[i].Equals("P"))
                        {
                            int vote = int.Parse(votes[i]);
                            if (minVotes == vote)
                            {
                                //Add candidates with the lowest vote to minCandidates
                                minCandidates.Add(i);
                            }
                        }
                    }
                    //Randomly choose an candidate to preclude
                    Random rand = new Random();
                    int index = rand.Next(0, minCandidates.Count);
                    precluded.Add(minCandidates[index]);
                    this.resultsDatabase.addRow(distributeVotes(minCandidates[index], precluded));
                }
                //Check if votes still need to be processed
                if (winnerFound || tie)
                {
                    votesCalculated = true;
                }
            }
            //Show the results form once the results have been calculated
            ResultForm resultsForm = new ResultForm(this.resultsDatabase, winner, tie);
            resultsForm.ShowDialog();
        }

        /// <summary>
        /// Distribute the votes of a precluded candidate
        /// </summary>
        /// <param name="candidate">Candidate whose votes are to be distributed</param>
        /// <param name="precluded">List of all the precluded candidates</param>
        /// <returns>String array containing the new preference counts</returns>
        private String[] distributeVotes(int candidate, List<int> precluded)
        {
            //Loop over the votes
            for (int i = 0; i < this.tempVotes.getRowCount(); i++)
            {
                String[] row = this.tempVotes.getRow(i);
                //Find the first preferences of the precluded candidate
                if (row[candidate].Equals("1"))
                {
                    //Update the votes in that row
                    this.tempVotes.updatePreferences(i);
                }
            }

            //Recalculate the First preferences
            this.tempPreferences.calculateFirstPreferences(this.tempVotes);

            //Row to be returned containing the updated preferences
            String[] newRow = new String[this.tempVotes.getColumnCount()];

            for (int i = 0; i < newRow.Length; i++)
            {   
                //Copy contents only for candidates that are not precluded
                if (!precluded.Contains(i))
                {
                    newRow[i] = this.tempPreferences.getRow(i)[1];
                }
                else
                {
                    //For candidates that are precluded, display a P
                    newRow[i] = "P";
                }
                Console.Write(newRow[i]);
            }
            Console.WriteLine();
            
            return newRow;
        }

        #endregion

        #region Quit Application

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            //Simply quit the application
            this.Close();
        }

        #endregion

    }
}
