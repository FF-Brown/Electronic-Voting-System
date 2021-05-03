using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class Profile
    {
        // Name, Address, Email, Password, Date of Birth, Social Security Number
		// private variables
		private string name, username, address, email, pw, dob;

		private int ssn;

		// Constructor 
		public Profile()
		{ 
			name = "";		// Name
			address = ""; 	// Address
			email = "";		// Email
			pw = "";		// Password
			dob = "";		// Date of Birth
			ssn = 0;		// Social Security Number
		}

		public Profile(string name, string username, string address, string email, string password, string birthdate, int SSN)
        {
			this.name = name;
			this.username = username;
			this.address = address;
			this.email = email;
			this.pw = password;
			this.dob = birthdate;
			this.ssn = SSN;
        }

		// Getters
		public string getName()		{	return name;	}
		public string getUsername() { return username; }
		public string getAddress()	{	return address;	}
		public string getEmail()	{	return email;	}
		public string getPW()		{	return pw;		}
		public string getDOB()		{	return dob;		}
		public int getSSN()		{	return ssn;		}

		// Setters
		public void setName(string n )			{	name = n;		}
		public void setAddress(string a)		{	address = a;	}
		public void setEmail(string e)			{	email = e;		}
		public void setPW(string p)				{	pw = p;			}
		public void setDOB(string d)			{	dob = d;		}
		public void setSSN(int s)			{	ssn = s;		}
    }
}
