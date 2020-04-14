using System;
using System.Drawing;
using System.Windows.Forms;

namespace KangarooRace
{
    public class Kangaroo
    {
        private static int StartingPosition;
        private static int RacetrackLength;
        public PictureBox KangarooPictureBox = null;
        public int Location = 0;
        public static Random MyRandom = new Random(); //declared random object as static to avoid same random number

        public static int StartingPosition1 { get => StartingPosition; set => StartingPosition = value; }
        public static int RacetrackLength1 { get => RacetrackLength; set => RacetrackLength = value; }

        // generation across all Kangaroo objects

        public static bool Run(Kangaroo obj)
        {
            int distance = MyRandom.Next(2, 6);
            if (obj.KangarooPictureBox != null)
                obj.MoveKangarooPictureBox(distance);

            obj.Location += distance;
            if (obj.Location >= (RacetrackLength1 - StartingPosition1))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            MoveKangarooPictureBox(-Location); //reset location to -ve distance ie. to starting point
            Location = 0;

        }

        public void MoveKangarooPictureBox(int distance)
        {
            Point p = KangarooPictureBox.Location;
            p.X += distance;
            KangarooPictureBox.Location = p; //move Kangaroo in x-axis
        }
    }
}
