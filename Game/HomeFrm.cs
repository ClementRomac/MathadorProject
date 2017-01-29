using Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameInterface
{
    internal partial class HomeFrm : Form
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
            CreateGame(GameType.Fastest);
        }

        private void Game1_Click(object sender, EventArgs e)
        {
            CreateGame(GameType.AgainstTime);
        }

        private void CreateGame(GameType type)
        {
            selectDrawFileDialog.Filter = "json files (*.json)|*.json";
            selectDrawFileDialog.RestoreDirectory = true;
            DialogResult result = selectDrawFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    DAO.FileHandler fileHandler = new DAO.FileHandler(selectDrawFileDialog.FileName);
                    List<Draw> drawList = fileHandler.ReadFile();
                    GameFrm gameFrm = new GameFrm(drawList, pseudo, type);
                    Hide();
                    gameFrm.ShowDialog();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        private void scoresButton_Click(object sender, EventArgs e)
        {
            ScoresFrm scoresFrm = new ScoresFrm(pseudo);
            Hide();
            scoresFrm.ShowDialog();
            Close();
        }
    }
}
