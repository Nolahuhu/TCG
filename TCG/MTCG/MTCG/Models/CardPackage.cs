namespace MonsterCardGame
{
    public class CardPackage
    {
        public List<Card> Cards { get; private set; }

        public CardPackage(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Ein Paket muss genau 5 Karten enthalten.");
            }
            Cards = cards;
        }
    }
}