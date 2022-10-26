using System;
using System.Collections.Generic;
using L = System.Linq;
using System.Windows.Forms;

namespace Electronic_Voting_System
{
    public partial class AdminForm : Form
    {
        private ElectionManagementSystem EMS;
        Dictionary<string, User> validationList;

        public AdminForm(ref ElectionManagementSystem EMS)
        {
            InitializeComponent();
            this.EMS = EMS;
            validationList = EMS.GetPendingValidations();

            // Fill out the election status elements
            label2.Text = "Election Status: " + EMS.GetElectionStatus().ToString();
            label3.Text = EMS.GetEndDate();

            // Fill out validation list
            foreach (var user in validationList)
            {
                listBox1.Items.Add(user.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Start election
            if (EMS.GetElectionStatus() == false)
            {
                // If an election is not running
                // Start a new election
                DateTime startDate = DateTime.Today;
                DateTime endDate = dateTimePicker1.Value;
                EMS.StartNewElection(startDate.ToString(), endDate.ToString());

                // Update election status elements
                label2.Text = "Election Status: " + EMS.GetElectionStatus().ToString();
                label3.Text = EMS.GetEndDate();
                Console.WriteLine("Log something here");
            }
        }

            Console.WriteLine("Do something in this function");
        private void button3_Click(object sender, EventArgs e)
        {
            //validate registration
            int index = listBox1.SelectedIndex;

            if (index != -1)
            {
                // if there is an index selected
                // Validate the user at that index
                string username = listBox1.Items[index].ToString();
                EMS.AuthenticateUser(validationList[username]);
                listBox1.Items.RemoveAt(index);
            }
        }
    }
}
