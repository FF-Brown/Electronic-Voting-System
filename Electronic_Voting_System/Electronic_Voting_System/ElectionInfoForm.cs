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
            this.EMS = EMS;

            // Fill out all the election info with the info in the EMS

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
            //Dictionary<string, int> demographics = EMS.GetDemographics();
            
            //foreach (var demographic in demographics)
            //{
                //this.tableLayoutPanel1.Controls.ad

            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
