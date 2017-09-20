using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson408GoFish {
    class Player {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(string name, Random random, TextBox textBoxOnForm) {
            this.name = name;
            this.random = random;
            this.textBoxOnForm.Text = $"{textBoxOnForm.Text} {this.name} has just joined the game.{Environment.NewLine}";

        }
        public IEnumerable<Values> PullOutBooks() {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++) {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++) {
                    if (cards.Peek(card).Value == value)
                        howMany++;
                    if (howMany == 4) {
                        books.Add(value);
                        cards.PullOutValues(value);
                    }
                }
            }
            return books;
        }

        public Values GetRandomValue() {
            return cards.Peek(random.Next(cards.Count)).Value;
        }
        public Deck DoYouHaveAny(Values value) {
            Deck deckToReturn = cards.PullOutValues(value);
            textBoxOnForm.Text = $"{textBoxOnForm.Text} {name} has {deckToReturn.Count}.{Environment.NewLine}";
            return deckToReturn;
        }
        public void AskForACard(List<Player> players, int myIndex, Deck stock) {

        }
        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value) {

        }
        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
