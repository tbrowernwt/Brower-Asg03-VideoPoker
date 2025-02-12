using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brower_Asg03_VideoPoker
{
    public class Hand
    {
        /// <summary>
        /// Hand class to manage cards
        /// </summary>
        private List<Card> cardsInHand = new List<Card>();

        public Hand()
        {
        }
        /// <summary>
        /// Add card to card list
        /// </summary>
        /// <param name="c">Card that needs to be added</param>
        public void addCardToHand(Card c)
        {
            cardsInHand.Add(c);
        }
        /// <summary>
        /// Get the instance of a card at index in the 
        /// Card list instance
        /// </summary>
        /// <param name="index">The index of the card to grab</param>
        /// <returns>Instance of the card at index</returns>
        public Card getCardAtIndex(int index)
        {
            return cardsInHand[index];
        }
        /// <summary>
        /// Discard a card at index in the card list instance
        /// </summary>
        /// <param name="index">Index of the card to toss</param>
        public void tossCardAtIndex(int index)
        {
            cardsInHand.RemoveAt(index);
        }
        /// <summary>
        /// Create a list of Strings that represents the state of the hand
        /// (the cards in the card list) so it can be passed to the PokerScore
        /// class for scoring
        /// </summary>
        /// <returns>List of strings in the form of "[int or char of Rank][char of Suit]</returns>
        public List<String> getRankSuitStringList()
        {
            List<String> listOfCardStrings = new List<String>();
            foreach (Card c in cardsInHand)
            {
                String s = ((int)c.getRank()).ToString() + ((char)c.getSuit()).ToString();
                listOfCardStrings.Add(s);
            }
            return listOfCardStrings;
        }
    }
}
