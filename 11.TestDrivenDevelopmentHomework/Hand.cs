namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }
        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Cards list cannot be null");
                }

                for(var i = 0; i < value.Count; i++)
                {
                    if(value[i] == null)
                    {
                        throw new ArgumentException("Card list cannot contain null");
                    }
                }

                this.cards = value;
            }
        }


        public override string ToString()
        {
            var result = "";
            for(var i = 0; i < this.Cards.Count; i++)
            {
                result += (this.Cards[i].ToString() + " ");
            }

            return result.TrimEnd();
        }
    }
}
