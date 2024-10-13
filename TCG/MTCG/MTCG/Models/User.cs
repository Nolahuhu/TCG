namespace MonsterCardGame
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Card> Cards { get; set; }  // Sammlung von Karten
        public List<Card> Deck { get; set; }   // Bestes 4-Karten Deck
        public int Coins { get; set; }         // Virtuelle Münzen
        public int Elo { get; private set; }   // ELO-Wert des Benutzers

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Cards = new List<Card>();
            Deck = new List<Card>();
            Coins = 20;  // Jeder Benutzer startet mit 20 Münzen
            Elo = 100;   // Jeder Benutzer startet mit einem ELO von 100
        }

        // Methode, um Münzen auszugeben
        public bool SpendCoins(int amount)
        {
            if (Coins >= amount)
            {
                Coins -= amount;
                return true;  // Münzen erfolgreich ausgegeben
            }
            return false;  // Nicht genügend Münzen
        }

        // Methode, um das Deck anzuzeigen
        public List<Card> ShowDeck()
        {
            return Deck;
        }

        // Methode, um zu prüfen, ob das Deck gültig ist
        public bool HasValidDeck()
        {
            return Deck.Count == 4;  // Ein gültiges Deck hat genau 4 Karten
        }

        // Karte zur Sammlung hinzufügen
        public string AddCard(Card card)
        {
            Cards.Add(card);
            return $"{card.Name} wurde zu {Username}'s Sammlung hinzugefügt.";
        }

        // Deck aktualisieren (beste 4 Karten)
        public string UpdateDeck(List<Card> deckCards)
        {
            if (deckCards.Count != 4)
            {
                return "Ein Deck muss genau 4 Karten enthalten.";
            }

            foreach (var card in deckCards)
            {
                if (!Cards.Contains(card))
                {
                    return $"Die Karte {card.Name} gehört nicht zu deiner Sammlung.";
                }
            }

            Deck = new List<Card>(deckCards);
            return "Deck wurde erfolgreich aktualisiert.";
        }

        // ELO-Wert erhöhen
        public void AddElo(int points)
        {
            Elo += points;
        }

        // ELO-Wert verringern
        public void RemoveElo(int points)
        {
            Elo -= points;
        }

        // Karten anzeigen
        public List<Card> ShowCards()
        {
            return Cards;
        }
    }
}
