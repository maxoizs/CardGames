using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    /// <summary>
    /// Snap game
    /// </summary>
    public class SnapGame : CardGame, ISnapGame
    {
        public SnapGame()
        {
            Players = new List<ICardPlayer>();
            Pile = new List<Card>();
            Cards = new List<Card>();
        }

        public void Start(params ICardPlayer[] players)
        {
           
            PopulateCards();
            SplitCards(players);
            Players = players.ToList();
        }

        public void Play(ICardPlayer player)
        {
            var card = player.Play();
            Pile.Add(card);
        }

        public void Snap(ISnapPlayer player)
        {
            player.Snap(Pile);
            Pile.Clear();
        }

        private void SplitCards(params ICardPlayer[] players)
        {
            int count = Cards.Count / players.Length;

            // either deal all at once or one by one
            foreach (var player in players)
            {
                player.Deal(Cards.Take(count));
                Cards.RemoveAll(c=> player.Cards.Contains(c));
            }
        }

        private void PopulateCards()
        {
            var cards = new List<Card>();
            foreach (var cardName in Enum.GetValues(typeof(CardName)).Cast<CardName>())
            {
                cards.Add(new Card {Color = CardColor.Black, Name = cardName, Shape = CardShape.Spades});
                cards.Add(new Card {Color = CardColor.Red, Name = cardName, Shape = CardShape.Hearts});
                cards.Add(new Card {Color = CardColor.Black, Name = cardName, Shape = CardShape.Diamonds });
                cards.Add(new Card {Color = CardColor.Red, Name = cardName, Shape = CardShape.Clubs});
            }
            var rand = new Random();
            Cards = cards.ProduceShuffle(rand);
        }
    }
}