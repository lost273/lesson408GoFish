using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson408GoFish {
    class Deck {
        private List<Card> cards;
        private Random random = new Random();

        //Конструктор создает колоду из 52 карт
        public Deck() {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++) {
                for (int value = 1; value <= 13; value++) {
                    cards.Add(new Card((Suits)suit, (Values)value));
                }
            }
        }
        //Конструктор создает колоду из определенного в параметре количества карт
        public Deck(IEnumerable<Card> initialCards) {
            cards = new List<Card>(initialCards);
        }
        //Количество карт в колоде
        public int Count { get { return cards.Count; } }
        //Добавляем карту в колоду
        public void Add(Card cardToAdd) {
            cards.Add(cardToAdd);
        }
        //Забираем карту из колоды
        public Card Deal(int index) {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }
        //метод тасует карты, меняя их порядок случайным образом
        public void Shuffle() {
            List<Card> NewCards = new List<Card>();
            while (cards.Count > 0) {
                int CardToMove = random.Next(cards.Count);
                NewCards.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
            cards = NewCards;
        }
        //метод возвращает массив типа string с именами всех карт
        public IEnumerable<string> GetCardNames() {
            string[] CardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++) {
                CardNames[i] = cards[i].Name;
            }
            return CardNames;
        }
        //Сортировка по 1 - масти и 2 - по наименованию
        public void Sort() {
            cards.Sort(new CardComparer_bySuit());
        }
        //Берем карту из колоды
        public Card Peek(int cardNumber) {
            return cards[cardNumber];
        }
        //Перегрузка метода без параметра - будет сдана верхняя карта в колоде
        public Card Deal() {
            return Deal(0);
        }
        //Ищет в колоде карты определенного старшинства, при нахождении true
        public bool ContainsValue(Values value) {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }
        //Получаем наборы по 4 одинаковые карты
        public Deck PullOutValues(Values value) {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }
        //При получении карты ищет взятки
        public bool HasBook(Values value) {
            int NumberOfCards = 0;
            foreach (Card card in cards)
                if (card.Value == value)
                    NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else return false;
        }
        //Сортировка по 1 - наименованию и 2 - по масти
        public void SortByValue() {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
