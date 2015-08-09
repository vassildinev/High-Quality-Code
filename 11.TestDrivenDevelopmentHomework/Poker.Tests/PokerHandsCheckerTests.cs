using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Poker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void TestPockerHandsChecker_IsValidShouldReturnTrueWhenHandIsValid()
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
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPockerHandsChecker_IsValidShouldReturnFalseWhenHandIsNotValidLessCardsInHand()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPockerHandsChecker_IsValidShouldReturnFalseWhenHandIsNotValidMoreCardsInHand()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPockerHandsChecker_IsValidShouldReturnFalseWhenHandIsNotValidRepeatingCardsInHand()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPockerHandsChecker_IsValidShouldReturnFalseWhenHandIsNotValidRepeatingAndLessCardsInHand()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPokerHandsChecker_IsFlushShouldReturnTrueWhenHandIsFlush()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestPokerHandsChecker_IsFlushShouldReturnFalseWhenHandIsNotFlush()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestPokerHandsChecker_IsFourOfAKindShouldReturnTrueWhenHandIsFourOfAKind()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestPokerHandsChecker_IsFourOfAKindShouldReturnFalseWhenHandIsNotFourOfAKind()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }
    }
}
