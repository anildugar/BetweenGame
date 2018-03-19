using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Quobject.SocketIoClientDotNet.Client;

namespace BetweenGameClient
{
    public partial class GameView : UserControl
    {
        private LoginResponse loginResponse;
        private Socket clientSocket;

        public GameView(Socket socket, LoginResponse response)
        {
            InitializeComponent();
            loginResponse = response;
            clientSocket = socket;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inviteList.Items.Add(txtInvite.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch(tabGame.SelectedIndex)
            {
                case 0:
                    CreateGame();
                    break;
                case 1:
                    JoinGame();
                    break;
                case 2:
                    break;
            }
        }

        private void JoinGame()
        {
        }

        private async void CreateGame()
        {
            string requestUri = string.Format(Globals.URLWITHPORTNO + "/createGame/");
            HttpClient client = new HttpClient();
            CreateGameRequest request = new CreateGameRequest { gamename = txtGameName.Text, email = loginResponse.email };
            request.invites = new List<string>();
            foreach (ListViewItem invite in inviteList.Items)
                request.invites.Add(invite.Text);
            string serializedRequest = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            CreateGameResponse createGameResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CreateGameResponse>(responseString);
            txtGameName.ReadOnly = true;
            txtGameName.Text = createGameResponse.gameId;
            MessageBox.Show("Game Created Successfully", "Create Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void GameView_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = "Welcome " + loginResponse.userName;

            string requestUri = string.Format(Globals.URLWITHPORTNO + "/gameCreatedByUser/" + loginResponse.email);
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(requestUri);
            var responseString = await response.Content.ReadAsStringAsync();
            List<GameCreatedByUser> gamesPerUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GameCreatedByUser>>(responseString);
            startgameList.DisplayMember = "GameName";
            startgameList.ValueMember = "GameId";
            startgameList.DataSource = gamesPerUser;

            tabGame.SelectedIndex = 1;
            requestUri = string.Format(Globals.URLWITHPORTNO + "/getJoinGamesPerUser/" + loginResponse.email);
            client = new HttpClient();
            response = await client.GetAsync(requestUri);
            responseString = await response.Content.ReadAsStringAsync();
            List<GameAvailableToJoin> joinGamesPerUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GameAvailableToJoin>>(responseString);
            joinGameList.DisplayMember = "GameName";
            joinGameList.ValueMember = "GameId";
            joinGameList.DataSource = joinGamesPerUser;
        }

        private void gameList_DoubleClick(object sender, EventArgs e)
        {
            GameCreatedByUser initiateGame = startgameList.SelectedItem as GameCreatedByUser;
            if (initiateGame != null)
                clientSocket.Emit("initiateGame", new object[] { loginResponse.userName, initiateGame.GameName, initiateGame.GameId });
        }

        private void joinGameList_DoubleClick(object sender, EventArgs e)
        {
            GameAvailableToJoin joinGame = joinGameList.SelectedItem as GameAvailableToJoin;
            if (joinGame != null)
                clientSocket.Emit("joinGame", new object[] { loginResponse.userName, joinGame.GameName, joinGame.GameId });
        }
    }
}
