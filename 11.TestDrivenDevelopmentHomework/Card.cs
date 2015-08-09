using System;

namespace Poker
{
    public class Card : ICard
    {
        private string[] cardsSuitsAsStrings = new string[4] { "♣", "♦", "♥", "♠" };
        private string[] cardsFacesAsStrings = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }


        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return this.cardsFacesAsStrings[(int)this.Face - 2] + this.cardsSuitsAsStrings[(int)this.Suit - 1];
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            if(card == null)
            {
                throw new ArgumentException("Parameter must be a valid card");
            }

            var suit = card.Suit;
            var face = card.Face;

            if(this.Suit == suit && this.Face == face)
            {
                return true;
            }

            return false;
        }
    }
}
