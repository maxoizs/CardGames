using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    /// <summary>
    /// <see cref="CardGame"/> SnapPlayer
    /// </summary>
    public class SnapPlayer : ISnapPlayer
    {
        public List<Card> Cards { get; private set; }
        public string Name { get; private set; }

        public SnapPlayer(string name)
        {
            Name = name;
        }

        public Card Play()
        {
            // we might use stack in this case
            var card = Cards.Last();
            Cards.Remove(card);
            return card; 
        }

        /// <summary>
        /// When game start, player takes a set of <see cref="Card"/>s 
        /// </summary>
        public void Deal(IEnumerable<Card> deal)
        {
            Cards = new List<Card>();
            Cards.AddRange(deal);
        }

        /// <summary>
        /// <see cref="SnapPlayer"/> takes the whole <see cref="SnapGame.Pile"/> adding it to his <see cref="Cards"/> 
        /// </summary>
        public void Snap(IEnumerable<Card> cards)
        {
            Cards.AddRange(cards);
        }
    }
}