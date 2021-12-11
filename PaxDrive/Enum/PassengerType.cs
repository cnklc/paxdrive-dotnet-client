namespace PaxDrive.Enum
{
    public class PassengerType : Enumeration
    {
        private PassengerType(string name, string value) : base(name, value)
        {
        }

        public static PassengerType Adult = new PassengerType("Adult", "adl");
        public static PassengerType Kid = new PassengerType("Kid", "kid");
        public static PassengerType Baby = new PassengerType("Baby", "bby");
    }
}