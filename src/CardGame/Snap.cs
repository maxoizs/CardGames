using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    /// <summary>
    /// Snap game
    /// </summary>
    public class SnapGame : CardGame, ISnapGame
    {
        public void Snap(ISnapPlayer player)
        {
            player.Snap(Pile);
            Pile.Clear();
        }
    }
}