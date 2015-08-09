using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var numberOfCards = hand.Cards.Count;
            if(numberOfCards != 5)
            {
                return false;
            }

            for(var i = 0; i < hand.Cards.Count; i++)
            {
                for (var j = 0; j < hand.Cards.Count; j++)
                {
                    if(j != i)
                    {
                        if(hand.Cards[j].Equals(hand.Cards[i]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var cardsCount = new int[13];
            for(var i = 0; i < hand.Cards.Count; i++)
            {
                cardsCount[(int)hand.Cards[i].Face - 2]++;
            }

            var max = cardsCount[0];
            for(var i = 0; i < cardsCount.Length; i++)
            {
                if (cardsCount[i] > max)
                {
                    max = cardsCount[i];
                }
            }

            if(max == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            var suit = hand.Cards[0].Suit;
            for(var i = 1; i < hand.Cards.Count; i++)
            {
                if(hand.Cards[i].Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
