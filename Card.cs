using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brower_Asg03_VideoPoker
{
    public class Card
    {
        public enum CardSuit
        {
            Clubs = 'C',
            Diamonds = 'D',
            Hearts = 'H',
            Spades = 'S'
        }
        public enum CardRank
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }
        private CardSuit suit;
        private CardRank rank;
        private Image cardFront;
        public Card(CardSuit suit, int rank, Image cardFront)
        {
            this.suit = suit;
            this.rank = (CardRank)rank;
            this.cardFront = cardFront;
        }

        public CardSuit getSuit() { return suit; }
        public CardRank getRank() { return rank; }
        public Image getCardFront() { return cardFront; }
    }
}
