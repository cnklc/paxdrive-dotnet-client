using System.Collections.Generic; 

namespace Hangar.Model
{
    public class EditCardRequest
    {
        public string OrderCode { get; set; }
        public string FromDescription { get; set; }
        public string fromMessage { get; set; }
        public string ToDescription { get; set; }
        public string ToMessage { get; set; }
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhone { get; set; }
        public string PassengerNationalityCode { get; set; }
        public string PassengerIdentityNumber { get; set; }
        public string Note { get; set; }

        public List<PassengerRequest> Passengers { get; set; } = new();
    }
}