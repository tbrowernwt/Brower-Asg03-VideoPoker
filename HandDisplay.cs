using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brower_Asg03_VideoPoker
{
    internal static class HandDisplay
    {
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
