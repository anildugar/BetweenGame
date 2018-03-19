var SchemaObject = require('node-schema-object');
var ArrayList = require('arraylist');

var Card = new SchemaObject({
    CardType: String,
    CardNo: String,
    CardValue: Number
});

module.exports.ShuffleDeck = function () {
    var unshuffledList = new ArrayList;

    var CardNumbers = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];

    for (i = 0; i < 13; i++) {
        var card = new Card(
            {
                CardType: "CLUB",
                CardNo: CardNumbers[i],
                CardValue: i + 1
            });
        unshuffledList.add(card);
    }

    for (i = 0; i < 13; i++) {
        var card = new Card(
            {
                CardType: "SPADE",
                CardNo: CardNumbers[i],
                CardValue: i + 1
            });
        unshuffledList.add(card);
    }

    for (i = 0; i < 13; i++) {
        var card = new Card(
            {
                CardType: "DIAMOND",
                CardNo: CardNumbers[i],
                CardValue: i + 1
            });
        unshuffledList.add(card);
    }

    for (i = 0; i < 13; i++) {
        var card = new Card(
            {
                CardType: "HEART",
                CardNo: CardNumbers[i],
                CardValue: i + 1
            });
        unshuffledList.add(card);
    }

    var shuffledList = unshuffledList.shuffle();

    return shuffledList;
};

