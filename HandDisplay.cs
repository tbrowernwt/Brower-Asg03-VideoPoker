using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brower_Asg03_VideoPoker
{
    /// <summary>
    /// Static class to update the PictureBoxes based on the hand and integer provided
    /// </summary>
    internal static class HandDisplay
    {
        /// <summary>
        /// Updates the card playfield based on the state of the game.
        /// Cards that need to be "elevated" (shown as selected to toss) are based on bitwise logic - by
        /// using the lowest 5 bits of bitwiseCardsToToss as flags.
        /// Bits are right shifted to process each card slot and update the display accordingly
        /// </summary>
        /// <param name="pictureBoxesCardsHold"></param>
        /// <param name="pictureBoxesCardsToss"></param>
        /// <param name="hand"></param>
        /// <param name="bitwiseCardsToToss"></param>
        public static void updateCardPlayfield(List<PictureBox> pictureBoxesCardsHold, List<PictureBox> pictureBoxesCardsToss, Hand hand, int bitwiseCardsToToss) 
        {
            int index = 0;
            for (int i = 4; i >= 0; i--)
            {

                if (((bitwiseCardsToToss >> i) & 0b00001) == 0b00001)
                {
                    pictureBoxesCardsToss[index].Image = hand.getCardAtIndex(index).getCardFront();
                    pictureBoxesCardsToss[index].BringToFront();
                    pictureBoxesCardsHold[index].Image = null;
                }
                else
                {
                    pictureBoxesCardsHold[index].Image = hand.getCardAtIndex(index).getCardFront();
                    pictureBoxesCardsHold[index].BringToFront();
                    pictureBoxesCardsToss[index].Image = null;
                }
                index++;
            }
        }
    }
}
