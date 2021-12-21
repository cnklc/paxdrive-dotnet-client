using System;
using System.Collections.Generic;
using NUnit.Framework;
using Hangar;
using Hangar.Enum;
using Hangar.Model;

namespace Test
{
    public class Hangar
    {
        private readonly HangarClient _hangarClient;

        public Hangar()
        {
           
        }


        [Test]
        public void Check()
        {
            var result = _hangarClient.Check();

            Assert.AreEqual(result.PartnerId, "225");
        }

        [Test]
        public void GetLocation()
        {
            var result = _hangarClient.GetLocations();
            var searchRequest = new LocationRequest
            {
                Search = "Ayt"
            };
            var result2 = _hangarClient.GetLocations(searchRequest);

            searchRequest = new LocationRequest
            {
                Search         = "alanya",
                FromLocationId = result2.Locations[0].Id
            };
            var result3 = _hangarClient.GetLocations(searchRequest);

            Assert.IsTrue(result.Locations.Count > 0);
            Assert.IsTrue(result2.Locations.Count > 0);
            Assert.IsTrue(result3.Locations.Count > 0);
        }

        [Test]
        public void SearchVehicle()
        {
            var request = createSearchVehicleRequest();

            var result = _hangarClient.SearchVehicle(request);

            Assert.IsTrue(result.Vehicles.Count > 0);
        }

        [Test]
        public void SelectVehicle()
        {
            var request = createSearchVehicleRequest();

            var result = _hangarClient.SearchVehicle(request);

            var request1 = new SelectVehicleRequest
            {
                SearchId  = result.SearchId,
                Quantity  = 1,
                VehicleId = result.Vehicles[0].Id
            };
            // request1.ExtraServices.Add(result.Vehicles[0].ExtraServices[0].Id);

            var result1 = _hangarClient.SelectVehicle(request1);

            Assert.IsTrue(result1.Vehicle.Id > 0);
        }

        [Test]
        public void CreateCard()
        {
            var request = createSearchVehicleRequest();

            var result = _hangarClient.SearchVehicle(request);

            var request1 = new SelectVehicleRequest
            {
                SearchId  = result.SearchId,
                Quantity  = 1,
                VehicleId = result.Vehicles[0].Id
            };
            // request1.ExtraServices.Add(result.Vehicles[0].ExtraServices[0].Id);

            var result1 = _hangarClient.SelectVehicle(request1);

            var card = new CreateCardRequest
            {
                SelectId                 = result1.SelectId,
                FromLocationName         = "FromLocationName",
                FromDescription          = "FromDescription",
                fromMessage              = "fromMessage",
                ToLocationName           = "ToLocationName",
                ToDescription            = "ToDescription",
                ToMessage                = "ToMessage",
                PassengerName            = "PassengerName",
                PassengerEmail           = "PassengerEmail",
                PassengerPhone           = "PassengerPhone",
                PassengerNationalityCode = "TR",
                PassengerIdentityNumber  = "5555555555",
                Passengers = new List<PassengerRequest>
                {
                    new()
                    {
                        PassengerType   = PassengerType.Adult,
                        Name            = "Test Yetiskin",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                    new()
                    {
                        PassengerType   = PassengerType.Kid,
                        Name            = "test cocuk",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                    new()
                    {
                        PassengerType   = PassengerType.Baby,
                        Name            = "test bebek",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    }
                }
            };
            var result2 = _hangarClient.CreateCard(card);

            Assert.IsTrue(!string.IsNullOrEmpty(result2.Token));

            var totalPrice = result.Vehicles[0].SalesPrice; //+ result.Vehicles[0].ExtraServices[0].SalesPrice;
            Assert.IsTrue(Math.Round(totalPrice) == Math.Round(result2.Total));
        }

        [Test]
        public void Checkout()
        {
            var request = createSearchVehicleRequest();
        
            var result = _hangarClient.SearchVehicle(request);
        
            var request1 = new SelectVehicleRequest
            {
                SearchId  = result.SearchId,
                Quantity  = 1,
                VehicleId = result.Vehicles[0].Id
            };
            // request1.ExtraServices.Add(result.Vehicles[0].ExtraServices[0].Id);
        
            var result1 = _hangarClient.SelectVehicle(request1);
        
            var card = new CreateCardRequest
            {
                SelectId                 = result1.SelectId,
                FromLocationName         = "FromLocationName",
                FromDescription          = "FromDescription",
                fromMessage              = "fromMessage",
                ToLocationName           = "ToLocationName",
                ToDescription            = "ToDescription",
                ToMessage                = "ToMessage",
                PassengerName            = "PassengerName",
                PassengerEmail           = "PassengerEmail",
                PassengerPhone           = "PassengerPhone",
                PassengerNationalityCode = "TR",
                PassengerIdentityNumber  = "5555555555",
                Passengers = new List<PassengerRequest>
                {
                    new()
                    {
                        PassengerType   = PassengerType.Adult,
                        Name            = "Test Yetiskin",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                    new()
                    {
                        PassengerType   = PassengerType.Kid,
                        Name            = "test cocuk",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                    new()
                    {
                        PassengerType   = PassengerType.Baby,
                        Name            = "test bebek",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    }
                }
            };
            var result2 = _hangarClient.CreateCard(card);
        
            Assert.IsTrue(!string.IsNullOrEmpty(result2.Token));
        
            var totalPrice = result.Vehicles[0].SalesPrice; //+ result.Vehicles[0].ExtraServices[0].SalesPrice;
            Assert.IsTrue(Math.Round(totalPrice) == Math.Round(result2.Total));
        
            var checkoutResult = _hangarClient.Checkout(new CheckoutRequest() {Token = result2.Token});
            
            Assert.IsTrue(checkoutResult.Status);
            Assert.IsTrue(!string.IsNullOrEmpty(checkoutResult.Reservation.Code));
        }

        [Test]
        public void GetByCode()
        {
            var reservaation = _hangarClient.GetByCode("200103506");

            Assert.IsTrue(reservaation.Code == "200103506");
        }

        [Test]
        public void GetList()
        {
            var reservaations = _hangarClient.GetList(new GetListRequest
            {
                OrderType = OrderType.TransferDateDesc
            });

            Assert.IsTrue(reservaations.Reservations.Count > 0);
        }

        [Test]
        public void Cancel()
        {
            var orderCode = "200104506";

            var reservation = _hangarClient.GetByCode(orderCode);
            Assert.IsNotNull(reservation);
            
            var result = _hangarClient.CancelReservation(orderCode);
            Assert.IsTrue(result.Status);
            
        }


        private SearchVehicleRequest createSearchVehicleRequest()
        {
            return new SearchVehicleRequest
            {
                AdultCount          = 1,
                KidCount            = 1,
                BabyCount           = 0,
                TransferType        = TransferType.PointToPoint,
                ReservationDateTime = new DateTime(2022, 2, 2),
                FromLocationId      = 9, // Ayt
                ToLocationId        = 92 // Alanya 
            };
        }
    }
}