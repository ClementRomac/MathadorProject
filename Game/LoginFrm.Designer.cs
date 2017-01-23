namespace Game
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.loginTitleLabel = new System.Windows.Forms.Label();
            this.loginUsernameTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTitleLabel
            // 
            this.loginTitleLabel.AutoSize = true;
            this.loginTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTitleLabel.Location = new System.Drawing.Point(235, 42);
            this.loginTitleLabel.Name = "loginTitleLabel";
            this.loginTitleLabel.Size = new System.Drawing.Size(351, 31);
            this.loginTitleLabel.TabIndex = 0;
            this.loginTitleLabel.Text = "Veuillez entrer un username";
            // 
            // loginUsernameTextBox
            // 
            this.loginUsernameTextBox.Location = new System.Drawing.Point(309, 109);
            this.loginUsernameTextBox.Name = "loginUsernameTextBox";
            this.loginUsernameTextBox.Size = new System.Drawing.Size(177, 22);
            this.loginUsernameTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginButton.BackgroundImage")));
            this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginButton.Location = new System.Drawing.Point(309, 216);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(177, 51);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Entrer !";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginUsernameTextBox);
            this.Controls.Add(this.loginTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginFrm";
            this.Text = "Accueil";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginFrm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginTitleLabel;
        private System.Windows.Forms.TextBox loginUsernameTextBox;
        private System.Windows.Forms.Button loginButton;
    }
}

