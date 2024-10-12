using System;
using System.Collections.Generic;

namespace MonsterCardGame
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Card> Cards { get; set; }  // Sammlung von Karten

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Cards = new List<Card>();  // Initialisiere die Liste der Karten
        }

        // Karte zur Sammlung hinzufügen
        public void AddCard(Card card)
        {
            Cards.Add(card);
            Console.WriteLine($"{card.Name} wurde zu {Username}'s Sammlung hinzugefügt.");
        }

        // Karte aus der Sammlung entfernen
        public void RemoveCard(string cardName)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Name == cardName)
                {
                    Console.WriteLine($"{Cards[i].Name} wurde aus {Username}'s Sammlung entfernt.");
                    Cards.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($"{cardName} wurde nicht gefunden.");
        }

        // Alle Karten anzeigen
        public void ShowCards()
        {
            Console.WriteLine($"{Username}'s Karten Sammlung:");
            if (Cards.Count == 0)
            {
                Console.WriteLine("Keine Karten in der Sammlung.");
                return;
            }

            // Karten mit einer einfachen for-Schleife anzeigen
            for (int i = 0; i < Cards.Count; i++)
            {
                Cards[i].DisplayCardInfo();
            }
        }
    }
}