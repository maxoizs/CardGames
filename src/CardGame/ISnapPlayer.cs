using System.Collections.Generic;

namespace CardGame
{
    /// <summary>
    /// <see cref="Snap"/> SnapPlayer
    /// </summary>
    public interface ISnapPlayer : ICardPlayer
    {

        /// <summary>
        /// <see cref="SnapPlayer"/> takes the whole <see cref="SnapGame.Pile"/> adding it to his <see cref="Cards"/> 
        /// </summary>
        void Snap(IEnumerable<Card> cards);
    }
}