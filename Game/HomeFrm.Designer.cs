﻿namespace Game
{
    partial class HomeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeFrm));
            this.homePseudoLabel = new System.Windows.Forms.Label();
            this.newGame1Button = new System.Windows.Forms.Button();
            this.newGame2Button = new System.Windows.Forms.Button();
            this.scoresButton = new System.Windows.Forms.Button();
            this.slectDrawFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // homePseudoLabel
            // 
            this.homePseudoLabel.AutoSize = true;
            this.homePseudoLabel.BackColor = System.Drawing.Color.Transparent;
            this.homePseudoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePseudoLabel.Location = new System.Drawing.Point(12, 9);
            this.homePseudoLabel.Name = "homePseudoLabel";
            this.homePseudoLabel.Size = new System.Drawing.Size(0, 31);
            this.homePseudoLabel.TabIndex = 0;
            this.homePseudoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // newGame1Button
            // 
            this.newGame1Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newGame1Button.BackgroundImage")));
            this.newGame1Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGame1Button.Location = new System.Drawing.Point(231, 71);
            this.newGame1Button.Name = "newGame1Button";
            this.newGame1Button.Size = new System.Drawing.Size(339, 51);
            this.newGame1Button.TabIndex = 2;
            this.newGame1Button.Text = "Game 1";
            this.newGame1Button.UseVisualStyleBackColor = true;
            this.newGame1Button.Click += new System.EventHandler(this.Game1_Click);
            // 
            // newGame2Button
            // 
            this.newGame2Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newGame2Button.BackgroundImage")));
            this.newGame2Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGame2Button.Location = new System.Drawing.Point(231, 148);
            this.newGame2Button.Name = "newGame2Button";
            this.newGame2Button.Size = new System.Drawing.Size(339, 51);
            this.newGame2Button.TabIndex = 3;
            this.newGame2Button.Text = "Game 2";
            this.newGame2Button.UseVisualStyleBackColor = true;
            this.newGame2Button.Click += new System.EventHandler(this.Game2_Click);
            // 
            // scoresButton
            // 
            this.scoresButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scoresButton.BackgroundImage")));
            this.scoresButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scoresButton.Location = new System.Drawing.Point(231, 355);
            this.scoresButton.Name = "scoresButton";
            this.scoresButton.Size = new System.Drawing.Size(339, 51);
            this.scoresButton.TabIndex = 4;
            this.scoresButton.Text = "Scores";
            this.scoresButton.UseVisualStyleBackColor = true;
            // 
            // slectDrawFileDialog
            // 
            this.slectDrawFileDialog.FileName = "drawFile";
            // 
            // HomeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.scoresButton);
            this.Controls.Add(this.newGame2Button);
            this.Controls.Add(this.newGame1Button);
            this.Controls.Add(this.homePseudoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomeFrm";
            this.Text = "Accueil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label homePseudoLabel;
        private System.Windows.Forms.Button newGame1Button;
        private System.Windows.Forms.Button newGame2Button;
        private System.Windows.Forms.Button scoresButton;
        private System.Windows.Forms.OpenFileDialog slectDrawFileDialog;
    }
}

