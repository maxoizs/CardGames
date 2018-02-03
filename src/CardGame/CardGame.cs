using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class CardGame : ICardGame
    {
        public List<Card> Cards { get; protected set; }
        public List<Card> Pile { get; protected set; }

        public CardGame()
        {
            Pile = new List<Card>();
            Cards = new List<Card>();
        }

        public virtual void Start(params ICardPlayer[] players)
        {
            PopulateCards();
            DealCards(players);
        }

        public virtual void Play(ICardPlayer player)
        {
            var card = player.Play();
            Pile.Add(card);
        }

        protected void PopulateCards()
        {
            var cards = new List<Card>();
            foreach (var cardName in Enum.GetValues(typeof(CardName)).Cast<CardName>())
            {
                cards.Add(new Card { Color = CardColor.Black, Name = cardName, Shape = CardShape.Spades });
                cards.Add(new Card { Color = CardColor.Red, Name = cardName, Shape = CardShape.Hearts });
                cards.Add(new Card { Color = CardColor.Black, Name = cardName, Shape = CardShape.Diamonds });
                cards.Add(new Card { Color = CardColor.Red, Name = cardName, Shape = CardShape.Clubs });
            }
            var rand = new Random();
            Cards = cards.ProduceShuffle(rand);
        }

        protected void DealCards(params ICardPlayer[] players)
        {
            int count = Cards.Count / players.Length;

            // either deal all at once or one by one
            foreach (var player in players)
            {
                player.Deal(Cards.Take(count));
                Cards.RemoveAll(c => player.Cards.Contains(c));
            }
        }
    }
}