
var userService = require('./UserService.js');
var Hashtable = require('hashtable');
var startedGames = new Hashtable();
var playerIndexPerGame = new Hashtable();
var playerListPerGame = new Hashtable();
var Stack = require('stackjs');
var ArrayList = require('arraylist');
var gameService = require('./GameService');

function onClientConnected(io, socket)
{
    socket.on('initiateGame', function (userName, email, gameName, gameId) {
        onInitiateGame(io, socket, userName, email, gameName, gameId);
    });

    socket.on('joinGame', function (userName, email, gameName, gameId) {
        onJoinGame(io, socket, userName, email, gameName, gameId);
    });

    socket.on('startGame', function (gameId, gameName) {
        onStartGame(io, socket, gameId, gameName);        
    });

    socket.on('removeUserFromGame', function (email, gameId, playerIndex) {
        onRemoveUserFromGame(io, socket, email, gameId, playerIndex);
    });

    socket.on('sendCardToPlayer', function (gameId, playerIndex) {
        sendCardToPlayer(io, socket, gameId, playerIndex);
    });

    socket.on('sendTrumpCard', function(gameId, playerIndex) {
        //gameService.getTrumpCard(gameId);
    });
}

function sendCardToPlayer(io, socket, gameId, playerIndex)
{
    if (startedGames.has(gameId))
    {
        var game = startedGames.get(gameId);
        game.CurrentPlayerIndex = playerIndex;
        var player = game.PlayerList[playerIndex-1];
        var cards = gameService.getPlayingCards(gameId);
        var activePlayer = new ActivePlayerInGame(gameId, player, cards);
        io.to(gameId).emit('setActivePlayer', activePlayer);
    }
}

class ActivePlayerInGame
{
    constructor(gameId, player, cards)
    {
        this.GameId = gameId;
        this.ActivePlayer = player;
        this.Cards = cards;
    }
}

function onStartGame(io, socket, gameId, gameName)
{
    if (!startedGames.has(gameId))
    {
        var response = new GameStartedResponse(gameId, gameName);
        var playerList = playerListPerGame.get(gameId);

        var game = new Game(gameId, gameName, playerList.size(), playerList.toArray(), 1)
        startedGames.put(gameId, game);
        gameService.startGame(gameId);

        io.to(gameId).emit('gameStarted', game);
    }
}

class Game
{
    constructor(gameId, gameName, totalPlayers, playerList, currentPlayerIndex)
    {
        this.GameId = gameId;
        this.GameName = gameName;
        this.TotalPlayers = totalPlayers;
        this.PlayerList = playerList;
        this.CurrentPlayerIndex = currentPlayerIndex;
    }
}

class GameStartedResponse
{
    constructor(gameId, gameName)
    {
        this.GameId = gameId;
        this.GameName = gameName;
    }
}

function onInitiateGame(io, socket, userName, emailId, gameName, gameId)
{
    console.log(userName + " Initiated " + gameName);
    userService.gameCollection.update(
        { 'GameId': gameId },
        { $set: { 'Status': true } },
        function (error, result) {

            userService.gameCollection.findOne({ "GameId": gameId }, (error, doc) => {
                var player;
                var playerList;
                var playerIndex;
                var playerIndexStack;

                if (!playerIndexPerGame.has(gameId)) {
                    playerIndexStack = new Stack();
                    playerList = new ArrayList();

                    populatePlayerIndexStack(playerIndexStack);
                    playerIndex = playerIndexStack.pop();
                    player = new Player(emailId, playerIndex, userName, gameId, gameName);

                    playerList.push(player);
                    socket.player = player;

                    playerIndexPerGame.put(gameId, playerIndexStack);
                    playerListPerGame.put(gameId, playerList);
                }
                else {
                    playerIndexStack = playerIndexPerGame.get(gameId);
                    playerList = playerListPerGame.get(gameId);
                    playerIndex = playerIndexStack.pop();
                    player = new Player(emailId, playerIndex, userName, gameId, gameName);
                    playerList.push(player);
                    socket.player = player;
                }

                var initGameResponse = new InitiateGameResponse(playerIndex, gameId, gameName, doc.Status, playerList.toArray());
                socket.emit('initiateGameResponse', initGameResponse);
                socket.join(gameId);
                if (playerList.length > 1)
                    io.to(gameId).emit('updateConnectedPlayers', playerList.toArray());
            });
        });
}

class InitiateGameResponse
{
    constructor(playerIndex, gameId, gameName, started, connectedPlayers) {
        this.PlayerIndex = playerIndex;
        this.GameId = gameId;
        this.GameStatus = started;
        this.GameName = gameName;
        this.ConnectedPlayers = connectedPlayers;
    }
}

function populatePlayerIndexStack(playerList)
{
    for (var i = 6; i >= 1; i--)
        playerList.push(i);
}

function onJoinGame(io, socket, userName, emailId, gameName, gameId)
{
    //If the game is started, a user cannot join in-between

    if (!startedGames.has(gameId)) {
        console.log(userName + " Joined " + gameName);
        userService.gameCollection.findOne({ "GameId": gameId }, (error, doc) => {
            var player;
            var playerList;
            var playerIndex;
            var playerIndexStack;

            if (!playerIndexPerGame.has(gameId)) {
                playerIndexStack = new Stack();
                playerList = new ArrayList();

                populatePlayerIndexStack(playerIndexStack);
                playerIndex = playerIndexStack.pop();
                player = new Player(emailId, playerIndex, userName, gameId, gameName);

                playerList.push(player);
                socket.player = player;

                playerIndexPerGame.put(gameId, playerIndexStack);
                playerListPerGame.put(gameId, playerList);
            }
            else
            {
                playerIndexStack = playerIndexPerGame.get(gameId);
                playerList = playerListPerGame.get(gameId);
                playerIndex = playerIndexStack.pop();
                player = new Player(emailId, playerIndex, userName, gameId, gameName);
                playerList.push(player);
                socket.player = player;
            }

            var joinGameResponse = new JoinGameResponse(playerIndex, gameId, gameName, doc.Status, playerList.toArray(), "");
            socket.emit('joinGameResponse', joinGameResponse);
            socket.join(gameId);
            if (playerList.length > 1)
                io.to(gameId).emit('updateConnectedPlayers', playerList.toArray());            
        });
    }
    else
    {
        var joinGameResponse = new JoinGameResponse(gameId, gameName, doc.Status, "Game is already started, Hence cannot join now");
        socket.emit('joinGameResponse', joinGameResponse);
    }
}

function onRemoveUserFromGame(io, socket, emailId, gameId, playerIndex)
{
    if (playerIndexPerGame.has(gameId))
    {
        var playerIndexStack = playerIndexPerGame.get(gameId);
        playerIndexStack.push(socket.player.PlayerIndex);
        var playerList = playerListPerGame.get(gameId);
        playerList.remove(socket.player);
        socket.broadcast.to(gameId).emit('removePlayer', socket.player.PlayerIndex);
        socket.leave(gameId);
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
