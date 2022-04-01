////"use strict";

////const connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();
////var connectionId = (Math.random() + 1).toString(36).substring(7);
////var player = "";

//////Disable the game until connection is established.
////document.getElementById("game_div").style = "display: none;";

////connection.on("UpdatePlayer", function (player_number) {
////    player = player_number;
////    connectionId = connection.connectionId;
////    if (player == "player_one" || player == "player_two") {
////        connection.invoke("StartGame", player);
////    }
////});

////connection.on("UpdateGame", function (my_hand, my_count, play_one, play_two, opp_count) {
    
////    document.getElementById("game_div").style = "";
////    document.getElementById("waiting_for_game").style = "display: none;";
////    player_count.innerHTML = my_count;
////    other_count.innerHTML = opp_count;
////    play_pile_one.src = "../lib/cards/" + play_one;
////    play_pile_two.src = "../lib/cards/" + play_two;
////    player_hand_0.src = "../lib/cards/" + my_hand[0];
////    player_hand_1.src = "../lib/cards/" + my_hand[1];
////    player_hand_2.src = "../lib/cards/" + my_hand[2];
////    player_hand_3.src = "../lib/cards/" + my_hand[3];
////    player_hand_4.src = "../lib/cards/" + my_hand[4];
    
////});

////connection.start().then(function () {
////    //connectionId = connection.connection.connectionId;
////    connection.invoke('JoinGame', connection.connectionId);
////}).catch(function (err) {
////    return console.error(err.toString());
////});


