using PaxDrive.Enum;

namespace PaxDrive.Model
{
    public class GetListRequest
    {
        public int Page { get; set; }
        public OrderType OrderType { get; set; }
    }
}