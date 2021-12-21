using Hangar.Enum;

namespace Hangar.Model
{
    public class CreateCardResponse
    {
        public string Token { get; set; }
        public decimal Total { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}