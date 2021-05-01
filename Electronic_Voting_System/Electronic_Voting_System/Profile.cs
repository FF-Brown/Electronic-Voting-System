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
		private string name, address, email, pw, dob, ssn;

		// Constructor 
		public Profile()
		{ 
			name = "";		// Name
			address = ""; 	// Address
			email = "";		// Email
			pw = "";		// Password
			dob = "";		// Date of Birth
			ssn = "";		// Social Security Number
		}

		// Getters
		public string getName()		{	return name;	}
		public string getAddress()	{	return address;	}
		public string getEmail()	{	return email;	}
		public string getPW()		{	return pw;		}
		public string getDOB()		{	return dob;		}
		public string getSSN()		{	return ssn;		}

		// Setters
		public void setName(string n )			{	name = n;		}
		public void setAddress(string a)		{	address = a;	}
		public void setEmail(string e)			{	email = e;		}
		public void setPW(string p)				{	pw = p;			}
		public void setDOB(string d)			{	dob = d;		}
		public void setSSN(string p)			{	ssn = s;		}
    }
}
