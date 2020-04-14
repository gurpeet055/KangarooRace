using System;
using System.Windows.Forms;

namespace KangarooRace
{
    public class PunterFactory
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "gurpreet":
                    p = new Gurpreet(null, MaximumBet, 50, bet);
                    break;

                case "raj":
                    p = new Raj(null, MaximumBet, 50, bet);
                    break;

                case "harman":
                    p = new Harman(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.setPunterName();
            return p;
        }
    }

    public class Gurpreet : Punter
    {
        public Gurpreet(Bet MyBet, Label MaximumBet, int Cash, Label MyLabel) : base(MyBet, MaximumBet, Cash, MyLabel)
        {
        }

        public override void setPunterName()
        {
            Name = "Gurpreet";
        }
    }
    public class Harman : Punter
    {
        public Harman(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setPunterName()
        {
            Name = "Harman";
        }
    }
    public class Raj : Punter
    {
        public Raj(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setPunterName()
        {
            Name = "Raj";
        }
    }
}
