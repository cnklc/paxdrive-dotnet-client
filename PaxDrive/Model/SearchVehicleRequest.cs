using System;
using PaxDrive.Enum;

namespace PaxDrive.Model
{
    public class SearchVehicleRequest
    {
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public string FromPaximumId { get; set; }
        public string ToPaximumId { get; set; }
        public string FromGlobalUniqueId { get; set; }
        public string ToGlobalUniqueId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int AdultCount { get; set; }
        public int KidCount { get; set; }
        public int BabyCount { get; set; }
        public TransferType TransferType { get; set; }
        public MarkupType MarkupType { get; set; }
        public int MarkupAmount { get; set; }
    }
}