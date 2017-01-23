using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(loginUsernameTextBox.Text))
            {
                HomeFrm homeFrm = new HomeFrm(loginUsernameTextBox.Text);
                Hide();
                homeFrm.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Username invalide");
            }
        }
    }
}
