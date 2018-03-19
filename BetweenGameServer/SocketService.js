
var userService = require('./UserService.js');

function onClientConnected(socket)
{
    socket.on('initiateGame', function (userName, gameName, gameId) {
        onInitiateGame(socket, userName, gameName, gameId);
    });

    socket.on('joinGame', function (userName, gameName, gameId) {
        onJoinGame(socket, userName, gameName, gameId);
    });
}

function onInitiateGame(socket, userName, gameName, gameId)
{
    console.log(userName + " Initiated " + gameName);
    userService.gameCollection.update(
        { 'GameId': gameId },
        {$set: {'Status' : true }});
}

class InitiateGameResponse
{
    constructor(gameId, gameName, started) {
        this.GameId = gameId,
            this.GameStatus = started,
            this.GameName = gameName
    }
}

function onJoinGame(socket, userName, gameName, gameId)
{
    console.log(userName + " Joined " + gameName);
    userService.gameCollection.findOne({ "GameId": gameId }, (error, doc) => {
        var joinGameResponse = new JoinGameResponse(gameId, gameName, doc.Status);
        socket.emit('joinGameResponse', joinGameResponse);
    });
}

class JoinGameResponse {
    constructor(gameId, gameName, started) {
        this.GameId = gameId,
            this.GameStatus = started,
            this.GameName = gameName
    }
}
module.exports.onClientConnected = onClientConnected;
