namespace MonsterCardGame
{
    public class Card
    {
        public string Name { get; set; }
        public string Type { get; set; }  // Monster oder Spell
        public int Damage { get; set; }
        public string Element { get; set; }  // Feuer, Wasser, Erde, etc.
        public MonsterType? MonsterType { get; set; } // Optional, wenn es eine Monsterkarte ist

        // Konstruktor für Monsterkarten
        public Card(string name, int damage, string element, MonsterType monsterType)
        {
            Name = name;
            Type = "Monster";
            Damage = damage;
            Element = element;
            MonsterType = monsterType;
        }

        // Konstruktor für Zauberkarten
        public Card(string name, int damage, string element)
        {
            Name = name;
            Type = "Spell";
            Damage = damage;
            Element = element;
            MonsterType = null; // Nicht anwendbar für Zauberkarten
        }

        public void DisplayCardInfo()
        {
            Console.WriteLine($"Name: {Name}, Type: {Type}, Damage: {Damage}, Element: {Element}");
            if (MonsterType.HasValue)
            {
                Console.WriteLine($"Monster Type: {MonsterType.Value}");
            }
        }
    }
}