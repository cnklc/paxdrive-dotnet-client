namespace Hangar.Enum
{
    public class OrderType : Enumeration
    {
        public static OrderType TransferDate = new("Transfer Date", "cart_task_date..ASC");
        public static OrderType TransferDateDesc = new("Transfer Date Desc", "cart_task_date..DESC");
        public static OrderType BookingDate = new("Booking Date", "cart_done_date..ASC");
        public static OrderType BookingDateDesc = new("Booking Date Desc", "cart_done_date..DESC");

        private OrderType(string name, string value) : base(name, value)
        {
        }
    }
}