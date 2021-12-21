using System.Collections.Generic;

namespace Hangar.Model
{
    public class LocationResponse
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public List<Location> Locations { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string PaximumId { get; set; }
        public string GlobalUniqueId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PointId { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
    }
}