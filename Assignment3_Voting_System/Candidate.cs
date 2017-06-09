using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Voting_System
{
    class Candidate
    {
        public String name { set; get; }
        public int votes { set; get; }

        public Candidate(String name, int votes)
        {
            this.name = name;
            this.votes = votes;
        }
    }
}
