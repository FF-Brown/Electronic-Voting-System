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
    public partial class RegisterMenu : Form
    {
        public string[] mynamearray;
        public string[] mypassarray;

        public RegisterMenu(string[] namearray, string[] passarray)
        {
            InitializeComponent();
            mynamearray = namearray;
            mypassarray = passarray;
        }

        private void LeaveButtonR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterPortal doIt = new WindowsFormsApplication1.RegisterPortal(mynamearray, mypassarray);
            this.Hide();
            doIt.ShowDialog();
            mynamearray = doIt.mynamearray;
            mypassarray = doIt.mypassarray;
            this.Show();
        }
    }
}
