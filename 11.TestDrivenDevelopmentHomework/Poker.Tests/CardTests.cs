using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Poker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestCard_EqualsShouldReturnTrueWhenCardsAreTheSame()
        {
            var cardA = new Card(CardFace.Five, CardSuit.Diamonds);
            var cardB = new Card(CardFace.Five, CardSuit.Diamonds);

            Assert.IsTrue(cardA.Equals(cardB));
        }

        [TestMethod]
        public void TestCard_EqualsShouldReturnFalseWhenCardsAreNotTheSame()
        {
            var cardA = new Card(CardFace.Five, CardSuit.Diamonds);
            var cardB = new Card(CardFace.Five, CardSuit.Hearts);

            Assert.IsFalse(cardA.Equals(cardB));
        }

        [TestMethod]
        public void TestCard_ToStringMustReturnCorrectCardWhenCardIsValidAceOfHearts()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.AreEqual("A♥", card.ToString());
        }

        [TestMethod]
        public void TestCard_ToStringMustReturnCorrectCardWhenCardIsValid2OfDiamonds()
        {
            var card = new Card(CardFace.Two, CardSuit.Diamonds);
            Assert.AreEqual("2♦", card.ToString());
        }
    }
}
