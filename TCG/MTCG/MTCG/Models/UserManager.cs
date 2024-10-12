using System;
using System.Collections.Generic;

namespace MonsterCardGame
{
    public class UserManager
    {
        private List<User> users = new List<User>();

        public bool Register(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    Console.WriteLine("Benutzername existiert bereits!");
                    return false;
                }
            }

            users.Add(new User(username, password));
            Console.WriteLine("Benutzer erfolgreich registriert.");
            return true;
        }

        public bool Login(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username && users[i].Password == password)
                {
                    Console.WriteLine("Login erfolgreich. Willkommen, " + username + "!");
                    return true;
                }
            }

            Console.WriteLine("Ungültige Anmeldeinformationen.");
            return false;
        }

        public void ListUsers()
        {
            Console.WriteLine("Registrierte Benutzer:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i].Username);
            }
        }

        // Benutzer finden
        private User FindUser(string username)
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

        // Karte zu einem Benutzer hinzufügen
        public void AddCardToUser(string username, Card card)
        {
            User user = FindUser(username);
            if (user != null)
            {
                user.AddCard(card);
            }
            else
            {
                Console.WriteLine("Benutzer nicht gefunden.");
            }
        }

        // Karte von einem Benutzer entfernen
        public void RemoveCardFromUser(string username, string cardName)
        {
            User user = FindUser(username);
            if (user != null)
            {
                user.RemoveCard(cardName);
            }
            else
            {
                Console.WriteLine("Benutzer nicht gefunden.");
            }
        }

        // Karten eines Benutzers anzeigen
        public void ShowUserCards(string username)
        {
            User user = FindUser(username);
            if (user != null)
            {
                user.ShowCards();
            }
            else
            {
                Console.WriteLine("Benutzer nicht gefunden.");
            }
        }
    }
}
