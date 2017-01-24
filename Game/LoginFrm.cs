using System;
using System.Windows.Forms;

namespace GameInterface
{
    internal partial class LoginFrm : Form
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
