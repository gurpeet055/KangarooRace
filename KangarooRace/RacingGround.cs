using System;
using System.Windows.Forms;

namespace KangarooRace
{
    public partial class RacingGround : Form
    {
        Kangaroo[] Kangaroos = new Kangaroo[4];

        PunterFactory pFactory = new PunterFactory();
        Punter[] punters = new Punter[3];

        public RacingGround()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {

            Kangaroo.StartingPosition1 = Kangaroo1.Right - racetrack.Left;
            Kangaroo.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            Kangaroos[0] = new Kangaroo() { KangarooPictureBox = Kangaroo1 };
            Kangaroos[1] = new Kangaroo() { KangarooPictureBox = Kangaroo2 };
            Kangaroos[2] = new Kangaroo() { KangarooPictureBox = Kangaroo3 };
            Kangaroos[3] = new Kangaroo() { KangarooPictureBox = Kangaroo4 };

            punters[0] = pFactory.getPunter("Gurpreet", MaximumBet, GurpreetBet); //getting Gurpreet object from factory class
            punters[1] = pFactory.getPunter("Raj", MaximumBet, RajBet); //getting Raj object from factory class
            punters[2] = pFactory.getPunter("Harman", MaximumBet, HarmanBet); //getting Harman object from factory class


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();
            }
        }

        private void JimButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[0].Cash);
        }

        private void RogerButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[1].Cash);
        }

        private void MikeButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[2].Cash);
        }

        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = string.Format("Maximum Bet: ${0}", Cash);
        }

        // setting the bet for each Punter and updating labels respectively
        private void Bets_Click(object sender, EventArgs e)
        {
            int PunterNum = 0;

            if (GurpreetButton.Checked)
            {
                PunterNum = 0;
            }
            if (RajButton.Checked)
            {
                PunterNum = 1;
            }
            if (HarmanButton.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)BettingAmount.Value, (int)KangarooNumber.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningKangaroo;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < Kangaroos.Length; i++)
                {
                    if (Kangaroo.Run(Kangaroos[i]))
                    {
                        winningKangaroo = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Kangaroo #" + winningKangaroo);
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningKangaroo); //give double amount to all who've won or deduce betted amount
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Kangaroo Kangaroo in Kangaroos)
                        {
                            Kangaroo.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  //stop punters from betting if they run out of cash
                string message = "Do you want to Play Again?";
                string title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

    }
}
