using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quobject.SocketIoClientDotNet.Client;

namespace BetweenGameClient
{
    class ClientSocketMessages
    {
        private Socket clientSocket;
        public ClientSocketMessages(Socket socket)
        {
            clientSocket = socket;

            clientSocket.On("joinGameResponse", (response) => { System.Windows.Forms.MessageBox.Show("Join Game Response Recieved"); });
        }
    }
}
