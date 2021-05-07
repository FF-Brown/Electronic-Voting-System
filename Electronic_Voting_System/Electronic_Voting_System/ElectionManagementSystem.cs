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
            pendingValidations.Remove(user.getUserProfile().getUsername()); // Remove "registered" user profile off of validationslist
        }

        /// <summary>
        /// Method that returns the election status
        /// </summary>
        /// <returns>election status as a bool</returns>
        public bool GetElectionStatus()
        {
            return election.is_active;
        }

        public Dictionary<string, User> GetUserList()
        {
            return this.users;
        }

        public bool UserIsAdmin()
        {
            return this.currentUser.getIsAdmin();
        }

        /// <summary>
        /// Adds new User object to this.users and this.pendingValidations.
        /// </summary>
        /// <param name="user"></param>
        private void RegisterUser(User user)
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

        public void Vote(string candidate)
        {
            // User must be logged in.
            if (currentUser != null)
            {
                // User must be registered (accepted by admin).
                if (currentUser.getIsRegistered())
                {
                    // Get Candidate object from election.
                    if (this.election.GetCandidate(candidate, out Candidate votedCandidate))
                    {
                        // Set user Voted Candidate.
                        this.currentUser.setVotedCandidate(votedCandidate);

                        // Add a vote to that candidate.
                        this.election.addVote(candidate);
                    }
                }
            }
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

        public void SaveXML()
        {
            FileStream electionOutFile = File.OpenWrite(".\\Trash\\electionInfo.xml");
            FileStream userOutFile = File.OpenWrite(".\\Trash\\userInfo.xml");
            if (electionOutFile != null && userOutFile != null)
            {
                this.saveToFile(electionOutFile, userOutFile);
            }
            electionOutFile.Close();
            userOutFile.Close();
        }

        public void LoadXML()
        {
            FileStream electionInFile = File.OpenRead("electionInfo.xml");
            FileStream userInFile = File.OpenRead("userInfo.xml");
            if (electionInFile != null && userInFile != null)
            {
                this.loadFromFile(electionInFile, userInFile);
            }
            electionInFile.Close();
            userInFile.Close();
        }

        /// <summary>
        /// Should be called automatically before program closes.
        /// Writes election data to electionOutFile and userList to userOutFile.
        /// Returns true if successful.
        /// </summary>
        public int saveToFile(Stream electionOutFile, Stream userOutFile)
        {
            bool result;

            if (electionOutFile != null)
            {
                XmlDocument doc = new XmlDocument();

                // Modify write settings.
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    NewLineChars = "\n",
                    Indent = true,
                    IndentChars = "\t",
                    NewLineOnAttributes = true,
                    OmitXmlDeclaration = false,
                };
                XmlWriter writer = XmlWriter.Create(electionOutFile, settings);

                doc.LoadXml("<EMS>" + "</EMS>");

                // Create cell element and root node.
                XmlNode root = doc["EMS"];
                XmlElement userElement = doc.CreateElement("election");
                XmlNode importNode = null;

                // Create Xml element from cell.
                result = this.ElectionToXML(election, out userElement);

                // True if cell was not empty.
                if (result)
                {
                    // Append shape to record and format it nicely.
                    importNode = doc.ImportNode(userElement, true);
                    root.AppendChild(importNode);
                }

                // Save Xml Doc.
                doc.Save(writer);
                writer.Close();
            }

            int usersSaved = 0;

            if (userOutFile != null)
            {
                XmlDocument doc = new XmlDocument();

                // Modify write settings.
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    NewLineChars = "\n",
                    Indent = true,
                    IndentChars = "\t",
                    NewLineOnAttributes = true,
                    OmitXmlDeclaration = false,
                };
                XmlWriter writer = XmlWriter.Create(userOutFile, settings);

                doc.LoadXml("<userList>" + "</userList>");

                // Create cell element and root node.
                XmlNode root = doc["userList"];
                XmlElement userElement = doc.CreateElement("user");
                XmlNode importNode = null;

                foreach (User user in this.users.Values)
                {
                    // Create Xml element from cell.
                    result = this.UserToXML(user, out userElement);

                    // True if cell was not empty.
                    if (result)
                    {
                        usersSaved++;

                        // Append shape to record and format it nicely.
                        importNode = doc.ImportNode(userElement, true);
                        root.AppendChild(importNode);
                    }
                }

                // Save Xml Doc.
                doc.Save(writer);
                writer.Close();
            }

            return usersSaved;
        }

        /// <summary>
        /// Should be called automatically when the program runs.
        /// </summary>
        public bool loadFromFile(Stream electionInFile, Stream userInFile)
        {
            XmlDocument electionDoc = new XmlDocument();

            // Begin loading Xml document.
            if (electionInFile != null)
            {
                try
                {
                    electionDoc.Load(electionInFile);
                }
                catch (Exception)
                {
                    return false;
                }
                if (electionDoc.HasChildNodes)
                {
                    XmlNode root;
                    try
                    {
                        root = electionDoc["EMS"];
                        root = root["election"];
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    // Clear election in EMS wrapper.
                    this.election = new Election();

                    if (root.HasChildNodes)
                    {
                        this.XMLToElection(out this.election, root);
                    }
                }
            }

            XmlDocument userDoc = new XmlDocument();

            // Begin loading Xml document.
            if (userInFile != null)
            {
                try
                {
                    userDoc.Load(userInFile);
                }
                catch (Exception)
                {
                    return false;
                }
                if (userDoc.HasChildNodes)
                {
                    XmlNode userRoot;
                    try
                    {
                        userRoot = userDoc["userList"];
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    // Clear userList in userList wrapper.
                    this.users = new Dictionary<string, User>();

                    User newUser = new User(); // Temp user object

                    foreach (XmlNode userNode in userRoot.ChildNodes)
                    {
                        this.XMLToUser(out newUser, userNode); // Load user element to user object

                        if (newUser.getIsRegistered())
                        {
                            this.users.Add(newUser.getUserProfile().getUsername(), newUser); // Add user to user if they are registered
                        }
                        else
                        {
                            this.users.Add(newUser.getUserProfile().getUsername(), newUser);
                            this.pendingValidations.Add(newUser.getUserProfile().getUsername(), newUser); // Add user to pendingValidations if they are not yet registered
                        }
                    }
                }
            }
            return true;
        }

        internal bool ElectionToXML(Election election, out XmlElement xml)
        {
            // Create temporary XmlDoc to create Element and Attribute objects.
            XmlDocument doc = new XmlDocument();
            xml = doc.CreateElement("election");

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
            endDateElement.InnerText = election.end_date.Date.ToString();
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

            XmlNode importNode = null;

            // Create and assign candidate elements. 
            // MAY BE A PROBLEM. If it doesn't work, try just copying the body of the CandidateToXML() function into this loop.
            foreach (Candidate candidate in election.GetCandidates())
            {
                if (this.CandidateToXML(candidate, out XmlElement candidateElement))
                {
                    importNode = doc.ImportNode(candidateElement, true);
                    xml.AppendChild(importNode);
                }
            }

            return true;
        }

        internal bool XMLToElection(out Election election, XmlNode xml)
        {
            election = new Election();

            election.start_date = DateTime.Parse(xml["startDate"].InnerText); // Load start date
            election.end_date = DateTime.Parse(xml["endDate"].InnerText); // Load end date
            election.min_win_percentage = Convert.ToDouble(xml["winPercentage"].InnerText); // Load win percentage
            election.is_active = Convert.ToBoolean(xml["active"].InnerText); // Load isActive

            Candidate newCandidate = new Candidate(); // Create temp candidate object

            foreach (XmlNode candidate in xml.ChildNodes)
            {
                if (candidate.Name == "candidate") // If XML element Name == "candidate"
                {
                    XMLToCandidate(out newCandidate, candidate); // Load one candidate from the xml
                    this.election.addCandidate(newCandidate); // Add new candidate to election
                }
            }
           
            return true;
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
            candidate = new Candidate();

            candidate.name = xml["name"].InnerText;
            candidate.party = xml["party"].InnerText;
            candidate.total_votes = Convert.ToInt32(xml["votes"].InnerText);

            return true;
        }

        internal bool UserToXML(User user, out XmlElement xml)
        {
            // Create temporary XmlDoc to create Element and Attribute objects.
            XmlDocument doc = new XmlDocument();
            xml = doc.CreateElement("user");

            // Create and assign NAME element.
            XmlElement nameElement = doc.CreateElement("name");
            nameElement.InnerText = user.getUserProfile().getName();
            xml.AppendChild(nameElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                nameElement.OuterXml,
                "\n    " + nameElement.OuterXml + " \n    ");

            // Create and assign USERNAME element.
            XmlElement usernameElement = doc.CreateElement("username");
            usernameElement.InnerText = user.getUserProfile().getUsername();
            xml.AppendChild(usernameElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                usernameElement.OuterXml,
                "\n    " + usernameElement.OuterXml + " \n    ");

            // Create and assign ADDRESS/STATE element.
            XmlElement addressElement = doc.CreateElement("address");
            addressElement.InnerText = user.getUserProfile().getState();
            xml.AppendChild(addressElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                addressElement.OuterXml,
                "\n    " + addressElement.OuterXml + " \n    ");

            // Create and assign email element.
            XmlElement emailElement = doc.CreateElement("email");
            emailElement.InnerText = user.getUserProfile().getEmail();
            xml.AppendChild(emailElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                emailElement.OuterXml,
                "\n    " + emailElement.OuterXml + " \n    ");

            // Create and assign PASSWORD element.
            XmlElement passwordElement = doc.CreateElement("pw");
            passwordElement.InnerText = user.getUserProfile().getPW();
            xml.AppendChild(passwordElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                passwordElement.OuterXml,
                "\n    " + passwordElement.OuterXml + " \n    ");

            // Create and assign DOB element.
            XmlElement dobElement = doc.CreateElement("dob");
            dobElement.InnerText = user.getUserProfile().getDOB();
            xml.AppendChild(dobElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                dobElement.OuterXml,
                "\n    " + dobElement.OuterXml + " \n    ");

            // Create and assign SSN element.
            XmlElement ssnElement = doc.CreateElement("ssn");
            ssnElement.InnerText = user.getUserProfile().getSSN().ToString();
            xml.AppendChild(ssnElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                ssnElement.OuterXml,
                "\n    " + ssnElement.OuterXml + " \n    ");

            // Create and assign IsAdmin element.
            XmlElement adminElement = doc.CreateElement("isAdmin");
            adminElement.InnerText = user.getIsAdmin().ToString();
            xml.AppendChild(adminElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                adminElement.OuterXml,
                "\n    " + adminElement.OuterXml + " \n    ");

            // Create and assign hasVoted element.
            XmlElement hasVotedElement = doc.CreateElement("hasVoted");
            hasVotedElement.InnerText = user.getHasVoted().ToString();
            xml.AppendChild(hasVotedElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                hasVotedElement.OuterXml,
                "\n    " + hasVotedElement.OuterXml + " \n    ");

            // Create and assign isRegistered element.
            XmlElement registeredElement = doc.CreateElement("isRegistered");
            registeredElement.InnerText = user.getIsRegistered().ToString();
            xml.AppendChild(registeredElement);

            // Append newline.
            xml.InnerXml = xml.InnerXml.Replace(
                registeredElement.OuterXml,
                registeredElement.OuterXml + " \n    ");

            return true;
        }

        /// <summary>
        /// Converts a single XMLNode to a user profile and returns user.
        /// </summary>
        /// <param name="user">User profile.</param>
        /// <param name="xml">XML childnode?</param>
        /// <returns>New User profile.</returns>
        internal bool XMLToUser(out User user, XmlNode xml)
        {
            user = new User();

            user.getUserProfile().setName(xml["name"].InnerText); // Set Name
            user.getUserProfile().setUsername(xml["username"].InnerText); // Set Username
            user.getUserProfile().setState(xml["address"].InnerText); // Set address
            user.getUserProfile().setEmail(xml["email"].InnerText); // Set email
            user.getUserProfile().setPW(xml["pw"].InnerText); // Set password
            user.getUserProfile().setDOB(xml["dob"].InnerText); // Set DOB
            user.getUserProfile().setSSN(Convert.ToInt32(xml["ssn"].InnerText)); // Set SSN
            user.setAdmin(Convert.ToBoolean(xml["isAdmin"].InnerText)); // Set isAdmin
            user.setIsRegistered(Convert.ToBoolean(xml["isRegistered"].InnerText)); // Set isRegistered
            user.setHasVoted(Convert.ToBoolean(xml["hasVoted"].InnerText)); // Set hasVoted

            return true;
        }
    }
}