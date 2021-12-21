namespace Hangar.Model
{
    public class CheckoutResponse
    {
        public bool Status { get; set; }
        public string OrderCode { get; set; }
        public Reservation Reservation { get; set; }
    }
}