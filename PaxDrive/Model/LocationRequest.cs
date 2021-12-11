namespace PaxDrive.Model
{
    public class LocationRequest
    {
        public string Search { get; set; }
        public int FromLocationId { get; set; }
        public string PaximumId { get; set; }
        public string FromPaximumId { get; set; }
        public string GlobalId { get; set; }
        public string FromGlobalId { get; set; }
    }
}