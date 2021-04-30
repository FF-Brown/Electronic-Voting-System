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

        private List<Candidate> electionResults;

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

    }
}
