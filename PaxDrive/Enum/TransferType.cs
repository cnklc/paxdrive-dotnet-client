namespace PaxDrive.Enum
{
    public class TransferType : Enumeration
    {
        public static TransferType PointToPoint = new("Point To Point", "D");

        private TransferType(string name, string value) : base(name, value)
        {
        }
    }
}