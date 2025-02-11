using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brower_Asg03_VideoPoker
{
    public partial class Form1 : Form
    {
        int discardData = 0b11111;
        private int credits = 100;
        private int bet = 0;
        private PokerGame game;
        private List<PictureBox> holdPictureBoxes = new List<PictureBox>();
        private List<PictureBox> discardPictureBoxes = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            holdPictureBoxes.Add(pictureBoxCard1Hold);
            holdPictureBoxes.Add(pictureBoxCard2Hold);
            holdPictureBoxes.Add(pictureBoxCard3Hold);
            holdPictureBoxes.Add(pictureBoxCard4Hold);
            holdPictureBoxes.Add(pictureBoxCard5Hold);
            discardPictureBoxes.Add(pictureBoxCard1);
            discardPictureBoxes.Add(pictureBoxCard2);
            discardPictureBoxes.Add(pictureBoxCard3);
            discardPictureBoxes.Add(pictureBoxCard4);
            discardPictureBoxes.Add(pictureBoxCard5);
        }

        /*
         * 
         *  When user clicks on a card to opt to discard (or click again to opt to keep it)
         *  These functions will perform bitwise operators 
         * 
         */
        public void flipBitOne()
        {
            discardData = discardData ^ 0b00001;
            updatePlayfield();
        }
        public void flipBitTwo()
        {
            discardData = discardData ^ 0b00010;
            updatePlayfield();
        }
        public void flipBitThree()
        {
            discardData = discardData ^ 0b00100;
            updatePlayfield();
        }
        public void flipBitFour()
        {
            discardData = discardData ^ 0b01000;
            updatePlayfield();
        }
        public void flipBitFive()
        {
            discardData = discardData ^ 0b10000;
            updatePlayfield();
        }

        private void buttonMultiFunction_Click(object sender, EventArgs e)
        {
            if(game == null)
            {
                discardData = 0b11111;
                bet = (int)numericUpDownWager.Value;
                credits -= bet;
                numericUpDownWager.Enabled = false;
                game = new PokerGame(imageListCardImages);
            }
            else if (game.getIfGameInPlay())
            {
                game.processAndReplaceDiscards(discardData);
                discardData = 0;
                processAndUpdateGameResult();
                numericUpDownWager.Enabled = true;
                if(credits == 0)
                {
                    labelFinalGameStatus.Text = "Bankrupt!";
                    numericUpDownWager.Enabled = false;
                    buttonMultiFunction.Enabled = false;
                }
                else if(numericUpDownWager.Value > credits)
                {
                    numericUpDownWager.Value = credits;
                }
                numericUpDownWager.Maximum = credits;
            }
            else
            {
                discardData = 0b11111;
                bet = (int)numericUpDownWager.Value;
                credits -= bet;
                numericUpDownWager.Enabled = false;
                game = new PokerGame(imageListCardImages);
            } 
            updatePlayfield();
        }
        private void updatePlayfield()
        {
            /*
             * 
             *  i is used to iterate through the bit shifts
             *  index is used to reference the position in the playfield
             *  
             *  index and bitshift table is below, with bitshift being top, index (position on table) being bottom
             *  
             *  4 3 2 1 0
             *  0 1 2 3 4 
             * 
             */
            int index = 0;
            if (game.getIfGameInPlay())
            {
                labelFinalGameStatus.Text = "Select the cards you wish to keep.";
                if (discardData > 0)
                {
                    buttonMultiFunction.Text = "Toss cards";
                }
                else
                {
                    buttonMultiFunction.Text = "Hold all cards";
                }
            }
            else
            {
                buttonMultiFunction.Text = "Place bet";
            }
            for(int i = 4; i >= 0; i--)
            {
                if(((discardData >> i) & 0b00001) == 0b00001)
                {
                    discardPictureBoxes[index].Image = game.getHand()[index].getCardFront();
                    discardPictureBoxes[index].BringToFront();
                    holdPictureBoxes[index].Image = null;
                }
                else
                {
                    holdPictureBoxes[index].Image = game.getHand()[index].getCardFront();
                    holdPictureBoxes[index].BringToFront();
                    discardPictureBoxes[index].Image = null;
                }
                index++;
            }
            labelCreditsAmount.Text = credits.ToString();
        }
        private void processAndUpdateGameResult()
        {
            List<String> rankAndSuitStrings = game.getRankSuitStringList();
            PokerScore pokerScore = new PokerScore(rankAndSuitStrings[0], rankAndSuitStrings[1], rankAndSuitStrings[2], rankAndSuitStrings[3], rankAndSuitStrings[4]);
            if (pokerScore.getPayoffRatio() > 0)
            {
                labelFinalGameStatus.Text = pokerScore.scoreHand() + " pays " + pokerScore.getPayoffRatio().ToString() + " to 1";
            }
            else
            {
                labelFinalGameStatus.Text = pokerScore.scoreHand();
            }
            int payout = bet * pokerScore.getPayoffRatio();
            credits += payout;
        }
        private void pictureBoxCard1_Click(object sender, EventArgs e)
        {
            if(game.getIfGameInPlay())
            {
                flipBitFive();
            }
            
        }

        private void pictureBoxCard2_Click(object sender, EventArgs e)
        {
            if (game.getIfGameInPlay())
            {
                flipBitFour();
            }

        }

        private void pictureBoxCard3_Click(object sender, EventArgs e)
        {
            if (game.getIfGameInPlay())
            {
                flipBitThree();
            }
        }

        private void pictureBoxCard4_Click(object sender, EventArgs e)
        {
            if (game.getIfGameInPlay())
            {
                flipBitTwo();
            }
        }

        private void pictureBoxCard5_Click(object sender, EventArgs e)
        {
            if (game.getIfGameInPlay())
            {
                flipBitOne();
            }
        }
    }
}
