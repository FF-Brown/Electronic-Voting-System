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
    public partial class EMSmenu : Form
    {
        private string[] namearray = { "froyo" , "gyro"};
        private string[] passarray = { "boyo", "gal"};
        private string username = "guest";

        public EMSmenu()
        {
           InitializeComponent();
        }

        private void GoToLogin_Click(object sender, EventArgs e)
        {
            LoginMenu doIt = new WindowsFormsApplication1.LoginMenu(namearray, passarray, username);
            this.Hide();
            doIt.ShowDialog();
            username = doIt.myusername;
            this.Show();
            MessageBox.Show(username);
        }

        private void GoToRegister_Click(object sender, EventArgs e)
        {
            RegisterMenu doIt = new WindowsFormsApplication1.RegisterMenu(namearray, passarray);
            this.Hide();
            doIt.ShowDialog();
            namearray = doIt.mynamearray;
            passarray = doIt.mypassarray;
            this.Show();
        }
    }
}
