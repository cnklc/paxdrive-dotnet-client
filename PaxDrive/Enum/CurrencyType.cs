namespace PaxDrive.Enum
{
    public class Currency : Enumeration
    {
        public static Currency Try = new("Try", "1");
        public static Currency Usd = new("Usd", "2");
        public static Currency Eur = new("Eur", "3");
        public static Currency Gbp = new("Gbp", "4");

        private Currency(string name, string value) : base(name, value)
        {
        }
    }
}