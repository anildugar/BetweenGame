using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Runtime.InteropServices;
using Quobject.SocketIoClientDotNet.Client;

namespace BetweenGameClient
{
    public class Globals
    {
        public static readonly string PORTNO = "9090";
        public static readonly string URL = "http://127.0.0.1";
        public static readonly string URLWITHPORTNO = URL + ":" + PORTNO;
    }
    public partial class MainForm : Form
    {
        Socket clientsocket;
        public MainForm()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.Parent = tableLayoutPanel1;
            tableLayoutPanel1.Controls.Add(loginForm);
        }

        internal void ShowGameView(LoginResponse loginResponse)
        {
            IO.Options options = new IO.Options { AutoConnect = false };
            //IO.Options options = null;

            clientsocket = IO.Socket(Globals.URLWITHPORTNO,options);
            clientsocket.Connect();

            GameView gameView = new GameView(this, clientsocket, loginResponse);
            gameView.Parent = tableLayoutPanel1;
            tableLayoutPanel1.Controls.Add(gameView);
            this.Size = gameView.MaximumSize;
        }


        internal void ShowTable(LoginResponse loginResponse, JoinGameResponse response)
        {
            GameTable table = new GameTable(loginResponse, response, clientsocket);
            tableLayoutPanel1.Controls.Clear();
            table.Parent = tableLayoutPanel1;
            tableLayoutPanel1.Controls.Add(table);
            this.Size = table.MaximumSize;
        }
    }
}
