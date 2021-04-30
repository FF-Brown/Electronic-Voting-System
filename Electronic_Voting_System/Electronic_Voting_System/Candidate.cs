using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class Candidate
    {
        public string name{get; set;}
        public string party{get; set;}
        public int total_votes{get; set;}

        public Candidate(string Name, string Party)
        {
            name = Name;
            party = Party;
            total_votes = 0;
        }

        public void addVote()
        {
            total_votes++;
        }
    }
}
