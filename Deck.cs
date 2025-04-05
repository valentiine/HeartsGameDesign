using System;
using System.Collections.Generic;
using System.Drawing;

namespace HeartsGameDesign
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    // Using a direct mapping for face cards, otherwise using the numeric value directly
                    string valueName = value switch
                    {
                        Value.Jack => "jack",
                        Value.Queen => "queen",
                        Value.King => "king",
                        Value.Ace => "ace",
                        _ => ((int)value).ToString() // For numeric cards, use the integer value directly
                    };

                    string suitName = suit.ToString().ToLower();
                    string cardName = $"{valueName}_of_{suitName}.png"; // The naming convention for the images folder
                    string path = $"PNG-cards-1.3/{cardName}"; // Finding the card
                    try
                    {
                        Image cardImage = Image.FromFile(path);
                        Cards.Add(new Card(suit, value, cardImage));
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        // Debugging to find why it does not work
                        MessageBox.Show($"Card image not found: {path}");
                    }
                }
            }
        }


        public void Shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }


        public Card DealOne()
        {
            if (Cards.Count > 0)
            {
                Card cardToDeal = Cards[0];
                Cards.RemoveAt(0);
                return cardToDeal;
            }
            else
            {
                throw new InvalidOperationException("No cards left in the deck");
            }
        }

        public List<Card> DealHand(int numberOfCards)
        {
            List<Card> hand = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                if (Cards.Count > 0)
                {
                    hand.Add(DealOne());
                }
                else
                {
                    throw new InvalidOperationException("Not enough cards left to deal a hand");
                }
            }
            return hand;
        }

    }
}
