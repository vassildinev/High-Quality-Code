using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Poker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHand_ConstructorMustThrowExceptionWhenCardListIsNull()
        {
            List<ICard> cards = null;

            var hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHand_ConstructorMustThrowExceptionWhenCardListContainsNull()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                null,
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)
            };

            var hand = new Hand(cards);
        }

        // Ensure hand ToString() returns valid results no matter the card count for a valid hand
        [TestMethod]
        public void TestHand_ToStringShouldPrintHandWhenHandIsValid5Cards()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)
            };

            var hand = new Hand(cards);

            Assert.AreEqual("A♣ A♦ A♥ A♠ 8♠", hand.ToString());
        }

        [TestMethod]
        public void TestHand_ToStringShouldPrintHandWhenHandIsValid4Cards()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            var hand = new Hand(cards);

            Assert.AreEqual("A♣ A♦ A♥ A♠", hand.ToString());
        }
        [TestMethod]
        public void TestHand_ToStringShouldPrintHandWhenHandIsValid2Cards()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);

            Assert.AreEqual("A♣ A♦", hand.ToString());
        }
    }
}
