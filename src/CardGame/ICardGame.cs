namespace CardGame
{
    public interface ICardGame
    {
        void Start(params ICardPlayer[] players);
        void Play(ICardPlayer player);
    }
}