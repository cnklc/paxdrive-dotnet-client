namespace PaxDrive.Enum
{
    public class Currency : Enumeration
    {
        private Currency(string name, string value) : base(name, value)
        {
        }

        public static Currency Try = new Currency("Try", "1");
        public static Currency Usd = new Currency("Usd", "2");
        public static Currency Eur = new Currency("Eur", "3");
        public static Currency Gbp = new Currency("Gbp", "4");
    }
}