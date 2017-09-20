using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson408GoFish {
    class Deck {
        public Card Peek(int cardNumber) {
            return cards[cardNumber];
        }
        public Card Deal() {
            returnDeal(0);
        }
        public bool ContainsValue(Values value) {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }
        public Deck PullOutValues(Values value) {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }
        public bool HasBook(Values value) {
            int NumberOfCards = 0;
            foreach (Card card in cards)
                if (card.Value == value)
                    NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else return false;
        }
        public void SortByValue() {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
