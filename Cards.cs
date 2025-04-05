using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HeartsGameDesign
{

    // Setting up the card deck along with their values
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Value
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Value Value { get; set; }
        public Image Image { get; set; }

        public Card(Suit suit, Value value, Image image)
        {
            Suit = suit;
            Value = value;
            Image = image;
        }
    }
}
