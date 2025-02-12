using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brower_Asg03_VideoPoker
{
    public class Hand
    {
        private List<Card> cardsInHand = new List<Card>();

        public Hand()
        {
        }
        public void addCardToHand(Card c)
        {
            cardsInHand.Add(c);
        }
        public Card getCardAtIndex(int index)
        {
            return cardsInHand[index];
        }
        public void tossCardAtIndex(int index)
        {
            cardsInHand.RemoveAt(index);
        }
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
