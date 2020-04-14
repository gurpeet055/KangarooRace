namespace KangarooRace
{
    public class Bet
    {
        public int Amount;
        public int KangarooNum;
        public Punter Bettor;

        public Bet(int Amount, int KangarooNum, Punter Bettor)
        {
            this.Amount = Amount;
            this.KangarooNum = KangarooNum;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                description = string.Format("{0} bets {1} on Kangaroo #{2}",
                    Bettor.Name, Amount, KangarooNum);
            }
            else
            {
                description = string.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

        public int Pay(int Winner)
        {
            if (KangarooNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
