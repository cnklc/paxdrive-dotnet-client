using System.Collections.Generic;

namespace PaxDrive.Model
{
    public class CancelResponse
    {
        public bool Status { get; set; }
    }

    public class GetListResponse
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}