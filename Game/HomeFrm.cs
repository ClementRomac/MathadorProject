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
    public partial class HomeFrm : Form
    {
        private string pseudo;
        public HomeFrm(string pseudo)
        {
            this.pseudo = pseudo;
            InitializeComponent();
            homePseudoLabel.Text = "Pseudo : " + pseudo;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
