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
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            this.Size = new Size(this.Parent.Size.Width, this.Parent.Size.Height);
            path.AddEllipse(0, 0, this.Parent.Size.Width - SystemInformation.FrameBorderSize.Width, this.Parent.Size.Height - SystemInformation.FrameBorderSize.Height);
            this.Region = new Region(path);
            this.BackColor = Color.ForestGreen;
        }
    }
}
