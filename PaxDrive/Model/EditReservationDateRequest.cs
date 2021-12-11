using System;

namespace PaxDrive.Model
{
    public class EditReservationDateRequest
    {
        public string OrderCode { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}