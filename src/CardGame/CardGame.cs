using System.Collections.Generic;

namespace CardGame
{
    public abstract class CardGame
    {
        public List<ICardPlayer> Players { get; protected set; }
        public List<Card> Cards { get; protected set; }
        public List<Card> Pile { get; protected set; }
    }
}