using Framework;
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

        private void Game2_Click(object sender, EventArgs e)
        {
            DialogResult result = slectDrawFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                CreateGame(slectDrawFileDialog.FileName);
            }
        }

        private void Game1_Click(object sender, EventArgs e)
        {

        }

        private void CreateGame(string filePath)
        {
            try
            {
                DAO.FileHandler fileHandler = new DAO.FileHandler(filePath);
                List<Draw> drawList = fileHandler.ReadFile();
                GameFrm gameFrm = new GameFrm(drawList, pseudo);
                Hide();
                gameFrm.ShowDialog();
                Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
