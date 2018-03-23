using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BetweenGameClient
{
    public partial class PlayerControl : UserControl
    {
        public Player Player { get; set; }

        GraphicsPath path;
        public PlayerControl()
        {
            InitializeComponent();
        }

        private string _playerName;
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                lblPlayerName.Text = value;
            }
        }
        private void Player_Load(object sender, EventArgs e)
        {
            path = RoundedRect(new Rectangle(0, 0, this.ClientSize.Width, ClientSize.Height),22);
            this.Region = new Region(path);
            this.BackColor = Color.ForestGreen;
            lblPlayerName.Text = string.Empty;
        }

        private void Player_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerName))
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(5, 5, 10, 10));
            else
                e.Graphics.FillEllipse(Brushes.ForestGreen, new Rectangle(5, 5, 10, 10));
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        
        public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (brush == null)
                throw new ArgumentNullException("brush");

            //using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            //{
            //    TextureBrush b = new TextureBrush(Image.FromFile(@"C:\Users\Admin\Downloads\images (3).jpg"));
            //    graphics.FillPath(b, path);
            //}
        }
    }
}
