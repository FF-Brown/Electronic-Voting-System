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
    public partial class RegisterForm : Form
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Birthdate { get; set; }
        public string SSN { get; set; }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            this.Name = this.NameBox.Text;
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            this.Password = this.PasswordBox.Text;
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            this.Email = this.EmailBox.Text;
        }

        private void AddressBox_TextChanged(object sender, EventArgs e)
        {
            this.Address = this.AddressBox.Text;
        }

        private void BirthdateBox_TextChanged(object sender, EventArgs e)
        {
            this.Birthdate = this.BirthdateBox.Text;
        }

        private void SSNBox_TextChanged(object sender, EventArgs e)
        {
            this.SSN = this.SSNBox.Text;
        }
    }
}
