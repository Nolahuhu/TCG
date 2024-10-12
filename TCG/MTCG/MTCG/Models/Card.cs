using System;

namespace MonsterCardGame
{
    public class Card
    {
        public string Name { get; set; }
        public string Type { get; set; }  // Monster oder Spell
        public int Damage { get; set; }
        public string Element { get; set; }  // Feuer, Wasser, Erde, etc.

        public Card(string name, string type, int damage, string element)
        {
            Name = name;
            Type = type;
            Damage = damage;
            Element = element;
        }

        public void DisplayCardInfo()
        {
            Console.WriteLine($"Name: {Name}, Type: {Type}, Damage: {Damage}, Element: {Element}");
        }
    }
}