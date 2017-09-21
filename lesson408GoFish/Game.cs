using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson408GoFish {
    class Game {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;
        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm) {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }
        private void Deal() {
            stock.Shuffle();

        }
        public bool PlayOneRound(int selectedPlayerCard) {

        }
        public bool PullOutBooks(Player player) {

        }
        public string DescribeBooks() {

        }
        public string GetWinnerName() {

        }
        public IEnumerable<string> GetPlayerCardNames() {
            return players[0].GetCardNames();
        }
        public string DescribePlayerHands() {
            string description = "";
            for (int i = 0; i < players.Count; i++) {
                description += players[i].Name + " has " + players[i].CardCount;
                if (players[i].CardCount == 1) {
                    description += " card." + Environment.NewLine;
                } else
                    description += " cards." + Environment.NewLine;
            }
            description += "The stock has " + stock.Count + " cards left.";
            return description;
        }
    }
}
