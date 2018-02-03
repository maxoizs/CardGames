using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CardGame.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void WhenPlayerDeal_ShouldFlushCardsWithNewDeal()
        {
            var player = new SnapPlayer( "P1");

            var card = new Card {Color = CardColor.Black, Shape = CardShape.Clubs, Name = CardName.Five};
            player.Deal(new List<Card> {card });

            var card2 = new Card { Color = CardColor.Black, Shape = CardShape.Clubs, Name = CardName.Five };
            player.Deal(new List<Card> { card2 });

            Assert.That(player.Cards.First(), Is.EqualTo(card2));
            Assert.That(player.Cards, Has.Count.EqualTo(1));
        }

        [Test]
        public void WhenPlayerSnap_ShouldIncreaseHisCards()
        {
            var player = new SnapPlayer("P1");
            var card = new Card { Color = CardColor.Black, Shape = CardShape.Clubs, Name = CardName.Five };
            player.Deal(new List<Card> { card });

            player.Snap(new List<Card> {card});

            Assert.That(player.Cards.First(), Is.EqualTo(card));
            Assert.That(player.Cards, Has.Count.EqualTo(2));}


        [Test]
        public void WhenPlayerPlay_ShouldDecreaseHisCards()
        {
            var player = new SnapPlayer("P2" );
            var card = new Card { Color = CardColor.Black, Shape = CardShape.Clubs, Name = CardName.Five };
            var card2 = new Card { Color = CardColor.Red, Shape = CardShape.Clubs, Name = CardName.Ten };
            player.Deal(new List<Card> { card, card2 });

            var result = player.Play();

            Assert.That(player.Cards, Has.Count.EqualTo(1));
            Assert.That(result, Is.EqualTo(card2));
        }
    }
}