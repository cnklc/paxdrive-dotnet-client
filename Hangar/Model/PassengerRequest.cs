using Hangar.Enum;

namespace Hangar.Model
{
    public class PassengerRequest
    {
        public PassengerType PassengerType { get; set; }
        public string Name { get; set; }
        public string NationalityCode { get; set; }
        public string IdentityNumber { get; set; }
    }
}