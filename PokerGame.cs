using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brower_Asg03_VideoPoker
{
    public class PokerGame
    {
        private Deck cardDeck;
        private Hand hand;
        private bool isGameInPlay = true;
        public PokerGame(ImageList CardFronts) 
        {
            hand = new Hand();
            cardDeck = new Deck(CardFronts);
            foreach(Card card in cardDeck.DealCards(5))
            {
                hand.addCardToHand(card);
            }
        }
        /// <summary>
        /// Provides access to the PokerGame's instance of the Hand class and it's methods
        /// </summary>
        /// <returns>The instance of the Hand class</returns>
        public Hand getHand()
        {
            return hand;
        }

        public bool getIfGameInPlay()
        {
            return isGameInPlay;
        }
        /// <summary>
        /// Disposes of and replaces cards flagged by the player to toss.
        /// </summary>
        /// <param name="bitwiseToss">
        /// The integer interpretation of the set and clear bits representing 
        /// cards that need to be tossed (bit set) and kept (bit clear)
        /// </param>
        public void processAndReplaceDiscards(int bitwiseToss)
        {
            /*
             * 
             * How this function works:
             * 0b0 = keep the card. 0b1 = toss the card.
             * Bits of CardsToToss are ordered based on their position on the playfield
             * Example: Far left card (PictureBoxCard1) is 0b10000
             * Far right card (PictureBoxCard5) is 0b00001 etc.
             * Evaluate the least significant bit (1's place) using the AND operation. If bit is 
             * set, remove card at index (i)
             * Decrement i after evaluation then shift bits right.
             * If the last set bit is shifted out of CardsToToss, the loop breaks. Otherwise repeat.
             *
             * Loop will break after all set set bits have been shifted out (CardsToToss = 0) - this
             * means all cards set to discard have been tossed
             * 
             */
            int countOfTossed = 0;
            int cardsToToss = 0b11111 & bitwiseToss;
            int i = 4;
            while(cardsToToss > 0)
            {
                if ((cardsToToss & 0b00001) == 1)
                {
                    hand.tossCardAtIndex(i);
                    countOfTossed++;
                    i--;
                }
                else
                {
                    i--;
                }
                cardsToToss = cardsToToss >> 1;
            }
            foreach(Card c in cardDeck.DealCards(countOfTossed))
            {
                hand.addCardToHand(c);
            }
            isGameInPlay = false;
        }
    }
}
