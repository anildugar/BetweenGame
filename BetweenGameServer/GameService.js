'use strict'; 
var Hashtable = require('hashtable');
var Deck = require('./Deck.js');
var Guid = require('guid');
var userService = require('./UserService.js');

var hashtable = new Hashtable();

function createGame(email, gamename, invitees, callback)
{
    console.log(email);

    var userexist = false;
    userService.userCollection.findOne({ "Email": email }, (error, doc) => {

        if (doc != null) {
            userexist = true;
        }
        else {
            userexist = false;
        }

        if (userexist == true) {

            var gameid = Guid.raw();

            var gamesessionid = Guid.raw();

            userService.gameCollection.insertOne({ "GameName": gamename, "GameId": gameid, "SessionId": gamesessionid, "Email": email, "Invitees": invitees }, (error, result) => {

                if (error)
                    throw error;
                var createGameResponse = new CreateGameResponse(email, gamename, gameid);
                callback(null, createGameResponse.get());
            });
        }
    });
}

class CreateGameResponse {
    constructor(email, gamename, gameid) {
        this.email = email;
        this.gameId = gameid;
        this.gameName = gamename;
    }

    get() {
        return JSON.stringify(this);
    };
}

function gameCreatedByUser(email, callback)
{
    console.log(email);

    var userexist = false;
    var list = [];
    var i = 0;
    userService.gameCollection.find({ "Email": email }).toArray(function (err, docs) {
        docs.forEach(function (doc) {
            var g = new GameCreatedByUser(doc.GameName, doc.GameId);
            list.push(g);
        });
        callback(JSON.stringify(list));
    });
}

class GameCreatedByUser
{
    constructor(gamename, gameid) {        
        this.GameId = gameid;
        this.GameName = gamename;
    }

    get() {
        return JSON.stringify(this);
    };
}

function getJoinGamesPerUser(email, callback)
{
    console.log(email);

    var userexist = false;
    var list = [];
    var i = 0;
    userService.gameCollection.find({ "Invitees": email }).toArray(function (err, docs) {
        docs.forEach(function (doc) {
            var g = new GameAvailableToJoin(doc.email, doc.GameName, doc.GameId);
            list.push(g);
        });
        callback(JSON.stringify(list));
    });
}

class GameAvailableToJoin
{
    constructor(email, gamename, gameid) {
        this.Email = email;
        this.GameId = gameid;
        this.GameName = gamename;
    }

    get() {
        return JSON.stringify(this);
    };
}

function startGame(gameid)
{
    var gameexist = false;
    var shuffledList = Deck.ShuffleDeck();

    if (hashtable.has(gameid))
        hashtable.remove(gameid);
    hashtable.put(gameid, shuffledList);

    //userService.gameCollection.findOne({ "GameId": gameid }, (error, doc) => {

    //    if (doc != null) {
    //        gameexist = true;
    //    }
    //    else {
    //        gameexist = false;
    //        res.send('Game doesnt exist');
    //    }

    //    if (gameexist == true) {
    //        var shuffledList = Deck.ShuffleDeck();

    //        if (hashtable.has(gameid))
    //            hashtable.remove(gameid);
    //        hashtable.put(gameid, shuffledList);
    //    }
    //});
}

function getPlayingCards(gameid)
{
    var gameexist = false;
    if (hashtable.has(gameid)) {
        var shuffledList = hashtable.get(gameid);
        if (shuffledList.size() >= 2) {
            var card1 = shuffledList.first();
            shuffledList.remove(0);
            var card2 = shuffledList.first();
            shuffledList.remove(0);
            var cards = { "Card1": card1, "Card2": card2 };
            return JSON.stringify(cards);
        }
    }
    //userService.gameCollection.findOne({ "GameId": gameid }, (error, doc) => {

    //    if (doc != null) {
    //        gameexist = true;
    //    }
    //    else {
    //        gameexist = false;
    //        res.send('Game doesnt exist');
    //    }

    //    if (gameexist == true) {
    //        if (hashtable.has(gameid)) {
    //            var shuffledList = hashtable.get(gameid);
    //            if (shuffledList.size() >= 2) {
    //                var card1 = shuffledList.first();
    //                shuffledList.remove(0);
    //                var card2 = shuffledList.first();
    //                shuffledList.remove(0);
    //                var cards = { "Card1": card1, "Card2": card2 };
    //                return JSON.stringify(cards);
    //            }
    //        }
    //    }
    //});
}

function getTrumpCard(gameid)
{
    var gameexist = false;
    gamecollection.findOne({ "GameId": gameid }, (error, doc) => {

        if (doc != null) {
            gameexist = true;
        }
        else {
            gameexist = false;
            res.send('Game doesnt exist');
        }

        if (gameexist == true) {
            if (hashtable.has(doc.SessionId)) {
                var shuffledList = hashtable.get(doc.SessionId);
                if (shuffledList.size() >= 1) {
                    var card1 = shuffledList.first();
                    shuffledList.remove(0);
                    var cards = { "TrumpCard": card1 };
                    res.send(JSON.stringify(cards));
                }
            }
        }
    });
}

module.exports.getTrumpCard = getTrumpCard;
module.exports.getPlayingCards = getPlayingCards;
module.exports.startGame = startGame;
module.exports.createGame = createGame;
module.exports.gameCreatedByUser = gameCreatedByUser;
module.exports.getJoinGamesPerUser = getJoinGamesPerUser;

