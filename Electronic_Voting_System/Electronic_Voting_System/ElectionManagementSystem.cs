using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class ElectionManagementSystem
    {
        private Election election;

        private List<User> users;

        private List<User> pendingValidations;

        private List<Candidate> candidate_list;

        private User currentUser;

        public void AuthenticateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminPortal()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserList()
        {
            return this.users;
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetPendingValidations()
        {
            return this.pendingValidations;
        }

        public void Vote()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetDemographics()
        {
            throw new NotImplementedException();
        }

        // we'll need something like this to constantly check if the min_win_percentage or the deadline has been reached
        // total voters would just be length(Userlist)
        // current date will need to update somehow, the whole date system could be improved as its just strings, no error/format checking
        public static void checkElection(Election election, List<Candidate> candidates, int total_voters, DateTime current_date)
        {
            election.sortByVotes();
            // check if minimum win percentage has been reached by the candidate with the most votes
            if ((candidates[0].total_votes / total_voters) * 100 > election.min_win_percentage)
            {
                election.stopElection();
            }
            // check if the deadline has passed
            if (DateTime.Compare(current_date, election.end_date) > 0)
            {
                election.stopElection();
            }
        }

        // adding/removing candidates (should be accessed from the admin portal/menu)
        public static void addCandidate(List<Candidate> candidates)
        {
            Console.WriteLine("Enter Candidates Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Candidates Party: ");
            string party = Console.ReadLine();

            candidates.Add(new Candidate(name, party));
        }
        // adding/removing candidates (should be accessed from the admin portal/menu)
        public static void removeCandidate(List<Candidate> candidates)
        {
            Console.WriteLine("Enter Candidates Name to Remove:");
            string name = Console.ReadLine();

            candidates.RemoveAll(r => r.name == name);
        }

    }
}
