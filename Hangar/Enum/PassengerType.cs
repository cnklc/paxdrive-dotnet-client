namespace Hangar.Enum
{
    public class PassengerType : Enumeration
    {
        public static PassengerType Adult = new("Adult", "adl");
        public static PassengerType Kid = new("Kid", "kid");
        public static PassengerType Baby = new("Baby", "bby");

        private PassengerType(string name, string value) : base(name, value)
        {
        }
    }
}