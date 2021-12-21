using System;

namespace Hangar.Model
{
    public class EditReservationDateRequest
    {
        public string OrderCode { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}