
var userService = require('./UserService.js');
var Hashtable = require('hashtable');
var startedGames = new Hashtable();
var usersPerGame = new Hashtable();

function onClientConnected(io, socket)
{
    socket.on('initiateGame', function (userName, gameName, gameId) {
        onInitiateGame(io, socket, userName, gameName, gameId);
    });

    socket.on('joinGame', function (userName, email, gameName, gameId) {
        onJoinGame(io, socket, userName, email, gameName, gameId);
    });

    socket.on('startGame', function (gameId, gameName)
    {
        onStartGame(io, socket, gameId, gameName);        
    });
}

function onStartGame(io, socket, gameId, gameName)
{
    if (!startedGames.has(gameId))
    {
        startedGames[gameId] = gameId;
        socket.emit('startGameResponse', g);
    }
}

function onInitiateGame(io, socket, userName, gameName, gameId)
{
    socket.userName = userName;
    console.log(userName + " Initiated " + gameName);
    userService.gameCollection.update(
        { 'GameId': gameId },
        { $set: { 'Status': true } },
        function (error, result)
        {
            var g = new InitiateGameResponse(gameId, gameName, true);
            socket.emit('initiateGameResponse', g);
            socket.join(gameId);
        });
        
}

class InitiateGameResponse
{
    constructor(gameId, gameName, started) {
        this.GameId = gameId;
        this.GameStatus = started;
        this.GameName = gameName;
    }
}

function onJoinGame(io, socket, userName, emailId, gameName, gameId)
{
    //If the game is started, a user cannot join in-between

    if (!startedGames.has(gameId)) {
        console.log(userName + " Joined " + gameName);
        userService.gameCollection.findOne({ "GameId": gameId }, (error, doc) => {
            var userList = [];
            var playerIndex = 1;
            if (!usersPerGame.has(gameId)) {
                var player = new Player(emailId, playerIndex, userName, gameId, gameName);
                userList.push(player);
                usersPerGame.put(gameId, userList);
                socket.player = player;
            }
            else
            {
                userList = usersPerGame.get(gameId);
                playerIndex = userList.length + 1;
                var player = new Player(emailId, playerIndex, userName, gameId, gameName);
                userList.push(player);
                socket.player = player;
            }

            var joinGameResponse = new JoinGameResponse(playerIndex, gameId, gameName, doc.Status, userList, "");
            socket.emit('joinGameResponse', joinGameResponse);
            socket.join(gameId);
            var newUser = new NewUserJoinedResponse(gameId, userName);
            //io.to(gameId).emit('updateConnectedPlayers', userList);
            if(userList.length > 1)
                socket.broadcast.to(gameId).emit('updateConnectedPlayers', userList);
            //{
            //    var clients = io.sockets.adapter.rooms[gameId].sockets;

            //    for (var clientId in clients) {

            //        //this is the socket of each client in the room.
            //        var clientSocket = io.sockets.connected[clientId];
            //        //console.log(clientSocket.userName);
            //        //you can do whatever you need with this
            //        clientSocket.emit('updatePlayers', userList);

            //    }
            //}
            //console.log("Users in a room +", gameId);
        });
    }
    else
    {
        var joinGameResponse = new JoinGameResponse(gameId, gameName, doc.Status, "Game is already started, Hence cannot join now");
        socket.emit('joinGameResponse', joinGameResponse);
    }
}

class NewUserJoinedResponse 
{
    constructor(gameId, userName) {
        this.GameId = gameId;
        this.UserName = userName;
    }
}

class JoinGameResponse {
    constructor(playerIndex, gameId, gameName, started, connectedPlayers, errorMsg) {
        this.PlayerIndex = playerIndex;
        this.GameId = gameId;
        this.GameStatus = started;
        this.GameName = gameName;
        this.ErrorMsg = errorMsg;
        this.ConnectedPlayers = connectedPlayers;
    }
}

class Player
{
    constructor(emailId, playerIndex, username, gameId, gameName)
    {
        this.Email = emailId;
        this.PlayerIndex = playerIndex;
        this.UserName = username;
        this.GameId = gameId;
        this.GameName = gameName;
    }
}
module.exports.onClientConnected = onClientConnected;
