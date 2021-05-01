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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int loginResult = showLoginMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // int registerResult = showRegisterMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // show Election Info
            // ElectionInfo info = EMS.getElectionInfo();
            ElectionInfoForm infoForm = new ElectionInfoForm();
            infoForm.Show();
        }
    }
}
