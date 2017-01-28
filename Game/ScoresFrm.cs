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

namespace GameInterface
{
    internal partial class ScoresFrm : Form
    {
        private List<Game> historical;
        private string pseudo;
        public ScoresFrm(List<Game> historical, string pseudo)
        {
            InitializeComponent();
            this.pseudo = pseudo;
            DAO.BDDHandler bdd = new DAO.BDDHandler();
            //historical = bdd.GetAllGames();
            this.historical = historical;
            foreach (Game game in historical)
            {
                ListViewItem currentLvItem = new ListViewItem(
                    new string[] {
                        "Voir",
                        game.Pseudo,
                        game.gameType.ToReadableString(),
                        game.GetTimeOfGame(),
                        game.Historical.Count.ToString(),
                        game.GetTotalPoints().ToString(),
                        game.Historical.Where(d => d.GetCurrentPoints() == 13).ToList().Count.ToString(),
                        game.Historical.Where(d => !d.IsGoalReached()).ToList().Count.ToString(),
                    });
                scoresListView.Items.Add(currentLvItem);
            }
        }

        private void scoresListView_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedItem = scoresListView.SelectedItems[0].Index;
            ScoreDetailsForm detailsForm = new ScoreDetailsForm(historical[selectedItem]);
            detailsForm.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            HomeFrm homeFrm = new HomeFrm(pseudo);
            this.Hide();
            homeFrm.ShowDialog();
            this.Close();
        }
    }
}
