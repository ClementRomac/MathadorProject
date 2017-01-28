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
    internal partial class ScoreDetailsForm : Form
    {
        private Game game;
        public ScoreDetailsForm(Game game)
        {
            InitializeComponent();
            this.game = game;
            foreach (DrawResolution drawResolution in game.Historical)
            {
                TreeNode currentNode = new TreeNode(drawResolution.Draw.ToString() +
                    " - Points : " + drawResolution.GetCurrentPoints().ToString());
                foreach (Stroke stroke in drawResolution.Strokes)
                {
                    currentNode.Nodes.Add(stroke.ToString());
                }

                scoresDetailsTreeView.Nodes.Add(currentNode);
            }
        }
    }
}
