using System;
using Hangar.Enum;

namespace Hangar.Model
{
    public class SearchVehicleRequest
    {
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int AdultCount { get; set; }
        public int KidCount { get; set; }
        public int BabyCount { get; set; }
        public TransferType TransferType { get; set; } 
    }
}