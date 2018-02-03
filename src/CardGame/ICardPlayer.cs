using System.Collections.Generic;

namespace CardGame
{
    /// <summary>
    /// <see cref="CardGame"/> SnapPlayer
    /// </summary>
    public interface ICardPlayer: IPlayer
    {
        List<Card> Cards { get; }

        Card Play();
        /// <summary>
        /// When game start, player takes a set of <see cref="Card"/>s 
        /// </summary>
        void Deal(IEnumerable<Card> deal);
    }
}