namespace PaxDrive.Enum
{
    public class TransferType : Enumeration
    {
        private TransferType(string name, string value) : base(name, value)
        {
        }

        public static TransferType PointToPoint = new TransferType("Point To Point", "D");
    }
}