using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brower_Asg03_VideoPoker
{
    public class Deck
    {
        private List<Card> cardsInDeck = new List<Card>();
        private Random rng = new Random();
        /// <summary>
        /// Construct a deck containing a single instance of each
        /// of the 52 cards. 
        /// </summary>
        /// <param name="cardFronts">ImageList of image assets for card front.</param>
        public Deck(ImageList cardFronts)
        {
            loadDeck(cardFronts);
        }
        int imageIndex = 0;
        Card card;
        private void loadDeck(ImageList cardFronts)
        {
            cardsInDeck.Clear();
            for (int i = 1; i <= 13; i++)
            {
                card = new Card(Card.CardSuit.Clubs, i, cardFronts.Images[imageIndex]);
                cardsInDeck.Add(card);
                imageIndex++;

                card = new Card(Card.CardSuit.Diamonds, i, cardFronts.Images[imageIndex]);
                cardsInDeck.Add(card);
                imageIndex++;

                card = new Card(Card.CardSuit.Hearts, i, cardFronts.Images[imageIndex]);
                cardsInDeck.Add(card);
                imageIndex++;

                card = new Card(Card.CardSuit.Spades, i, cardFronts.Images[imageIndex]);
                cardsInDeck.Add(card);
                imageIndex++;
            }
        }
        public List<Card> DealCards(int numberOfCards)
        {
            List<Card> deal = new List<Card>();
            for(int i = 0; i < numberOfCards; i++)
            {
                int rand = rng.Next(cardsInDeck.Count);
                deal.Add(cardsInDeck[rand]);
                cardsInDeck.RemoveAt(rand);
            }

            return deal;
        }
        
    }
}
