namespace Hangar.Enum
{
    public class MarkupType : Enumeration
    {
        public static MarkupType Percent = new("Percent", "PT");
        public static MarkupType Try = new("Try", "PC-1");
        public static MarkupType Usd = new("Usd", "PC-2");
        public static MarkupType Eur = new("Eur", "PC-3");
        public static MarkupType Gbp = new("Gbp", "PC-4");

        private MarkupType(string name, string value) : base(name, value)
        {
        }
    }
}