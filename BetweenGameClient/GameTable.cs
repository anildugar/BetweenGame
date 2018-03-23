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
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;

namespace BetweenGameClient
{
    public partial class GameTable : UserControl  
    {
        private LoginResponse LoginResponse;

        private JoinGameResponse JoinGameResponse;

        private InitiateGameResponse InitiateGameResponse;

        private Socket ClientSocket;
        public bool CanStartGame { get; set; }
        public string PlayerIndex { get; set; }
        public GameTable()
        {
            InitializeComponent();
        }

        public GameTable(LoginResponse loginResponse, InitiateGameResponse initiateGameResponse, Socket clientSocket)
        {
            LoginResponse = loginResponse;
            InitiateGameResponse = initiateGameResponse;
            this.ClientSocket = clientSocket;
            InitializeComponent();
        }

        public GameTable(LoginResponse loginResponse, JoinGameResponse joinGameResponse, Socket clientSocket)
        {
            LoginResponse = loginResponse;
            JoinGameResponse = joinGameResponse;
            this.ClientSocket = clientSocket;
            InitializeComponent();
        }

        private void GameTable_Load(object sender, EventArgs e)
        {
            HandleSocketMessages();

            this.playerPanel.BackColor = Color.Black;
            bthStartGame.Enabled = CanStartGame;
            if (JoinGameResponse != null)
                JoinGameResponse.ConnectedPlayers.ForEach( player => AllocatePlayerControl(player));
        }

        private void HandleSocketMessages()
        {
            ClientSocket.On("updateConnectedPlayers", (updatePlayers) => { HandleInitiateGameResponse(updatePlayers); });
        }

        internal void HandleInitiateGameResponse(object players)
        {
            List<Player> connectedPlayers = JsonConvert.DeserializeObject<List<Player>>(players.ToString());
            connectedPlayers.ForEach(player => 
                {
                    if (player.PlayerIndex != PlayerIndex)
                        AllocatePlayerControl(player);
                });
        }

        private void AllocatePlayerControl(Player player)
        {
            switch(player.PlayerIndex)
            {
                case "1":
                    player1.Player = player;
                    player1.PlayerName = player.UserName;
                    player1.Invalidate();
                    break;

                case "2":
                    player2.Player = player;
                    player2.PlayerName = player.UserName;
                    player2.Invalidate();

                    break;

                case "3":
                    player3.Player = player;
                    player3.PlayerName = player.UserName;
                    player3.Invalidate();

                    break;

                case "4":
                    player4.Player = player;
                    player4.PlayerName = player.UserName;
                    player4.Invalidate();

                    break;

                case "5":
                    player5.Player = player;
                    player5.PlayerName = player.UserName;
                    player5.Invalidate();

                    break;

                case "6":
                    player6.Player = player;
                    player6.PlayerName = player.UserName;
                    player6.Invalidate();
                    break;
            }
        }

        private void bthStartGame_Click(object sender, EventArgs e)
        {
            ClientSocket.Emit("startGame", JoinGameResponse.GameId, JoinGameResponse.GameName);
        }
    }
}
