using Hangar.Enum;

namespace Hangar.Model
{
    public class GetListRequest
    {
        public int Page { get; set; }
        public OrderType OrderType { get; set; }
    }
}