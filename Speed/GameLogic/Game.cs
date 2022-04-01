namespace Speed.GameLogic
{
    public class Game
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

        public Game()
        {
            PlayerOneHand = new List<Card>();
            PlayerTwoHand = new List<Card>();
            PlayerOneDeck = new List<Card>();
            PlayerTwoDeck = new List<Card>();
            PlayPileOne = new List<Card>();
            PlayPileTwo = new List<Card>();
            PickPileOne = new List<Card>();
            PickPileTwo = new List<Card>();

            Deal();
        }

        public void Deal()
        {
            var cards = new List<string> { "2_of_clubs.png", "2_of_diamonds.png", "2_of_hearts.png", "2_of_spades.png", "3_of_clubs.png", "3_of_diamonds.png", "3_of_hearts.png", "3_of_spades.png", "4_of_clubs.png", "4_of_diamonds.png", "4_of_hearts.png", "4_of_spades.png", "5_of_clubs.png", "5_of_diamonds.png", "5_of_hearts.png", "5_of_spades.png", "6_of_clubs.png", "6_of_diamonds.png", "6_of_hearts.png", "6_of_spades.png", "7_of_clubs.png", "7_of_diamonds.png", "7_of_hearts.png", "7_of_spades.png", "8_of_clubs.png", "8_of_diamonds.png", "8_of_hearts.png", "8_of_spades.png", "9_of_clubs.png", "9_of_diamonds.png", "9_of_hearts.png", "9_of_spades.png", "10_of_clubs.png", "10_of_diamonds.png", "10_of_hearts.png", "10_of_spades.png", "jack_of_clubs.png", "jack_of_diamonds.png", "jack_of_hearts.png", "jack_of_spades.png", "queen_of_clubs.png", "queen_of_diamonds.png", "queen_of_hearts.png", "queen_of_spades.png", "king_of_clubs.png", "king_of_diamonds.png", "king_of_hearts.png", "king_of_spades.png", "ace_of_clubs.png", "ace_of_diamonds.png", "ace_of_hearts.png", "ace_of_spades.png" };
            var shuffled_cards = cards.OrderBy(a => Random.Next()).ToList();
            var i = 0;
            foreach (var image in shuffled_cards)
            {
                var name = image.Split('_')[0];
                var suit = image.Split('_')[2].Split('.')[0];
                var card = new Card(name, suit, image);
                if (PlayPileOne.Count < 1)
                {
                    PlayPileOne.Add(card);
                }
                else if (PlayPileTwo.Count < 1)
                {
                    PlayPileTwo.Add(card);
                }
                else if (PickPileOne.Count < 5)
                {
                    PickPileOne.Add(card);
                }
                else if (PickPileTwo.Count < 5)
                {
                    PickPileTwo.Add(card);
                }
                else if (PlayerOneDeck.Count < 20)
                {
                    PlayerOneDeck.Add(card);
                }
                else
                {
                    PlayerTwoDeck.Add(card);
                }
                i++;
            }

            for (i = 0; i < 5; i++)
            {
                PlayerOneHand.Add(PlayerOneDeck[i]);
                PlayerTwoHand.Add(PlayerTwoDeck[i]);
            }

            PlayerOneDeck.RemoveRange(0, 5);
            PlayerTwoDeck.RemoveRange(0, 5);
        }

        public void Reshuffle()
        {
            var cards = new List<Card>();
            foreach (var card in PlayPileOne)
            {
                cards.Add(card);
            }
            foreach (var card in PlayPileTwo)
            {
                cards.Add(card);
            }

            var shuffled_cards = cards.OrderBy(a => Random.Next()).ToList();
        }

        public List<string> GetHand(string player_number)
        {
            var hand = new List<string>();
            if (player_number == "player_one")
            {
                foreach(var card in PlayerOneHand)
                {
                    hand.Add(card.Image);
                }
            }
            else
            {
                foreach(var card in PlayerTwoHand)
                {
                    hand.Add(card.Image);
                }
            }
            return hand;
        }

        public bool PlayCard(string player_number, int hand_index, string play_pile)
        {
            int pile_value;
            int card_value;
            List<Card> pile;


            if (play_pile == "play_pile_one")
            {
                pile = PlayPileOne;
                pile_value = PlayPileOne.Last().Value;
            }
            else
            {
                pile = PlayPileTwo;
                pile_value = PlayPileTwo.Last().Value;
            }

            if (player_number == "player_one")
            {
                card_value = PlayerOneHand[hand_index].Value;
                if(IsValidPlay(card_value, pile_value))
                {
                    var card = PlayerOneHand[hand_index];
                    pile.Add(card);
                    PlayerOneHand.Remove(card);
                    card = PlayerOneDeck.Last();
                    PlayerOneHand.Add(card);
                    PlayerOneDeck.Remove(card);
                    return true;
                }
            }
            else
            {
                card_value = PlayerTwoHand[hand_index].Value;
                if (IsValidPlay(card_value, pile_value))
                {
                    var card = PlayerTwoHand[hand_index];
                    pile.Add(card);
                    PlayerTwoHand.Remove(card);
                    card = PlayerTwoDeck.Last();
                    PlayerTwoHand.Add(card);
                    PlayerTwoDeck.Remove(card);
                    return true;
                }
            }
            return false;
        }


        public bool IsValidPlay(int card_value, int pile_value)
        {
            if ((card_value + 1) % 13 == pile_value || (pile_value + 1) % 13 == card_value)
            {
                return true;
            }

            return false;
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
                Value = 0;
            }
            else if (name == "jack")
            {
                Value = 10;
            }
            else if (name == "queen")
            {
                Value = 11;
            }
            else if (name == "king")
            {
                Value = 12;
            }
            else
            {
                Value = int.Parse(name) - 1;
            }
            Name = name;
            Suit = suit;
            Image = image;
        }
    }
}
