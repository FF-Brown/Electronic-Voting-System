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
    public partial class ElectionInfoForm : Form
    {
        private ElectionManagementSystem EMS;
        public ElectionInfoForm(ElectionManagementSystem EMS)
        {
            InitializeComponent();
            this.Text = "Election Information";
            this.EMS = EMS;

            // Fill out all the election info with the info in the EMS
            //EMS.loadFromFile();

            // First fill out the candidate list
            List<Candidate> candidateList = EMS.GetCandidates();
            foreach (var candidate in candidateList)
            {
                listBox1.Items.Add(candidate.name + ": " + candidate.total_votes);
            }

            // Update the election status
            if (EMS.ElectionHasEnded())
            {
                this.label3.Text = "Election Status: INACTIVE";
            }
            else if (EMS.ElectionHasEnded())
            {
                this.label3.Text = "Election Status: ACTIVE";
            }

            // Update the demographics
            Dictionary<string, int> demographics = EMS.GetDemographics();

            // Display demographics in the tablelayoutpanel
            this.tableLayoutPanel1.Controls.Add(new Label() { Text = "State:", TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            this.tableLayoutPanel1.Controls.Add(new Label() { Text = "Votes:", TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            foreach (var demographic in demographics)
            {
            
                this.tableLayoutPanel1.RowCount++;
                this.tableLayoutPanel1.Controls.Add(new Label() { Text = demographic.Key, TextAlign = ContentAlignment.MiddleCenter }, 0, tableLayoutPanel1.RowCount - 1);
                this.tableLayoutPanel1.Controls.Add(new Label() { Text = demographic.Value.ToString(), TextAlign = ContentAlignment.MiddleCenter }, 1, tableLayoutPanel1.RowCount - 1);
            
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
