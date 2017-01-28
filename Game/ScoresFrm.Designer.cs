using System.Drawing;

namespace GameInterface
{
    partial class ScoresFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoresFrm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.scoresListView = new System.Windows.Forms.ListView();
            this.Details = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pseudo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GameType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalDraw = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalMathador = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalUnreasolved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(324, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(189, 36);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Historique";
            // 
            // scoresListView
            // 
            this.scoresListView.BackColor = System.Drawing.SystemColors.Menu;
            this.scoresListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Details,
            this.Pseudo,
            this.GameType,
            this.Time,
            this.TotalDraw,
            this.TotalPoints,
            this.TotalMathador,
            this.TotalUnreasolved});
            this.scoresListView.GridLines = true;
            this.scoresListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scoresListView.Location = new System.Drawing.Point(12, 64);
            this.scoresListView.MultiSelect = false;
            this.scoresListView.Name = "scoresListView";
            this.scoresListView.Scrollable = false;
            this.scoresListView.ShowGroups = false;
            this.scoresListView.Size = new System.Drawing.Size(773, 374);
            this.scoresListView.TabIndex = 1;
            this.scoresListView.UseCompatibleStateImageBehavior = false;
            this.scoresListView.View = System.Windows.Forms.View.Details;
            this.scoresListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scoresListView_MouseClick);
            // 
            // Details
            // 
            this.Details.Text = "Détails";
            this.Details.Width = 55;
            // 
            // Pseudo
            // 
            this.Pseudo.Text = "Pseudo";
            this.Pseudo.Width = 93;
            // 
            // GameType
            // 
            this.GameType.Text = "Type de partie";
            this.GameType.Width = 100;
            // 
            // Time
            // 
            this.Time.Text = "Temps";
            this.Time.Width = 57;
            // 
            // TotalDraw
            // 
            this.TotalDraw.Text = "Tirages";
            // 
            // TotalPoints
            // 
            this.TotalPoints.Text = "Points";
            this.TotalPoints.Width = 55;
            // 
            // TotalMathador
            // 
            this.TotalMathador.Text = "Mathadors";
            this.TotalMathador.Width = 78;
            // 
            // TotalUnreasolved
            // 
            this.TotalUnreasolved.Text = "Non résolus";
            this.TotalUnreasolved.Width = 86;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(12, 9);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(72, 49);
            this.backButton.TabIndex = 2;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ScoresFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.scoresListView);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScoresFrm";
            this.Text = "Les Scores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListView scoresListView;
        private System.Windows.Forms.ColumnHeader Pseudo;
        private System.Windows.Forms.ColumnHeader GameType;
        private System.Windows.Forms.ColumnHeader TotalPoints;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Details;
        private System.Windows.Forms.ColumnHeader TotalDraw;
        private System.Windows.Forms.ColumnHeader TotalMathador;
        private System.Windows.Forms.ColumnHeader TotalUnreasolved;
        private System.Windows.Forms.Button backButton;
    }
}

