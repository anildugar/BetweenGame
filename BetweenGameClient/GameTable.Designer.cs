namespace BetweenGameClient
{
    partial class GameTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameTable));
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.player6 = new BetweenGameClient.Player();
            this.player5 = new BetweenGameClient.Player();
            this.player4 = new BetweenGameClient.Player();
            this.player3 = new BetweenGameClient.Player();
            this.player2 = new BetweenGameClient.Player();
            this.player1 = new BetweenGameClient.Player();
            this.gamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.pointsPerPlayerList = new System.Windows.Forms.ListView();
            this.cardPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.playerPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.cardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.74501F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.25499F));
            this.mainPanel.Controls.Add(this.playerPanel, 0, 0);
            this.mainPanel.Controls.Add(this.gamePanel, 1, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 631F));
            this.mainPanel.Size = new System.Drawing.Size(1353, 631);
            this.mainPanel.TabIndex = 0;
            // 
            // playerPanel
            // 
            this.playerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerPanel.Controls.Add(this.player6);
            this.playerPanel.Controls.Add(this.player5);
            this.playerPanel.Controls.Add(this.player4);
            this.playerPanel.Controls.Add(this.player3);
            this.playerPanel.Controls.Add(this.player2);
            this.playerPanel.Controls.Add(this.player1);
            this.playerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerPanel.Location = new System.Drawing.Point(3, 3);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(869, 625);
            this.playerPanel.TabIndex = 0;
            this.playerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // player6
            // 
            this.player6.BackColor = System.Drawing.Color.ForestGreen;
            this.player6.Location = new System.Drawing.Point(214, 7);
            this.player6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.player6.Name = "player6";
            this.player6.Size = new System.Drawing.Size(169, 182);
            this.player6.TabIndex = 11;
            // 
            // player5
            // 
            this.player5.BackColor = System.Drawing.Color.ForestGreen;
            this.player5.Location = new System.Drawing.Point(214, 426);
            this.player5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.player5.Name = "player5";
            this.player5.Size = new System.Drawing.Size(169, 182);
            this.player5.TabIndex = 10;
            // 
            // player4
            // 
            this.player4.BackColor = System.Drawing.Color.ForestGreen;
            this.player4.Location = new System.Drawing.Point(493, 426);
            this.player4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.player4.Name = "player4";
            this.player4.Size = new System.Drawing.Size(169, 182);
            this.player4.TabIndex = 9;
            // 
            // player3
            // 
            this.player3.BackColor = System.Drawing.Color.ForestGreen;
            this.player3.Location = new System.Drawing.Point(691, 219);
            this.player3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.player3.Name = "player3";
            this.player3.Size = new System.Drawing.Size(169, 182);
            this.player3.TabIndex = 8;
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.ForestGreen;
            this.player2.Location = new System.Drawing.Point(493, 7);
            this.player2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(169, 182);
            this.player2.TabIndex = 7;
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.ForestGreen;
            this.player1.Location = new System.Drawing.Point(6, 219);
            this.player1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(169, 182);
            this.player1.TabIndex = 6;
            // 
            // gamePanel
            // 
            this.gamePanel.ColumnCount = 1;
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.05932F));
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.94068F));
            this.gamePanel.Controls.Add(this.cardPanel, 0, 0);
            this.gamePanel.Controls.Add(this.pointsPerPlayerList, 0, 1);
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(878, 3);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.RowCount = 4;
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.49123F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.50877F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.gamePanel.Size = new System.Drawing.Size(472, 625);
            this.gamePanel.TabIndex = 1;
            // 
            // pointsPerPlayerList
            // 
            this.pointsPerPlayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointsPerPlayerList.GridLines = true;
            this.pointsPerPlayerList.Location = new System.Drawing.Point(3, 215);
            this.pointsPerPlayerList.Name = "pointsPerPlayerList";
            this.pointsPerPlayerList.Size = new System.Drawing.Size(466, 238);
            this.pointsPerPlayerList.TabIndex = 1;
            this.pointsPerPlayerList.UseCompatibleStateImageBehavior = false;
            this.pointsPerPlayerList.View = System.Windows.Forms.View.List;
            // 
            // cardPanel
            // 
            this.cardPanel.ColumnCount = 3;
            this.cardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.cardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.cardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.cardPanel.Controls.Add(this.panel1, 0, 0);
            this.cardPanel.Controls.Add(this.panel2, 1, 0);
            this.cardPanel.Controls.Add(this.panel3, 2, 0);
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(3, 3);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.RowCount = 1;
            this.cardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardPanel.Size = new System.Drawing.Size(466, 206);
            this.cardPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 200);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(158, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 200);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(313, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 200);
            this.panel3.TabIndex = 2;
            // 
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1353, 631);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "GameTable";
            this.Text = "GameTable";
            this.Load += new System.EventHandler(this.GameTable_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameTable_Paint);
            this.mainPanel.ResumeLayout(false);
            this.playerPanel.ResumeLayout(false);
            this.gamePanel.ResumeLayout(false);
            this.cardPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel playerPanel;
        private Player player6;
        private Player player5;
        private Player player4;
        private Player player3;
        private Player player2;
        private Player player1;
        private System.Windows.Forms.TableLayoutPanel gamePanel;
        private System.Windows.Forms.ListView pointsPerPlayerList;
        private System.Windows.Forms.TableLayoutPanel cardPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}