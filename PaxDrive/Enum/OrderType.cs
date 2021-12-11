namespace PaxDrive.Enum
{
    public class OrderType : Enumeration
    {
        private OrderType(string name, string value) : base(name, value)
        {
        }

        public static OrderType TransferDate = new OrderType("Transfer Date", "cart_task_date..ASC");
        public static OrderType TransferDateDesc = new OrderType("Transfer Date Desc", "cart_task_date..DESC");
        public static OrderType BookingDate = new OrderType("Booking Date", "cart_done_date..ASC");
        public static OrderType BookingDateDesc = new OrderType("Booking Date Desc", "cart_done_date..DESC");
    }
}