using System;
using System.Collections.Generic;
using Hangar.Enum;

namespace Hangar.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public TransferType TransferType { get; set; }
        public string FromLocationName { get; set; }
        public string FromDescription { get; set; }

        public object FromMessage { get; set; }

        // public string vbook_fr_type { get; set; }
        // public string vbook_fr_type_r { get; set; }
        public string ToLocationName { get; set; }
        public string ToDescription { get; set; }

        public object ToMessage { get; set; }

        // public string vbook_to_type { get; set; }
        // public string vbook_to_type_r { get; set; }
        public DateTime ReservationDate { get; set; }
        public string PassengerName { get; set; }
        public string PassengerIdentityNumber { get; set; }

        public string PassengerNationalityCode { get; set; }

        // public string vbook_nationR { get; set; }
        public string PassengerPhone { get; set; }

        public string PassengerEmail { get; set; }

        // public object vbook_driver_x_ { get; set; }
        // public int vbook_pax_adt { get; set; }
        // public object vbook_pax_kid { get; set; }
        // public object vbook_pax_bby { get; set; }
        // public object vbook_note_ur { get; set; }
        public VehicleType VehicleType { get; set; }
        // public string vbook_info_max_pax { get; set; }
        // public string vbook_info_max_suitcase { get; set; }
        // public string vbook_info_hour_freeCancel { get; set; }
        // public string vbook_info_hour_freeChange { get; set; }
        // public object vbook_info_pax_name_ { get; set; }
        // public object vbook_info_pax_idno_ { get; set; }
        // public object vbook_info_pax_nation_ { get; set; }
        // public List<object> vbook_info_t_ { get; set; }
        // public VbookFeed vbook_feed_ { get; set; }
        // public string vbook_hash { get; set; }

        public List<Card> Cards { get; set; }
    }

    public class Card
    {
        public int Id { get; set; }
    }
}