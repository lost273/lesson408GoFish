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
            this.cards = new Deck(new Card[] { });
            this.textBoxOnForm = textBoxOnForm;
            textBoxOnForm.Text = $"{textBoxOnForm.Text} {this.name} has just joined the game.{Environment.NewLine}";
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
        // Выбираем случайную карту среди имеющихся у игроков
        public Values GetRandomValue() {
            Card randomCard = cards.Peek(random.Next(cards.Count));
            return randomCard.Value;
        }
        //Извлекаем карты, которые соответствуют заданным параметрам
        public Deck DoYouHaveAny(Values value) {
            Deck cardsIHave = cards.PullOutValues(value);
            textBoxOnForm.Text = $"{textBoxOnForm.Text} {name} has {cardsIHave.Count} {Card.Plural(value)}{Environment.NewLine}";
            return cardsIHave;
        }
        //Метод используется соперником, выбирает случайную карту
        public void AskForACard(List<Player> players, int myIndex, Deck stock) {
            //Ситуация когда противник отдал последнюю карту
            if (stock.Count > 0) 
                if (cards.Count == 0)
                    cards.Add(stock.Deal());
            Values randomValue = GetRandomValue();
            AskForACard(players,myIndex,stock, randomValue);
        }
        //Проверяем всех игроков(за исключением спрашивающего), добавляем найденные карты
        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value) {
            this.textBoxOnForm.Text = $"{textBoxOnForm.Text} {this.name} asks if anyone has a {value.ToString()}.{Environment.NewLine}";
            int totalCardGiven = 0;
            for (int i = 0; i < players.Count; i++) {
                if (i != myIndex) {
                    Player player = players[i];
                    Deck CardsGiven = player.DoYouHaveAny(value);
                    totalCardGiven += CardsGiven.Count;
                    while (CardsGiven.Count > 0)
                        cards.Add(CardsGiven.Deal());
                }
            }
            //При отсутствии у соперников подходящих карт игрок берет карту из запаса при помощи метода Deal
            if((totalCardGiven == 0) && (stock.Count > 0)){
                textBoxOnForm.Text = $"{textBoxOnForm.Text} {Name} must draw from the stock.{Environment.NewLine}";
                cards.Add(stock.Deal());
            }
        }
        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
