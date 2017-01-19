using System.Drawing;

namespace Game
{
    partial class GameFrm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameFrm));
            this.scoresButton = new System.Windows.Forms.Button();
            this.homePseudoLabel = new System.Windows.Forms.Label();
            this.totalPointsLabel = new System.Windows.Forms.Label();
            this.currentPointsLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.goalLabel = new System.Windows.Forms.Label();
            this.numbersPanel = new System.Windows.Forms.Panel();
            this.number5 = new System.Windows.Forms.CheckBox();
            this.number4 = new System.Windows.Forms.CheckBox();
            this.number3 = new System.Windows.Forms.CheckBox();
            this.number2 = new System.Windows.Forms.CheckBox();
            this.number1 = new System.Windows.Forms.CheckBox();
            this.operatorsPanel = new System.Windows.Forms.Panel();
            this.divideButton = new System.Windows.Forms.RadioButton();
            this.multiplyButton = new System.Windows.Forms.RadioButton();
            this.minusButton = new System.Windows.Forms.RadioButton();
            this.plusButton = new System.Windows.Forms.RadioButton();
            this.historicLabel = new System.Windows.Forms.Label();
            this.numbersPanel.SuspendLayout();
            this.operatorsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // scoresButton
            // 
            this.scoresButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scoresButton.BackgroundImage")));
            this.scoresButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scoresButton.Location = new System.Drawing.Point(295, 362);
            this.scoresButton.Name = "scoresButton";
            this.scoresButton.Size = new System.Drawing.Size(185, 76);
            this.scoresButton.TabIndex = 4;
            this.scoresButton.Text = "Calculer";
            this.scoresButton.UseVisualStyleBackColor = true;
            this.scoresButton.Click += new System.EventHandler(this.scoresButton_Click);
            // 
            // homePseudoLabel
            // 
            this.homePseudoLabel.AutoSize = true;
            this.homePseudoLabel.BackColor = System.Drawing.Color.Transparent;
            this.homePseudoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePseudoLabel.Location = new System.Drawing.Point(12, 9);
            this.homePseudoLabel.Name = "homePseudoLabel";
            this.homePseudoLabel.Size = new System.Drawing.Size(0, 29);
            this.homePseudoLabel.TabIndex = 14;
            this.homePseudoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // totalPointsLabel
            // 
            this.totalPointsLabel.AutoSize = true;
            this.totalPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPointsLabel.Location = new System.Drawing.Point(12, 52);
            this.totalPointsLabel.Name = "totalPointsLabel";
            this.totalPointsLabel.Size = new System.Drawing.Size(0, 29);
            this.totalPointsLabel.TabIndex = 15;
            this.totalPointsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentPointsLabel
            // 
            this.currentPointsLabel.AutoSize = true;
            this.currentPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPointsLabel.Location = new System.Drawing.Point(646, 52);
            this.currentPointsLabel.Name = "currentPointsLabel";
            this.currentPointsLabel.Size = new System.Drawing.Size(0, 29);
            this.currentPointsLabel.TabIndex = 17;
            this.currentPointsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(646, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 29);
            this.timeLabel.TabIndex = 16;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goalLabel
            // 
            this.goalLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.goalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalLabel.Location = new System.Drawing.Point(345, 19);
            this.goalLabel.Name = "goalLabel";
            this.goalLabel.Size = new System.Drawing.Size(90, 90);
            this.goalLabel.TabIndex = 27;
            this.goalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numbersPanel
            // 
            this.numbersPanel.BackColor = System.Drawing.Color.Transparent;
            this.numbersPanel.Controls.Add(this.number5);
            this.numbersPanel.Controls.Add(this.number4);
            this.numbersPanel.Controls.Add(this.number3);
            this.numbersPanel.Controls.Add(this.number2);
            this.numbersPanel.Controls.Add(this.number1);
            this.numbersPanel.Location = new System.Drawing.Point(93, 152);
            this.numbersPanel.Name = "numbersPanel";
            this.numbersPanel.Size = new System.Drawing.Size(597, 90);
            this.numbersPanel.TabIndex = 28;
            // 
            // number5
            // 
            this.number5.Appearance = System.Windows.Forms.Appearance.Button;
            this.number5.BackColor = System.Drawing.SystemColors.Control;
            this.number5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number5.Location = new System.Drawing.Point(507, 0);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(90, 90);
            this.number5.TabIndex = 27;
            this.number5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number5.UseVisualStyleBackColor = false;
            this.number5.CheckedChanged += new System.EventHandler(this.OnNumberButtonChecked);
            // 
            // number4
            // 
            this.number4.Appearance = System.Windows.Forms.Appearance.Button;
            this.number4.BackColor = System.Drawing.SystemColors.Control;
            this.number4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number4.Location = new System.Drawing.Point(379, 0);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(90, 90);
            this.number4.TabIndex = 26;
            this.number4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number4.UseVisualStyleBackColor = false;
            this.number4.CheckedChanged += new System.EventHandler(this.OnNumberButtonChecked);
            // 
            // number3
            // 
            this.number3.Appearance = System.Windows.Forms.Appearance.Button;
            this.number3.BackColor = System.Drawing.SystemColors.Control;
            this.number3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number3.Location = new System.Drawing.Point(252, 0);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(90, 90);
            this.number3.TabIndex = 25;
            this.number3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number3.UseVisualStyleBackColor = false;
            this.number3.CheckedChanged += new System.EventHandler(this.OnNumberButtonChecked);
            // 
            // number2
            // 
            this.number2.Appearance = System.Windows.Forms.Appearance.Button;
            this.number2.BackColor = System.Drawing.SystemColors.Control;
            this.number2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number2.Location = new System.Drawing.Point(124, 0);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(90, 90);
            this.number2.TabIndex = 24;
            this.number2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number2.UseVisualStyleBackColor = false;
            this.number2.CheckedChanged += new System.EventHandler(this.OnNumberButtonChecked);
            // 
            // number1
            // 
            this.number1.Appearance = System.Windows.Forms.Appearance.Button;
            this.number1.BackColor = System.Drawing.SystemColors.Control;
            this.number1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number1.Location = new System.Drawing.Point(0, 0);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(90, 90);
            this.number1.TabIndex = 23;
            this.number1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number1.UseVisualStyleBackColor = false;
            this.number1.CheckedChanged += new System.EventHandler(this.OnNumberButtonChecked);
            // 
            // operatorsPanel
            // 
            this.operatorsPanel.BackColor = System.Drawing.Color.Transparent;
            this.operatorsPanel.Controls.Add(this.divideButton);
            this.operatorsPanel.Controls.Add(this.multiplyButton);
            this.operatorsPanel.Controls.Add(this.minusButton);
            this.operatorsPanel.Controls.Add(this.plusButton);
            this.operatorsPanel.Location = new System.Drawing.Point(197, 266);
            this.operatorsPanel.Name = "operatorsPanel";
            this.operatorsPanel.Size = new System.Drawing.Size(381, 70);
            this.operatorsPanel.TabIndex = 29;
            // 
            // divideButton
            // 
            this.divideButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.divideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divideButton.Location = new System.Drawing.Point(311, 0);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(70, 70);
            this.divideButton.TabIndex = 34;
            this.divideButton.TabStop = true;
            this.divideButton.Text = "/";
            this.divideButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.divideButton.UseVisualStyleBackColor = true;
            // 
            // multiplyButton
            // 
            this.multiplyButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.multiplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplyButton.Location = new System.Drawing.Point(208, 0);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(70, 70);
            this.multiplyButton.TabIndex = 33;
            this.multiplyButton.TabStop = true;
            this.multiplyButton.Text = "*";
            this.multiplyButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.multiplyButton.UseVisualStyleBackColor = true;
            // 
            // minusButton
            // 
            this.minusButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minusButton.Location = new System.Drawing.Point(104, 0);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(70, 70);
            this.minusButton.TabIndex = 32;
            this.minusButton.TabStop = true;
            this.minusButton.Text = "-";
            this.minusButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minusButton.UseVisualStyleBackColor = true;
            // 
            // plusButton
            // 
            this.plusButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.plusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusButton.Location = new System.Drawing.Point(0, 0);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(70, 70);
            this.plusButton.TabIndex = 31;
            this.plusButton.TabStop = true;
            this.plusButton.Text = "+";
            this.plusButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.plusButton.UseVisualStyleBackColor = true;
            // 
            // historicLabel
            // 
            this.historicLabel.AutoSize = true;
            this.historicLabel.BackColor = System.Drawing.Color.Transparent;
            this.historicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historicLabel.Location = new System.Drawing.Point(12, 307);
            this.historicLabel.Name = "historicLabel";
            this.historicLabel.Size = new System.Drawing.Size(0, 20);
            this.historicLabel.TabIndex = 30;
            this.historicLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.historicLabel);
            this.Controls.Add(this.goalLabel);
            this.Controls.Add(this.currentPointsLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.totalPointsLabel);
            this.Controls.Add(this.homePseudoLabel);
            this.Controls.Add(this.scoresButton);
            this.Controls.Add(this.numbersPanel);
            this.Controls.Add(this.operatorsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameFrm";
            this.Text = "Partie";
            this.numbersPanel.ResumeLayout(false);
            this.operatorsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button scoresButton;
        private System.Windows.Forms.Label homePseudoLabel;
        private System.Windows.Forms.Label totalPointsLabel;
        private System.Windows.Forms.Label currentPointsLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label goalLabel;
        private System.Windows.Forms.Panel numbersPanel;
        private System.Windows.Forms.Panel operatorsPanel;
        private System.Windows.Forms.CheckBox number5;
        private System.Windows.Forms.CheckBox number4;
        private System.Windows.Forms.CheckBox number3;
        private System.Windows.Forms.CheckBox number2;
        private System.Windows.Forms.CheckBox number1;
        private System.Windows.Forms.RadioButton plusButton;
        private System.Windows.Forms.RadioButton minusButton;
        private System.Windows.Forms.RadioButton divideButton;
        private System.Windows.Forms.RadioButton multiplyButton;
        private System.Windows.Forms.Label historicLabel;
    }
}

