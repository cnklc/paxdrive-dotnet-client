namespace PaxDrive.Enum
{
    public class Language : Enumeration
    {
        private Language(string name, string value) : base(name, value)
        {
        }

        public static Language Turkish = new Language("Türkçe", "tr");
        public static Language English = new Language("English", "en");
    }
}