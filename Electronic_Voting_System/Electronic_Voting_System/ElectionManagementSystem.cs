using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

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

        /// <summary>
        /// Method that returns the election status
        /// </summary>
        /// <returns>election status as a bool</returns>
        public bool GetElectionStatus()
        {
            return election.is_active;
        }

        public void DisplayAdminPortal()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, User> GetUserList()
        {
            return this.users;
        }

        /// <summary>
        /// Adds new User object to this.users and this.pendingValidations.
        /// </summary>
        /// <param name="user"></param>
        public void RegisterUser(User user)
        {
            this.users.Add(user.getUserProfile().getUsername(), user);
            this.pendingValidations.Add(user.getUserProfile().getUsername(), user);
        }

        /// <summary>
        /// Creates a User object from the parameters.
        /// Should validate entries - check that username not taken, email, birthdate and ssn in correct format, etc.
        /// Returns true if valid input.
        /// </summary>
        public bool Register(string username, string password, string email, string birthDate, int SSN, string name, string address)
        {
            bool createdUser = false;

            if (!this.users.ContainsKey(username))
            {
                if (password != string.Empty)
                {
                    if (SSN.ToString().Length == 9)
                    {
                        try
                        {
                            DateTime.Parse(birthDate);
                            this.RegisterUser(new User(new Profile(name, username, address, email, password, birthDate, SSN)));
                            createdUser = true;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            return createdUser;
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
        /// by "demographics" it means how many votes from each state
        /// </summary>
        public Dictionary<string, int> GetDemographics()
        {
            Dictionary<string, int> demographics = new Dictionary<string, int>(){{"AL",0},{"AK",0},{"AZ",0},{"AR",0},{"CA",0},
                                                                                {"CO",0},{"CT",0},{"DE",0},{"FL",0},{"GA",0},
                                                                                {"HI",0},{"ID",0},{"IL",0},{"IN",0},{"IA",0},
                                                                                {"KS",0},{"KY",0},{"LA",0},{"ME",0},{"MD",0},
                                                                                {"MA",0},{"MI",0},{"MN",0},{"MS",0},{"MO",0},
                                                                                {"MT",0},{"NE",0},{"NV",0},{"NH",0},{"NJ",0},
                                                                                {"NM",0},{"NY",0},{"NC",0},{"ND",0},{"OH",0},
                                                                                {"OK",0},{"OR",0},{"PA",0},{"RI",0},{"SC",0},
                                                                                {"SD",0},{"TN",0},{"TX",0},{"UT",0},{"VT",0},
                                                                                {"VA",0},{"WA",0},{"WV",0},{"WI",0},{"WY",0}};
            foreach (var user in this.users)
            {
                demographics[user.Value.getUserProfile().getState()]++;
            }

            return demographics;
        }

        public User GetCurrentUser()
        {
            return this.currentUser;
        }

        public void SetCurrentUser(User user)
        {
            this.currentUser = user;
        }

        public List<Candidate> GetCandidates()
        {
            return this.election.GetCandidates();
        }

        /// <summary>
        /// Compares election end date to Now.
        /// If end date <= Now, returns true;
        /// </summary>
        public bool ElectionHasEnded()
        {
            return DateTime.Compare(this.election.end_date, DateTime.Now) <= 0;
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
        /// Accepts any standard date format.
        /// Verifies that start date is before end date.
        /// Returns false if dates are not correctly formatted or if start date >= end date.
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
                    if (DateTime.Compare(startDT, endDT) < 0)
                    {
                        this.election = new Election(new List<Candidate>(), startDT, endDT, 50);
                        startedNewElection = true;
                    }
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

        /// <summary>
        /// Should be called automatically before program closes.
        /// Writes election data to electionOutFile and userList to userOutFile.
        /// Returns true if successful.
        /// </summary>
        public bool saveToFile(Stream electionOutFile, Stream userOutFile)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Should be called automatically when the program runs.
        /// </summary>
        public bool loadFromFile(Stream electionInFile, Stream userInFile)
        {
            throw new NotImplementedException();
        }

        internal bool ElectionToXML(Election election, out XmlElement xml)
        {
            // Create temporary XmlDoc to create Element and Attribute objects.
            XmlDocument doc = new XmlDocument();
            xml = doc.CreateElement("shape");

            // Create and assign startDate element.
            XmlElement startDateElement = doc.CreateElement("startDate");
            startDateElement.InnerText = election.start_date.Date.ToString();
            xml.AppendChild(startDateElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                startDateElement.OuterXml,
                "\n    " + startDateElement.OuterXml + " \n    ");

            // Create and assign endDate element.
            XmlElement endDateElement = doc.CreateElement("endDate");
            endDateElement.InnerText = election.start_date.Date.ToString();
            xml.AppendChild(endDateElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                endDateElement.OuterXml,
                "\n    " + endDateElement.OuterXml + " \n    ");

            // Create and assign winPercentage element.
            XmlElement winPercentageElement = doc.CreateElement("winPercentage");
            winPercentageElement.InnerText = election.min_win_percentage.ToString();
            xml.AppendChild(winPercentageElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                winPercentageElement.OuterXml,
                "\n    " + winPercentageElement.OuterXml + " \n    ");

            // Create and assign active element.
            XmlElement activeElement = doc.CreateElement("active");
            activeElement.InnerText = election.is_active.ToString();
            xml.AppendChild(activeElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                activeElement.OuterXml,
                "\n    " + activeElement.OuterXml + " \n    ");

            // Create and assign candidate elements. 
            // MAY BE A PROBLEM. If it doesn't work, try just copying the body of the CandidateToXML() function into this loop.
            foreach (Candidate candidate in election.GetCandidates())
            {
                if (this.CandidateToXML(candidate, out XmlElement candidateElement))
                {
                    xml.AppendChild(candidateElement);
                }
            }

            return true;
        }

        internal bool XMLToElection(out Election election, XmlNode xml)
        {
            throw new NotImplementedException();
        }

        internal bool CandidateToXML(Candidate candidate, out XmlElement xml)
        {
            // Create temporary XmlDoc to create Element and Attribute objects.
            XmlDocument doc = new XmlDocument();
            xml = doc.CreateElement("candidate");

            // Create and assign name element.
            XmlElement nameElement = doc.CreateElement("name");
            nameElement.InnerText = candidate.name;
            xml.AppendChild(nameElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                nameElement.OuterXml,
                "\n    " + nameElement.OuterXml + " \n    ");

            // Create and assign party element.
            XmlElement partyElement = doc.CreateElement("party");
            partyElement.InnerText = candidate.party;
            xml.AppendChild(partyElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                partyElement.OuterXml,
                "\n    " + partyElement.OuterXml + " \n    ");

            // Create and assign votes element.
            XmlElement votesElement = doc.CreateElement("votes");
            votesElement.InnerText = candidate.total_votes.ToString();
            xml.AppendChild(votesElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                votesElement.OuterXml,
                votesElement.OuterXml + " \n    ");

            return true;
        }

        internal bool XMLToCandidate(out Candidate candidate, XmlNode xml)
        {
            throw new NotImplementedException();
        }

        internal bool UserToXML(User user, out XmlElement xml)
        {
            throw new NotImplementedException();
        }

        internal bool XMLToUser(out User user, XmlNode xml)
        {
            throw new NotImplementedException();
        }
    }
}
