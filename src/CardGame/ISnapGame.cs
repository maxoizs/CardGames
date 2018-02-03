namespace CardGame
{
    public interface ISnapGame : ICardGame
    {
        void Snap(ISnapPlayer player);
    }
}