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
        public Hand getHand()
        {
            return hand;
        }
        public bool getIfGameInPlay()
        {
            return isGameInPlay;
        }
        public void processAndReplaceDiscards(int bitwiseToss)
        {
            /*
             * 
             * How this function works:
             * The cards to toss is received in an int with each of the five least 
             * significant bits of the int representing a bool
             * 0 = keep the card. 1 = toss the card.
             * Evaluate the least significant bit (1's place) using AND. If bit is 
             * set, remove card at index (i)
             * Decrement i after evaluation then shift bits right and repeat.
             * Bits are ordered based on their position on the playfield
             * Example: Far left card (PictureBoxCard1) is 0b10000
             * Far right card (PictureBoxCard5) is 0b00001 etc.
             *
             * Loop will break after all set set bits have been shifted out of the byte - this
             * means all cards set to discard have been tossed.
             * 
             */
            int CountOfTossed = 0;
            int CardsToToss = 0b11111 & bitwiseToss; // In case someone tries to get crafty...
            int i = 4;
            while(CardsToToss > 0)
            {
                if ((CardsToToss & 0b00001) == 1)
                {
                    hand.tossCardAtIndex(i);
                    CountOfTossed++;
                    i--;
                }
                else
                {
                    i--;
                }
                CardsToToss = CardsToToss >> 1;
            }
            foreach(Card c in cardDeck.DealCards(CountOfTossed))
            {
                hand.addCardToHand(c);
            }
            isGameInPlay = false;
        }
    }
}
