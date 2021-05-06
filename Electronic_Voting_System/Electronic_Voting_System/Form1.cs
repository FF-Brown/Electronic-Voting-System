using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_Voting_System
{
    public partial class Form1 : Form
    {
        private ElectionManagementSystem EMS;
        private bool loginResult;

        public Form1()
        {
            InitializeComponent();
            EMS = new ElectionManagementSystem();
            this.Text = "Electronic Voting System";
            this.loginResult = false;
        }

        /// <summary>
        /// Method that returns the login menu results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new LoginForm())
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    string username = form.Username;
                    string password = form.Password;

                    // If username && password matches a user or admin
                    // Present the voting or admin menu

                    if(EMS.Login(username, password) == true)
                    {
                        // username & password matches a user
                        // Show voting menu
                        this.loginResult = true;
                        using (var votingForm = new VotingForm())
                        {
                            //var result
                        }
                    } /*
                    else if (EMS.AdminLogin(username, password))
                    {
                        // username & password matches the admin
                        // Show admin menu

                    } */
                    else
                    {
                        // No credentials match a user or admin

                    }
                }
            }
        }

        /// <summary>
        /// Method that returns the register menu inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using (var form = new RegisterForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string username = form.Name;
                    string password = form.Password;
                    string email = form.Email;
                    string address = form.Address;
                    string birthdate = form.Birthdate;
                    try
                    {
                        int SSN = Convert.ToInt32(form.SSN);

                        // Put the user on the pending verification list
                        EMS.Register(username, password, email, birthdate, SSN, username, address);

                        // Display confirmation and close the register form
                        form.Close();

                    }
                    catch
                    {
                        // Invalid SSN. User not registered.
                    }
                    
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // show Election Info
            // ElectionInfo info = EMS.getElectionInfo();
            ElectionInfoForm infoForm = new ElectionInfoForm(EMS);
            infoForm.Show();
        }

        private void VoteButton_Click(object sender, EventArgs e)
        {
            this.loginResult = true; // remove this after implementation
            if(this.loginResult == true)
            {
                // if a valid user is logged in
                // Show the voting menu

                using (var form = new VotingForm())
                {
                    var result = form.ShowDialog();
                    if(result == DialogResult.OK)
                    {

                    }
                }
            }
        }
    }
}
