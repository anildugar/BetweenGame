'use strict';

var MongoClient = require('mongodb').MongoClient;
var url = 'mongodb://anildugar:BHAGAT1931@ds111138.mlab.com:11138/betweengame1';

var database;
var usercollection, gamecollection;

MongoClient.connect(url, (error, db) => {

    if (error)
        throw error;
    database = db.db('betweengame1');
    usercollection = database.collection('users');
    gamecollection = database.collection('games');

    console.log('Database Connected');

    module.exports.userCollection = usercollection;
    module.exports.gameCollection = gamecollection;
});

function validateUser(email)
{
    usercollection.findOne({ "Email": email }, (error, result) => {
        if (result != null)
            res.send(JSON.stringify(result.Active));
        else
            res.send(JSON.stringify(result));
    });
}

function registerUser(name, email, password, callback) {
    console.log(email);

    var userexist = false;
    usercollection.findOne({ "Email": email }, (error, doc) => {
        if (doc != null) {
            userexist = true;
        }
        else {
            userexist = false;
        }

        if (userexist == false) {
            usercollection.insertOne({ "Name": name, "Email": email, "Password": password, "Active": "true" }, (error, result) => {

                if (error)
                    throw error;
                console.log("Record Inserted ID: " + result.insertedId);
            });
        }
    });
}

function authenticateUser(email, password, callback)
{
    console.log(email);

    var userExist = false;
    var isUserActive = false;
    var username = "";
    usercollection.findOne({ "Email": email }, (error, doc) => {

        if (doc != null) {
            userExist = true;
        }
        else {
            userExist = false;
        }

        if (userExist == true) {
            isUserActive = doc.Active;
            username = doc.Name;
            if (doc.Password != password) {
                userExist = false;
            }
        }
        var loginResponse = new LoginResponse(username, email, userExist, isUserActive);
        callback(null, loginResponse.get());
    });
}

module.exports.authenticateUser = authenticateUser;
module.exports.registerUser = registerUser;
module.exports.validateUser = validateUser;

class LoginResponse {
    constructor(username, email, userexist, active) {
        this.userName = username;
        this.email = email;
        this.userExist = userexist;
        this.isUserActive = active;
    }

    get() {
        return JSON.stringify(this);
    };
}