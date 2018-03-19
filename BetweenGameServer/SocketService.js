

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
}

function onJoinGame(socket, userName, gameName, gameId)
{
    console.log(userName + " Joined " + gameName);
}
module.exports.onClientConnected = onClientConnected;
