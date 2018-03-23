using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetweenGameClient
{
    public sealed class LoginResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool UserExist { get; set; }
        public bool IsUserActive { get; set; }
    }

    internal sealed class CreateGameResponse
    {
        public string email { get; set; }
        public string gameId { get; set; }
        public string gameName { get; set; }
    }

    internal sealed class GameCreatedByUser
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
    }

    internal sealed class GameAvailableToJoin
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string Email { get; set; }
    }

    public class InitiateGameResponse
    {
        public string GameId { get; set; }
        public string GameStatus { get; set; }
        public string GameName { get; set; }
    }

    public class JoinGameResponse
    {
        public String PlayerIndex { get; set; }
        public string GameId { get; set; }
        public string GameStatus { get; set; }
        public string GameName { get; set; }
        public List<Player> ConnectedPlayers { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class Player
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PlayerIndex { get; set; }
        public string GameId { get; set; }
        public string GameName { get; set; }
    }
}
