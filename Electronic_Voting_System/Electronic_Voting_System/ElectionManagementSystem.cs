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

        private User currentUser;

        public ElectionManagementSystem()
        {
            this.election = new Election();
            this.users = new List<User>();
            this.pendingValidations = new List<User>();
            this.currentUser = null;
        }

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

        /// <summary>
        /// Calculates demographics of voters. 
        /// </summary>
        public Dictionary<string, int> GetDemographics()
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            return this.currentUser;
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

        public List<Candidate> GetCandidates()
        {
            return this.election.GetCandidates();
        }

        /// <summary>
        /// Calls Election method to check end date.
        /// </summary>
        /// <returns></returns>
        public bool ElectionHasEnded()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks this.users to see if username/password combo is listed.
        /// If found, sets that User as this.currentUser and returns true.
        /// Else returns false.
        /// </summary>
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a User object from the parameters.
        /// Should validate entries - check that username not taken, email, birthdate and ssn in correct format, etc.
        /// Adds the new User object to this.users and this.pendingValidations.
        /// Returns true if valid input.
        /// </summary>
        public bool Register(string username, string password, string email, string birthDate, int SSN, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns election object for UI to display.
        /// </summary>
        public Election GetElection()
        {
            return this.election;
        }

        /// <summary>
        /// Sets this.election to a new instance of Election.
        /// </summary>
        public void StartNewElection()
        {

        }

        /// <summary>
        /// Sets this.election to a new instance of Election.
        /// Verifies that start date is before end date.
        /// </summary>
        public void StartNewElection(DateTime start, DateTime end)
        {

        }

        /// <summary>
        /// Create a Candidate object and pass it to Election.
        /// </summary>
        public void AddCandidate(string name, string party)
        {

        }

        /// <summary>
        /// Makes win percentage accessible for UI.
        /// </summary>
        public double GetMinWinPercentage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows UI to set win percentage.
        /// </summary>
        public void SetMinWinPercentage()
        {

        }

        /// <summary>
        /// Pass to Election to remove a Candidate.
        /// </summary>
        /// <param name="candidate"></param>
        public void RemoveCandidate(Candidate candidate)
        {

        }

        /// <summary>
        /// Remove candidate with index in list.
        /// </summary>
        public void RemoveCandidate(int index)
        {

        }

        /// <summary>
        /// Converts election start date to string for UI.
        /// </summary>
        public string GetStartDate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts election end date to string for UI.
        /// </summary>
        public string GetEndDate()
        {
            throw new NotImplementedException();
        }
    }
}
