using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LoginPortal : Form
    {
        private string[] mynamearray;
        private string[] mypassarray;
        public string myusername;

        public LoginPortal(string[] namearray, string[] passarray, string username)
        {
            InitializeComponent();
            mynamearray = namearray;
            mypassarray = passarray;
            myusername = username;
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < mynamearray.Length && j == 0; i++)
            {
                if (usernameBox.Text == mynamearray[i] && passwordBox.Text == mypassarray[i])
                {
                    myusername = mynamearray[i];
                    j = 1;
                    MessageBox.Show("Logged in successfully!");
                    this.Close();
                }
            }
            if (j == 0)
            {
                MessageBox.Show("Username and Password pairing not found in registered users list!");
                this.Close();
            }       
        }
    }
}
