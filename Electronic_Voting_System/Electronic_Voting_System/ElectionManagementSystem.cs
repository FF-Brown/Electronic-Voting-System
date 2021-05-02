﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class ElectionManagementSystem
    {
        private Election election;

        private Dictionary<string, User> users;

        private Dictionary<string, User> pendingValidations;

        private User currentUser;

        public ElectionManagementSystem()
        {
            this.election = new Election();
            this.users = new Dictionary<string, User>();
            this.pendingValidations = new Dictionary<string, User>();
            this.currentUser = null;
        }

        public void AuthenticateUser(User user)
        {
            user.setIsRegistered(true);
        }

        public void DisplayAdminPortal()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, User> GetUserList()
        {
            return this.users;
        }

        public void RegisterUser(User user)
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

        public Dictionary<string, User> GetPendingValidations()
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
            bool success = false;
            if (this.users.ContainsKey(username))
            {
                if (this.users[username].getUserProfile().getPW() == password)
                {
                    this.currentUser = this.users[username];
                    success = true;
                }
            }

            return success;
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
            this.election = new Election();
        }

        /// <summary>
        /// Sets this.election to a new instance of Election.
        /// Currently accepts dates in the form YYYY-MM-DD, YYYY/MM/DD, MM-DD-YYYY or MM/DD/YYYY.
        /// Verifies that start date is before end date.
        /// </summary>
        public bool StartNewElection(string startDate, string endDate)
        {
            bool startedNewElection = false;

            if (startDate is null || endDate is null || startDate.Length < 10 || endDate.Length < 10)
            {
                return startedNewElection;
            }

            try
            {
                DateTime startDT = DateTime.Parse(startDate);
                try
                {
                    DateTime endDT = DateTime.Parse(endDate);
                    this.election = new Election(new List<Candidate>(), startDT, endDT, 50);
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }

            return startedNewElection;
        }

        /// <summary>
        /// Create a Candidate object and pass it to Election.
        /// </summary>
        public void AddCandidate(string name, string party)
        {
            this.election.addCandidate(new Candidate(name, party));
        }

        /// <summary>
        /// Makes win percentage accessible for UI.
        /// </summary>
        public double GetMinWinPercentage()
        {
            return this.election.min_win_percentage;
        }

        /// <summary>
        /// Allows UI to set win percentage.
        /// </summary>
        public void SetMinWinPercentage(double percentage)
        {
            this.election.min_win_percentage = percentage;
        }

        /// <summary>
        /// Pass to Election to remove a Candidate.
        /// </summary>
        /// <param name="candidate"></param>
        public bool RemoveCandidate(Candidate candidate)
        {
            return this.election.removeCandidate(candidate);
        }

        /// <summary>
        /// Remove candidate with index in list.
        /// </summary>
        public bool RemoveCandidate(int index)
        {
            return this.election.removeCandidate(index);
        }

        /// <summary>
        /// Converts election start date to string for UI.
        /// </summary>
        public string GetStartDate()
        {
            DateTime dt = this.election.start_date;
            string output = dt.Year
                + "-" + dt.Month
                + "-" + dt.Day;
            return output;
        }

        /// <summary>
        /// Converts election end date to string for UI.
        /// </summary>
        public string GetEndDate()
        {
            DateTime dt = this.election.end_date;
            string output = dt.Year
                + "-" + dt.Month
                + "-" + dt.Day;
            return output;
        }
    }
}
