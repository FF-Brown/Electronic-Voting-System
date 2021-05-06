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
    public partial class AdminForm : Form
    {
        private ElectionManagementSystem EMS;
        Dictionary<string, User> validationList;

        public AdminForm(ElectionManagementSystem EMS)
        {
            InitializeComponent();
            this.EMS = EMS;
            validationList = EMS.GetPendingValidations();

            // Fill out the election status elements
            this.label2.Text = "Election Status: " + EMS.GetElectionStatus().ToString();
            this.label3.Text = EMS.GetEndDate();

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
                this.label2.Text = "Election Status: " + EMS.GetElectionStatus().ToString();
                this.label3.Text = EMS.GetEndDate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Force End election
        }

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
            }
        }
    }
}
