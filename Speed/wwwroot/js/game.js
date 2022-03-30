"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();
var token = (Math.random() + 1).toString(36).substring(7);
var player = "";

//Disable the game until connection is established.
document.getElementById("game_div").style = "display: none;";

connection.on("UpdatePlayer", function (player_number) {
    player = player_number;
    if (player == "player_one" || player == "player_two") {
        document.getElementById("game_div").style = "";
        document.getElementById("waiting_for_game").style = "display: none;";
        connection.invoke("StartGame", token)
    }
});

connection.on("UpdateGame", function (my_hand, my_count, play_one, play_two, other_count) {
    console.log("hand: ", my_hand, "count: ", my_count, "play_one: ", play_one, "play_two: ", play_two, "count2: ", other_count);
    player_hand = document.getElementsByClassName('player_hand');
    player_count = document.getElementById('player_count');
    play_pile_one = document.getElementById('play_pile_one');
    play_pile_two = document.getElementById('play_pile_two');
    opp_count = document.getElementById('other_count');
    
    my_hand.forEach(card, index => {
        player_hand[index].src = "../lib/cards/" + card;
    });
    player_count.innerHtml = my_count;
    play_pile_one.src = "../lib/cards/" + play_one;
    play_pile_two.src = "../lib/cards/" + play_two;
    opp_count.innerHtml = other_count;
});

connection.start().then(function () {
    connection.invoke('JoinGame', token)
}).catch(function (err) {
    return console.error(err.toString());
});