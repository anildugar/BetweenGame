'use strict';

var http = require('http');
var express = require('express');
var bodyParser = require('body-parser');
var app = express();
var server = http.createServer(app);

var io = require('socket.io').listen(server);

var userService = require('./UserService.js');
var gameService = require('./GameService.js');
var socketService = require('./SocketService.js')

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

server.listen(9090);

io.on('connection', function (socket)
{
    console.log('connected');
    socketService.onClientConnected(io, socket);
});

app.get('/gameCreatedByUser/:email', (req, res) => {

    gameService.gameCreatedByUser(req.params.email, function (data)
    {
        res.send(data);
    });
});

app.get('/getJoinGamesPerUser/:email', (req, res) => {

    gameService.getJoinGamesPerUser(req.params.email, function (data) {
        res.send(data);
    });
});

app.get('/validateUser/:email/', (req, res) => {

    userService.validateUser(req.params.email);
});


app.post('/registerUser/', (req, res) => {

    userService.registerUser(req.body.name, req.body.email, req.body.password);
});

app.post('/authenticateUser/', (req, res) => {

    userService.authenticateUser(req.body.email, req.body.password, function (error, msg) {
        console.log(msg);
        res.send(msg);
    });
});

app.post('/createGame/', (req, res) => {

    gameService.createGame(req.body.email, req.body.gamename, req.body.invites, function (error, msg) {
        console.log(msg);
        res.send(msg);
    });
});

app.post('/startGame/', (req, res) => {
    gameService.startGame(req.body.gameid);
});

app.post('/getPlayingCards/', (req, res) =>
{
    gameService.getPlayingCards(req.body.gameid);
});

app.post('/getTrumpCard/', (req, res) => {

    gameService.getTrumpCard(req.body.gameid);
});