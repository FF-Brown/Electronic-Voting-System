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
    public partial class LoginForm : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            Username = usernameBox.Text;
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            Password = passwordBox.Text;
        }
    }
}
