using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson408GoFish {
    class Card {

        public Card(Suits suit, Values value) {
            Suit = suit;
            Value = value;
        }
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public string Name {
            get { return $"{Value} of {Suit}"; }

        }
        public static string Plural(Values value) {
            if (value == Values.Six)
                return "Sixes";
            else
                return $"{value.ToString()}s";
        }
    }
    enum Suits {
        Spades = 0,
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3
    }

    enum Values {
        Ace = 1,
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
        King = 13
    }

}