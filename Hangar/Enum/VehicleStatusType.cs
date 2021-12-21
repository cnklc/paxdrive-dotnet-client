namespace Hangar.Enum
{
    public class VehicleStatusType : Enumeration
    {
        public static VehicleStatusType PointToPoint = new("Avaible", "a");

        private VehicleStatusType(string name, string value) : base(name, value)
        {
        }
    }
}