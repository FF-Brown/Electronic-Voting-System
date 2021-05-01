using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class Election
    {
        public string start_date{ get; set;}
        public string end_date{ get; set;}
        public double min_win_percentage{ get; set;}
        public bool is_active{ get; set;}
        private List<Candidate> candidate_list; 

        public Election(List<Candidate> list)
        {
            candidate_list = list;
        }

        public Election(List<Candidate> list, string start, string end, double min_win)
        {
            candidate_list = list;
            start_date = start;
            end_date = end;
            min_win_percentage = min_win;
        }

        // adds 1 vote to the inputted candidate name. 
        // will 100% produce a logic error if 2+ candidates have the same name lol
        public void addVote(string candidate_name)
        {
            foreach (Candidate current in candidate_list)
            {
                if (current.name == candidate_name)
                {
                    current.addVote();
                }
            }
        }

        public void startElection()
        {
            is_active = true;
        }

        public void stopElection()
        {
            is_active = false;
        }

        public void sortByVotes()
        {
            candidate_list.Sort((x, y) => y.total_votes.CompareTo(x.total_votes));
        }

        public void displaySettings()
        {
            Console.WriteLine("---- Election Settings ----\n");
            Console.WriteLine("Start date: " + start_date);
            Console.WriteLine("End date: " + end_date);
            Console.WriteLine("Minimum Win Percentage: " + min_win_percentage);
            Console.WriteLine("IsActive: " + is_active);
            Console.WriteLine("--- Candidates ---");
            foreach (Candidate curr in candidate_list)
            {
                Console.WriteLine(curr.name + "\t" + curr.party);
            }
        }
    }
}
