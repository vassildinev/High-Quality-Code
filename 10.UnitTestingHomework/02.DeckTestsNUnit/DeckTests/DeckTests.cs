namespace DeckTests
{
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        private const int allCardsCount = 24;

        [Test]
        public void TestDeck_ConstructorShouldGenerateANewFullSantaseDeck()
        {
            var deck = new Deck();
            Assert.AreEqual(allCardsCount, deck.CardsLeft);
        }

        [Test]
        public void TestDeck_ChangeTrumpCardShouldChangeTrumpCard()
        {
            var deck = new Deck();
            var newTrump = new Card(CardSuit.Spade, CardType.Ace);

            deck.ChangeTrumpCard(newTrump);
            Assert.AreSame(newTrump, deck.GetTrumpCard);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(12)]
        [TestCase(24)]
        public void TestDeck_GetNextCardShouldReduceDeckCardsCount(int cardsToRemove)
        {
            var deck = new Deck();

            for (int i = 0; i < cardsToRemove; i++)
            {
                deck.GetNextCard();
            }
            
            Assert.AreEqual(allCardsCount - cardsToRemove, deck.CardsLeft);
        }

        [Test, ExpectedException(typeof(InternalGameException))]
        public void TestDeck_GetNextCardShouldThrowIfAppliedMoreThanTheTotalAmountOfCards()
        {
            var deck = new Deck();
            var totalCards = 24;
            var cardsToRemove = totalCards + totalCards;

            for (int i = 0; i < cardsToRemove; i++)
            {
                deck.GetNextCard();
            }
        }
    }
}
