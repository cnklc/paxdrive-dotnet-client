namespace Hangar.Enum
{
    public class Language : Enumeration
    {
        public static Language Turkish = new("Türkçe", "tr");
        public static Language English = new("English", "en");

        private Language(string name, string value) : base(name, value)
        {
        }
    }
}