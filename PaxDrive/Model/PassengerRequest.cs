using PaxDrive.Enum;

namespace PaxDrive.Model
{
    public class PassengerRequest
    {
        public PassengerType PassengerType { get; set; }
        public string Name { get; set; }
        public string NationalityCode { get; set; }
        public string IdentityNumber { get; set; }
    }
}