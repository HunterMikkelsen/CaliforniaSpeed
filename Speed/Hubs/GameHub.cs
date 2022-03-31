using Microsoft.AspNetCore.SignalR;
using Speed.GameLogic;

namespace Speed.Hubs
{
    public class GameHub : Hub
    {
       
        public static Game? game { get; set; }
        public static string? player_one { get; set; }
        public static string? player_two { get; set; }


        public async Task JoinGame(string token)
        {
            if (string.IsNullOrEmpty(player_one) || player_one == token)
            {
                player_one = token;
                await Clients.Caller.SendAsync("UpdatePlayer", "player_one");
            }
            else if (string.IsNullOrEmpty(player_two) || player_two == token)
            {
                player_two = token;
                await Clients.Caller.SendAsync("UpdatePlayer", "player_two");
            }
        }

        public async Task StartGame(string token)
        {
            if (game == null)
            {
                game = new Game();
            }
            if ((!string.IsNullOrEmpty(player_one)) && (!string.IsNullOrEmpty(player_two))) {
                var my_hand = new string[5];
                var my_count = 0;
                var play_one = "";
                var play_two = "";
                var other_count = 0;
                if (token.Equals("player_one"))
                {
                    my_hand = game.getHand(player_one).ToArray();
                    my_count = game.PlayerOneDeck.Count();
                    play_one = game.PlayPileOne[0].Image;
                    play_two = game.PlayPileTwo[0].Image;
                    other_count = game.PlayerTwoDeck.Count();
                }
                else if (token.Equals("player_two"))
                {
                    my_hand = game.getHand(player_two).ToArray();
                    my_count = game.PlayerTwoDeck.Count();
                    play_one = game.PlayPileOne[0].Image;
                    play_two = game.PlayPileTwo[0].Image;
                    other_count = game.PlayerOneDeck.Count();
                }
                    await Clients.Caller.SendAsync("UpdateGame", my_hand, my_count, play_one, play_two, other_count);
            }
            await Clients.Caller.SendAsync("UpdatePlayer", "player_one");
        }

        public async Task SendMessage(string user, string message)
        {
            // sends to all endpoints
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            // sends to the user that called the function
            //await Clients.Caller.SendAsync("ReceiveMessage", user, message.ToUpper());
            // sends to all other users except the person who called the function
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }

        public async Task EchoMessage(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message.ToUpper());
        }
    }

    
}
