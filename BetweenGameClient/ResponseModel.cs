using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetweenGameClient
{
    public class LoginResponse
    {
        public string userName { get; set; }
        public string email { get; set; }
        public bool userExist { get; set; }
        public bool isUserActive { get; set; }
    }

    internal class CreateGameResponse
    {
        public string email { get; set; }
        public string gameId { get; set; }
        public string gameName { get; set; }
    }

    internal class GameCreatedByUser
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
    }

    internal class GameAvailableToJoin
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string Email { get; set; }
    }
}
