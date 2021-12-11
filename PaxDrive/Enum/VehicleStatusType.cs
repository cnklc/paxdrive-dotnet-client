namespace PaxDrive.Enum
{
    public class VehicleStatusType : Enumeration
    {
        private VehicleStatusType(string name, string value) : base(name, value)
        {
        }

        public static VehicleStatusType PointToPoint = new VehicleStatusType("Avaible", "a");
    }
}