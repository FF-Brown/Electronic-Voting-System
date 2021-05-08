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
    public partial class VotingForm : Form
    {
        private ElectionManagementSystem EMS;
        User currentUser;
        public VotingForm(ElectionManagementSystem EMS, User currentUser)
        {
            InitializeComponent();
            this.EMS = EMS;
            this.currentUser = currentUser;

            // First fill out the candidate list
            List<Candidate> candidateList = EMS.GetCandidates();
            foreach (var candidate in candidateList)
            {
                listBox1.Items.Add(candidate.name + ": " + candidate.total_votes);
            }
        }

        /// <summary>
        /// Method that updates the candidate list
        /// </summary>
        public void updateCandidateList()
        {
            List<Candidate> candidateList = EMS.GetCandidates();
            foreach (var candidate in candidateList)
            {
                listBox1.Items.Add(candidate.name + ": " + candidate.total_votes);
            }
        }

        /// <summary>
        /// Voting button method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Voting button clicked
            int index = listBox1.SelectedIndex;
            string candidateString;
            string[] candidateStringSplit;
            string candidateName;
            if(index != -1)
            {
                // if an index on the candidate list is selected
                // Get the candidate
                candidateString = listBox1.Items[index].ToString();
                candidateStringSplit = candidateString.Split(':');
                candidateName = candidateStringSplit[0];

                if (!currentUser.getHasVoted())
                {
                    // if the current user has not voted
                    EMS.Vote(candidateName); // IMPLEMENT THIS
                    currentUser.setHasVoted(true);
                    updateCandidateList();
                }

            }
        }
    }
}
