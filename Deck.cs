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
        private List<Card> CardsInDeck = new List<Card>();
        private Random Rng = new Random();
        public Deck(ImageList cardFronts)
        {
            LoadDeck(cardFronts);
        }
        int imageIndex = 0;
        Card card;
        private void LoadDeck(ImageList cardFronts)
        {
            CardsInDeck.Clear();
            for (int i = 1; i <= 13; i++)
            {
                card = new Card(Card.CardSuit.Clubs, i, cardFronts.Images[imageIndex]);
                CardsInDeck.Add(card);
                imageIndex++;

                card = new Card(Card.CardSuit.Diamonds, i, cardFronts.Images[imageIndex]);
                CardsInDeck.Add(card);
                imageIndex++;

                card = new Card(Card.CardSuit.Hearts, i, cardFronts.Images[imageIndex]);
                CardsInDeck.Add(card);
                imageIndex++;

                card = new Card(Card.CardSuit.Spades, i, cardFronts.Images[imageIndex]);
                CardsInDeck.Add(card);
                imageIndex++;
            }
        }
        public List<Card> DealCards(int numberOfCards)
        {
            List<Card> Deal = new List<Card>();
            for(int i = 0; i < numberOfCards; i++)
            {
                int rand = Rng.Next(CardsInDeck.Count);
                Deal.Add(CardsInDeck[rand]);
                CardsInDeck.RemoveAt(rand);
            }

            return Deal;
        }
        
    }
}
