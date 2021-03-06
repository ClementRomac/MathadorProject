﻿using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameInterface
{
    internal partial class GameFrm : Form
    {
        private List<Draw> drawList;
        private int currentDraw;

        private List<List<DrawResolution>> solutionsOfDraws;

        private Game game;
        private string pseudo;

        private CheckBox operand1;
        private CheckBox operand2;
        private RadioButton operatorRadioButton;

        private GameType gameType;
        private DateTime referentTime;
        private Timer timer;

        public GameFrm(List<Draw> drawList, string pseudo, GameType gameType)
        {
            InitializeComponent();
            currentDraw = 0;
            solutionsOfDraws = new List<List<DrawResolution>>();
            this.pseudo = pseudo;
            this.gameType = gameType;
            homePseudoLabel.Text = "Pseudo : " + pseudo;
            game = new Game(pseudo, gameType);
            this.drawList = drawList;
            SetTimer();

            PlayDraw();
        }

        private void PlayDraw()
        {
            if(currentDraw < drawList.Count)
            {
                game.AddDrawResolution(drawList[currentDraw]);
                //Task.Factory.StartNew(() => GetDrawSolutions());
                number1.Text = drawList[currentDraw].Numbers[0].ToString();
                number2.Text = drawList[currentDraw].Numbers[1].ToString();
                number3.Text = drawList[currentDraw].Numbers[2].ToString();
                number4.Text = drawList[currentDraw].Numbers[3].ToString();
                number5.Text = drawList[currentDraw].Numbers[4].ToString();
                numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Enabled = true);
                numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Show());
                numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Tag = null);
                goalLabel.Text = drawList[currentDraw].Goal.ToString();
                remainingDraws.Text = (drawList.Count - currentDraw - 1).ToString() + " Restants";
                SetHistorical();
                this.totalPointsLabel.Text = "Points : " + game.GetTotalPoints();  
            }
            else
            {
                FinishGame();
            }
            
        }

        private void GetDrawSolutions()
        {
            List<DrawResolution> currentDrawSolutions = Solver.DrawSolver.GetSolutions(drawList[currentDraw]);
            solutionsOfDraws.Add(currentDrawSolutions);
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
                    int result = currentStroke.Result;
                    if(operand1.Tag != null && operand1.Tag.GetType() == typeof(Stroke))
                    {
                        if(operand2.Tag != null && operand2.Tag.GetType() == typeof(Stroke))
                        {
                            game.AddStroke(currentStroke, (Stroke)operand1.Tag, (Stroke)operand2.Tag);
                        }
                        else
                        {
                            game.AddStroke(currentStroke, (Stroke)operand1.Tag);
                        }
                        
                    }
                    else if(operand2.Tag != null && operand2.Tag.GetType() == typeof(Stroke))
                    {
                        game.AddStroke(currentStroke, (Stroke)operand2.Tag);
                    }
                    else
                    {
                        game.AddStroke(currentStroke);
                    }

                    operand1.Enabled = false;
                    operand1.Checked = false;
                    operand2.Text = result.ToString();
                    operand2.Tag = currentStroke;
                    SetHistorical(currentStroke);

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
            timer = new Timer();
            timer.Interval = 1000; // tick each second
            timer.Tick += new EventHandler(timer_Tick);          
            
            DateTime now = DateTime.Now;
            switch (gameType)
            {
                case GameType.AgainstTime:
                    referentTime = now.AddMinutes(3);
                    this.timeLabel.Text = (referentTime - now).ToString("mm\\:ss");
                    break;
                case GameType.Fastest:
                    referentTime = now;
                    this.timeLabel.Text = (now - referentTime).ToString("mm\\:ss");
                    break;
            }

            game.BeginTime = now;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if(gameType == GameType.AgainstTime)
            {
                TimeSpan remainingTime = (referentTime - now);
                this.timeLabel.Text = remainingTime.ToString("mm\\:ss");

                if (remainingTime < new TimeSpan(0, 0, 1))
                {
                    FinishGame();
                }
                else if(remainingTime < new TimeSpan(0, 0, 10))
                {
                    Blink();
                }
                
            }
            else if(gameType == GameType.Fastest)
            {
                this.timeLabel.Text = (now - referentTime).ToString("mm\\:ss");
            }
        }

        private async void Blink()
        {
            this.timeLabel.ForeColor = Color.Red;
            await Task.Delay(250);
            this.timeLabel.ForeColor = Color.Black;
        }

        private void SetHistorical(Stroke stroke = null)
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
          
            operand1 = null;
            operand2 = null;
            operatorRadioButton = null;
            numbersPanel.Controls.OfType<CheckBox>().ToList().ForEach(b => b.Checked = false);
            operatorsPanel.Controls.OfType<RadioButton>().ToList().ForEach(b => b.Checked = false);
            calculLabel.Text = operand1?.Text + " " + operatorRadioButton?.Text + " " + operand2?.Text;
        }

        private void FinishGame()
        {
            game.FinishTime = DateTime.Now;
            ((Timer)timer).Stop();
            this.timeLabel.ForeColor = Color.Red;
            for (int i = currentDraw + 1; i < drawList.Count; i++)
            {
                game.AddDrawResolution(drawList[i]);
            }

            SaveResultsInBDD();

            if (MessageBox.Show("Partie terminée !", "Bravo !", MessageBoxButtons.OK) == DialogResult.OK)
            {
                HomeFrm homeFrm = new HomeFrm(pseudo);
                this.Hide();
                homeFrm.ShowDialog();
                this.Close();
            }
        }

        private void SaveResultsInBDD()
        {
            DAO.BDDHandler bdd = new DAO.BDDHandler();
            try
            {
                bdd.WriteGame(game);
            }
            catch(Exception ex) { }
           
        }
    }
}
