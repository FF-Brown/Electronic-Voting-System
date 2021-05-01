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
    public partial class LoginMenu : Form
    {
        private string[] mynamearray;
        private string[] mypassarray;
        public string myusername;

        public LoginMenu(string[] namearray, string[] passarray, string username)
        {
            InitializeComponent();
            mynamearray = namearray;
            mypassarray = passarray;
            myusername = username;
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginPortal doIt = new WindowsFormsApplication1.LoginPortal(mynamearray, mypassarray, myusername);
            this.Hide();
            doIt.ShowDialog();
            myusername = doIt.myusername;
            this.Show();
        }
    }
}
