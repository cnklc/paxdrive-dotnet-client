namespace PaxDrive.Enum
{
    public class MarkupType : Enumeration
    {
        private MarkupType(string name, string value) : base(name, value)
        {
        }

        public static MarkupType Percent = new MarkupType("Percent", "PT");
        public static MarkupType Try = new MarkupType("Try", "PC-1");
        public static MarkupType Usd = new MarkupType("Usd", "PC-2");
        public static MarkupType Eur = new MarkupType("Eur", "PC-3");
        public static MarkupType Gbp = new MarkupType("Gbp", "PC-4");
    }
}