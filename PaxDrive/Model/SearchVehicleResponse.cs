using System;
using System.Collections.Generic;
using PaxDrive.Enum;

namespace PaxDrive.Model
{
    public class SearchVehicleResponse
    {
        public int SearchId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public string FromGlobalUniqueId { get; set; }
        public string ToGlobalUniqueId { get; set; }
        public string FromPaximumId { get; set; }
        public string ToPaximumId { get; set; }
        public string MeetingImage { get; set; }
        public string MeetingDescription { get; set; }
        public string FromLocationName { get; set; }
        public string ToLocationName { get; set; }
        public string ZoneName { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string Distance { get; set; }
        public string RoadTime { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string PassengerCount { get; set; }
        public string SuitcaseCount { get; set; }
        public string BookingTime { get; set; }
        public string FreeCancelTime { get; set; }
        public string FreeChangeTime { get; set; }
        public int Quantity { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal Price { get; set; }
        public decimal SalesPrice { get; set; }
        public VehicleStatusType VehicleStatusType { get; set; }
        public List<ExtraService> ExtraServices { get; set; }
    }

    public class ExtraService
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal Price { get; set; }
        public decimal SalesPrice { get; set; }
    }
}