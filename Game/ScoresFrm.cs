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
        public ScoresFrm()
        {
            InitializeComponent();
            DAO.BDDHandler bdd = new DAO.BDDHandler();
            historical = bdd.GetAllGames();
            foreach (Game game in historical)
            {
                ListViewItem currentLvItem = new ListViewItem(
                    new string[] {
                        game.Pseudo,
                        game.gameType.ToString(),
                        game.GetTotalPoints().ToString(),
                        (game.FinishTime - game.BeginTime).ToString(),
                        "3+4"
                    });
            }
        }
    }
}
