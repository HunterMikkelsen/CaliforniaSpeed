using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Speed.Pages
{
    public class GameModel : PageModel
    {
        public List<Card> PlayerOneHand { get; set; }
        public List<Card> PlayerTwoHand { get; set; }
        public List<Card> PlayerOneDeck { get; set; }
        public List<Card> PlayerTwoDeck { get; set; }
        public List<Card> PlayPileOne { get; set; }
        public List<Card> PlayPileTwo { get; set; }
        public List<Card> PickPileOne { get; set; }
        public List<Card> PickPileTwo { get; set; }
        static readonly Random Random = new();

        public GameModel()
        {
            PlayerOneHand = new List<Card>();
            PlayerTwoHand = new List<Card>();
            PlayerOneDeck = new List<Card>();
            PlayerTwoDeck = new List<Card>();
            PlayPileOne = new List<Card>();
            PlayPileTwo = new List<Card>();
            PickPileOne = new List<Card>();
            PickPileTwo = new List<Card>();

        }
        public void OnGet()
        {
        }

        

    }

    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string Image { get; set; }

        public Card(string name, string suit, string image)
        {
            if (name == "ace")
            {
                Value = 1;
            }
            else if (name == "jack") {
                Value = 11;
            }
            else if (name == "queen")
            {
                Value = 12;
            }
            else if (name == "king")
            {
                Value = 13;
            }
            else
            {
                Value = int.Parse(name);
            }
            Name = name;
            Suit = suit;
            Image = image;
        }
    }
}
