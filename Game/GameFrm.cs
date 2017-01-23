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
        private string pseudo;
        private CheckBox operand1;
        private CheckBox operand2;
        private RadioButton operatorRadioButton;
        private GameType type;
        public GameFrm(List<Draw> drawList, string pseudo, GameType type)
        {
            InitializeComponent();
            currentDraw = 0;
            this.pseudo = pseudo;
            this.type = type;
            homePseudoLabel.Text = "Pseudo : " + pseudo;
            game = new Framework.Game(pseudo);
            this.drawList = drawList;
            SetTimer();

            PlayDraw();
        }

        private void PlayDraw()
        {
            if(currentDraw < drawList.Count)
            {
                game.AddDrawResolution(drawList[currentDraw]);
                this.number1.Text = drawList[currentDraw].Numbers[0].ToString();
                this.number2.Text = drawList[currentDraw].Numbers[1].ToString();
                this.number3.Text = drawList[currentDraw].Numbers[2].ToString();
                this.number4.Text = drawList[currentDraw].Numbers[3].ToString();
                this.number5.Text = drawList[currentDraw].Numbers[4].ToString();
                numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Enabled = true);
                numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Show());
                this.goalLabel.Text = drawList[currentDraw].Goal.ToString();
                SetHistoricalAndPoints();               
            }
            else
            {
                if(MessageBox.Show("Partie terminée !", "Bravo !", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    //Insertion BDD
                    HomeFrm homeFrm = new HomeFrm(pseudo);
                    this.Hide();
                    homeFrm.ShowDialog();
                    this.Close();
                }
            }
            
        }

        private void OnOperatorButtonChecked(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                operatorRadioButton = (RadioButton)sender;
            }
            else
            {
                operatorRadioButton = null;
            }

            calculLabel.Text = operand1?.Text + " " + operatorRadioButton?.Text + " " + operand2?.Text;
        }

        private void OnNumberButtonChecked(object sender, EventArgs e)
        {
            CheckBox modifiedCheckbox = ((CheckBox)sender);
            List<CheckBox> numbersButtons = numbersPanel.Controls.OfType<CheckBox>().ToList();
            if (modifiedCheckbox.Checked)
            {
                if(operand1 == null)
                {
                    operand1 = modifiedCheckbox;
                }
                else
                {
                    operand2 = modifiedCheckbox;
                }
            }
            else
            {
                if (operand1 == modifiedCheckbox)
                {
                    operand1 = null;
                }
                else
                {
                    operand2 = null;
                }
            }

            if(!(numbersButtons.Where(b => b.Checked).Count() < 2))
            {
                numbersButtons.Where(b => !b.Checked).ToList().ForEach(b => b.Hide());
            }
            else
            {
                numbersButtons.ForEach(b => b.Show());
            }

            calculLabel.Text = operand1?.Text + " " + operatorRadioButton?.Text + " " + operand2?.Text;
        }

        private void scoresButton_Click(object sender, EventArgs e)
        {
            if(operatorRadioButton != null && operand1 != null && operand2 != null)
            {
                try
                {
                    Stroke currentStroke = new Stroke(
                                Convert.ToInt32(operand1.Text),
                                Convert.ToInt32(operand2.Text),
                                operatorRadioButton.Text[0]
                                );
                    game.AddStroke(currentStroke);
                    operand1.Enabled = false;
                    operand1.Checked = false;
                    operand2.Text = currentStroke.Result.ToString();
                    SetHistoricalAndPoints(currentStroke);

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

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentDraw += 1;
            PlayDraw();
        }

        private void SetTimer()
        {
            switch(type)
            {
                case GameType.AgainstTime:
                    this.timeLabel.Text = "3:00";
                    break;
                case GameType.Fastest:
                    this.timeLabel.Text = "00:00";
                    break;
            }         
        }

        private void SetHistoricalAndPoints(Stroke stroke = null)
        {
            if(stroke != null)
            {
                historicLabel.Text = historicLabel.Text +
                        stroke.FirstOperand.ToString() + " " +
                        stroke.Operator.ToReadableChar() + " " +
                        stroke.SecondOperand.ToString() + " = " +
                        stroke.Result.ToString() + "\n";
            }
            else
            {
                historicLabel.Text = "Coups joués : \n";
            }
          
            this.totalPointsLabel.Text = "Total : " + game.GetTotalPoints();
            this.currentPointsLabel.Text = "Points : " + game.GetCurrentDrawResolutionPoints();
            operand1 = null;
            operand2 = null;
            operatorRadioButton = null;
            numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Checked = false);
            operatorsPanel.Controls.OfType<RadioButton>().ToList().ForEach(b => b.Checked = false);
            calculLabel.Text = operand1?.Text + " " + operatorRadioButton?.Text + " " + operand2?.Text;
        }
    }
}
