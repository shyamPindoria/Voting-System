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


    }
}
