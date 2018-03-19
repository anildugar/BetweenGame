using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetweenGameClient
{
    class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    class CreateGameRequest
    {
        public string email { get; set; }
        public string gamename { get; set; }
        public List<string> invites { get; set; }

        public CreateGameRequest()
        {
            invites = new List<string>();
        }
    }

    class GetGamePerUser
    {
        public string email { get; set; }
    }
}
