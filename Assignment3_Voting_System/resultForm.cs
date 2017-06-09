using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        
    }
}
