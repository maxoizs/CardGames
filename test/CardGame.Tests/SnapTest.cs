using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace CardGame.Tests
{
    [TestFixture]
    public class SnapTest
    {
        [Test]
        public void WhenSnapStart_ShouldGenerateCards()
        {
            var snap = new SnapGame();
            var player = Substitute.For<ISnapPlayer>();

            snap.Start(player);

            Assert.That(snap.Cards.Count, Is.EqualTo(52));
        }


        [Test]
        public void WhenSnapStart_ShouldDealCardsToPlayer()
        {
            var snap = new SnapGame();
            var p1 = new SnapPlayer("P1");
            var p2 = new SnapPlayer("P2");

            snap.Start(p1,p2);

            Assert.That(p1.Cards.Count, Is.EqualTo(p2.Cards.Count));
        }

        [Test]
        public void WhenSnapStart_ShouldDealDifferentCardsToPlayers()
        {
            var snap = new SnapGame();
            var p1 = new SnapPlayer("P1");
            var p2 = new SnapPlayer("P2");

            snap.Start(p1, p2);

            CollectionAssert.AreNotEqual(p1.Cards, p2.Cards);
        }

        [Test]
        public void WhenPlayerSnap_ShouldTakeGamePile()
        {
            var snap = new SnapGame();
            var p1 = new SnapPlayer("P1");
            var p2 = new SnapPlayer("P2");

            snap.Start(p1, p2);
            snap.Play(p1);

            snap.Snap(p2);
            Assert.That(p1.Cards.Count, Is.EqualTo(p2.Cards.Count-2));
        }
    }
}
