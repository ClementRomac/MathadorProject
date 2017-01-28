namespace GameInterface
{
    partial class ScoreDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreDetailsForm));
            this.scoresDetailsTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // scoresDetailsTreeView
            // 
            this.scoresDetailsTreeView.Location = new System.Drawing.Point(13, 13);
            this.scoresDetailsTreeView.Name = "scoresDetailsTreeView";
            this.scoresDetailsTreeView.Size = new System.Drawing.Size(571, 282);
            this.scoresDetailsTreeView.TabIndex = 0;
            // 
            // ScoreDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 307);
            this.Controls.Add(this.scoresDetailsTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScoreDetailsForm";
            this.Text = "Détails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView scoresDetailsTreeView;
    }
}