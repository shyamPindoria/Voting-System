using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Voting_System
{
    class Candidate : IComparable
    {
        public String name { set; get; }
        public int votes { set; get; }

        public Candidate(String name, int votes)
        {
            this.name = name;
            this.votes = votes;
        }

        public int CompareTo(object obj)
        {
            if (this.votes > ((Candidate) obj).votes)
            {
                return 1;
            }
            else if (this.votes < ((Candidate)obj).votes)
            {
                return -1;
            }
            return 0;
        }
    }
}
