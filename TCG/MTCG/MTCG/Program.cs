using System;

namespace MonsterCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Willkommen im Monster Trading Cards Game!");
                Console.WriteLine("1. Registrieren");
                Console.WriteLine("2. Anmelden");
                Console.WriteLine("3. Benutzer anzeigen");
                Console.WriteLine("4. Karte zu Benutzer hinzufügen");
                Console.WriteLine("5. Karte von Benutzer entfernen");
                Console.WriteLine("6. Benutzerkarten anzeigen");
                Console.WriteLine("7. Beenden");
                Console.Write("Bitte wähle eine Option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Benutzername: ");
                        string regUsername = Console.ReadLine();
                        Console.Write("Passwort: ");
                        string regPassword = Console.ReadLine();
                        userManager.Register(regUsername, regPassword);
                        break;
                    case "2":
                        Console.Write("Benutzername: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Passwort: ");
                        string loginPassword = Console.ReadLine();
                        userManager.Login(loginUsername, loginPassword);
                        break;
                    case "3":
                        userManager.ListUsers();
                        break;
                    case "4":
                        Console.Write("Benutzername: ");
                        string userToAddCard = Console.ReadLine();
                        Console.Write("Kartenname: ");
                        string cardName = Console.ReadLine();
                        Console.Write("Kartentyp (Monster/Spell): ");
                        string cardType = Console.ReadLine();
                        Console.Write("Schaden: ");
                        int damage = int.Parse(Console.ReadLine());
                        Console.Write("Element: ");
                        string element = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Benutzername: ");
                        string userToRemoveCard = Console.ReadLine();
                        Console.Write("Kartenname: ");
                        string removeCardName = Console.ReadLine();
                        userManager.RemoveCardFromUser(userToRemoveCard, removeCardName);
                        break;
                    case "6":
                        Console.Write("Benutzername: ");
                        string userToShowCards = Console.ReadLine();
                        userManager.ShowUserCards(userToShowCards);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }

                Console.WriteLine(); // Zeilenumbruch für bessere Lesbarkeit
            }
        }
    }
}
