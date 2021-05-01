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
    public partial class RegisterPortal : Form
    {
        public string[] mynamearray;
        public string[] mypassarray;

        public RegisterPortal(string[] namearray, string[] passarray)
        {
            InitializeComponent();
            mynamearray = namearray;
            mypassarray = passarray;
        }

        private void RegButton_Click_1(object sender, EventArgs e)
        {
            Array.Resize(ref mynamearray, mynamearray.Length + 1);
            mynamearray[mynamearray.Length - 1] = NameBox.Text;
            Array.Resize(ref mypassarray, mypassarray.Length + 1); 
            mypassarray[mypassarray.Length - 1] = PasswordBox.Text;
            MessageBox.Show("Added to Pending Registry List!");
            this.Close();
        }
    }
}
