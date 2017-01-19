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
    public partial class GameFrm : Form
    {
        private List<Draw> drawList;
        private int currentDraw;
        private Framework.Game game;
        public GameFrm(List<Draw> drawList, string pseudo)
        {
            InitializeComponent();
            currentDraw = 0;
            homePseudoLabel.Text = "Pseudo : " + pseudo;
            game = new Framework.Game(pseudo);
            this.drawList = drawList;
            this.timeLabel.Text = "3:12";

            PlayDraw();
        }

        private void PlayDraw()
        {
            game.AddDrawResolution(drawList[currentDraw]);
            this.number1.Text = drawList[0].Numbers[0].ToString();
            this.number2.Text = drawList[0].Numbers[1].ToString();
            this.number3.Text = drawList[0].Numbers[2].ToString();
            this.number4.Text = drawList[0].Numbers[3].ToString();
            this.number5.Text = drawList[0].Numbers[4].ToString();
            numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Enabled = true);
            this.goalLabel.Text = drawList[currentDraw].Goal.ToString();
            this.totalPointsLabel.Text = "Total : " + game.GetTotalPoints();
            this.currentPointsLabel.Text = "Points : " + game.GetCurrentDrawResolutionPoints();
        }

        private void OnNumberButtonChecked(object sender, EventArgs e)
        {
            List<CheckBox> numbersButtons = numbersPanel.Controls.OfType<CheckBox>().ToList();
            if(!(numbersButtons.Where(b => b.Checked).Count() < 2))
            {
                numbersButtons.Where(b => !b.Checked).ToList().ForEach(b => b.Hide());
            }
            else
            {
                numbersButtons.ForEach(b => b.Show());
            }
        }

        private void scoresButton_Click(object sender, EventArgs e)
        {
            List<CheckBox> numbersButtons = numbersPanel.Controls.OfType<CheckBox>().ToList().Where(b => b.Checked).ToList();
            RadioButton operatorButton = operatorsPanel.Controls.OfType<RadioButton>().ToList().Where(b => b.Checked).FirstOrDefault();

            if(operatorButton != null && numbersButtons.Count == 2)
            {
                try
                {
                    Stroke currentStroke = new Stroke(
                                Convert.ToInt32(numbersButtons[0].Text),
                                Convert.ToInt32(numbersButtons[1].Text),
                                operatorButton.Text[0]
                                );
                    game.AddStroke(currentStroke);
                    numbersButtons[0].Enabled = false;
                    numbersButtons[0].Checked = false;
                    numbersButtons[1].Text = currentStroke.Result.ToString();
                    historicLabel.Text = historicLabel.Text +
                        currentStroke.FirstOperand.ToString() + " " +
                        currentStroke.Operator.ToReadableChar() + " " +
                        currentStroke.SecondOperand.ToString() + " = " +
                        currentStroke.Result.ToString() + "\n";
                    this.totalPointsLabel.Text = "Total : " + game.GetTotalPoints();
                    this.currentPointsLabel.Text = "Points : " + game.GetCurrentDrawResolutionPoints();

                    if (game.IsCurrentDrawResolutionFinished())
                    {
                        currentDraw += 1;
                        this.PlayDraw();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un opérateur et deux nombres");
            }
            
        }
    }
}
