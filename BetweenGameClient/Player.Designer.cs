namespace BetweenGameClient
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayerName.Location = new System.Drawing.Point(37, 107);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(69, 15);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Player Name";
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPlayerName);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(145, 139);
            this.Load += new System.EventHandler(this.Player_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Player_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
    }
}
