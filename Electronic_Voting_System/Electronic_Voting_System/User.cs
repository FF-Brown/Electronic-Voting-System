using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class User
    {
        // private variables

		// Profile
		Profile userProfile;
		// Is the user already registered?
		bool isRegistered;
		// Has the user voted?
		bool hasVoted;
		// Is the user an administrator?
		bool isAdmin;
		// the candidate the user voted for
		Candidate votedCandidate; 

		// Constructor
		public User()
		{
			userProfile = new Profile();
			isRegistered = false;
			hasVoted = false;
			isAdmin = false;
			Candidate votedCandidate = new Candidate();
		}

		/******** Getters ********/ 

		// return whether the user is an administrator
		public bool getIsAdmin()				{ return isAdmin; }

		// return whether the user has voted
		public bool getHasVoted()				{ return hasVoted;}

		// return whether the user is registered 
		public bool getIsRegistered()			{ return isRegistered; }

		// return the Candidate the user voted for
		public Candidate getVotedCandidate()	{ return votedCandidate; }

		// return the user's profile
		public Profile getUserProfile()			{ return userProfile; }

		/******** Setters ********/ 

		// set admin
		public void setAdmin(bool b) { isAdmin = b; }

		// set has voted
		public void setHasVoted(bool b) { hasVoted = b; }

		// set registered 
		public void setIsRegistered(bool b) { isRegistered = b; }

		// set the candidate the user voted for
		public void setVotedCandidate (Candidate c) { Candidate c; }

		// set the user's profile to a new profile
		public void setProfile (Profile p) { userProfile = p; }
    }
}
