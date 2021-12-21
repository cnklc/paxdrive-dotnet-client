using System.Collections.Generic;

namespace Hangar.Model
{
    public class SelectVehicleRequest
    {
        public int SearchId { get; set; }
        public int VehicleId { get; set; }
        public int Quantity { get; set; }
        public List<int> ExtraServices { get; set; } = new();
    }
}