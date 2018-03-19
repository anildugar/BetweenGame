using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BetweenGameClient
{
    public partial class GameTable : Form
    {
        public GameTable()
        {
            InitializeComponent();
        }

        private void GameTable_Load(object sender, EventArgs e)
        {
            this.playerPanel.BackColor = Color.Black;
        }

        private void GameTable_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            TextureBrush brush = new TextureBrush(Image.FromFile(@"C:\Users\Admin\Downloads\cards.jpg"));
            e.Graphics.FillEllipse(brush ,new Rectangle(0, 0, this.playerPanel.Width - 2, this.playerPanel.Height));
        }
    }
}
