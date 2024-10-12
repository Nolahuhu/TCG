namespace MonsterCardGame
{
    public class UserManager
    {
        private List<User> users = new List<User>();

        // Benutzer finden
        public User FindUser(string username)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    return users[i];
                }
            }
            return null;
        }

        // Kartenpaket für den Benutzer kaufen
        public string BuyPackage(string username)
        {
            User user = FindUser(username);
            if (user == null)
            {
                return "Benutzer nicht gefunden.";
            }

            if (!user.SpendCoins(5))
            {
                return "Nicht genügend Münzen.";
            }

            // Erstelle ein zufälliges Kartenpaket
            List<Card> newCards = GenerateRandomPackage();
            foreach (var card in newCards)
            {
                user.AddCard(card);
            }

            return "Kartenpaket erfolgreich gekauft.";
        }

        // Deck aktualisieren
        public string UpdateUserDeck(string username, List<Card> deckCards)
        {
            User user = FindUser(username);
            if (user == null)
            {
                return "Benutzer nicht gefunden.";
            }

            return user.UpdateDeck(deckCards);
        }

        // Benutzerdeck anzeigen
        public List<Card> ShowUserDeck(string username)
        {
            User user = FindUser(username);
            if (user == null)
            {
                return null;  // Benutzer nicht gefunden
            }

            return user.ShowDeck();
        }

        // Überprüfen, ob der Benutzer ein vollständiges Deck hat
        public bool HasValidUserDeck(string username)
        {
            User user = FindUser(username);
            if (user == null)
            {
                return false;
            }

            return user.HasValidDeck();
        }

        // Methode zur Generierung eines zufälligen Kartenpakets
        private List<Card> GenerateRandomPackage()
        {
            List<Card> package = new List<Card>();

            // Erstelle 5 zufällige Karten (kann verbessert werden)
            for (int i = 0; i < 5; i++)
            {
                MonsterType randomType = (MonsterType)(new Random().Next(Enum.GetValues(typeof(MonsterType)).Length));
                Card card = new Card($"RandomCard{i + 1}", new Random().Next(10, 100), "RandomElement", randomType);
                package.Add(card);
            }

            return package;
        }
    }
}
