using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PaxDrive;
using PaxDrive.Enum;
using PaxDrive.Model;

namespace Test
{
    public class PaxDrive
    {
        private readonly PaxDriveClient _paxDriveClient;

        public PaxDrive()
        {
            _paxDriveClient = new PaxDriveClient("http://api.paxdrive-dev.poisoft.com/v1/", "121_98cd7eacfcb2aa7d083a4de7f08b8db52849194b", Currency.Try, Language.Turkish);
        }


        [Test]
        public void Check()
        {
            var result = _paxDriveClient.Check();

            Assert.AreEqual(result.PartnerId, "72");
        }

        [Test]
        public void GetLocation()
        {
            var result = _paxDriveClient.GetLocations();
            var searchRequest = new LocationRequest
            {
                Search = "Ayt"
            };
            var result2 = _paxDriveClient.GetLocations(searchRequest);

            searchRequest = new LocationRequest
            {
                Search         = "alanya",
                FromLocationId = result2.Locations[0].Id
            };
            var result3 = _paxDriveClient.GetLocations(searchRequest);

            Assert.IsTrue(result.Locations.Count > 0);
            Assert.IsTrue(result2.Locations.Count > 0);
            Assert.IsTrue(result3.Locations.Count > 0);
        }

        [Test]
        public void SearchVehicle()
        {
            var request = new SearchVehicleRequest()
            {
                AdultCount          = 1,
                KidCount            = 1,
                BabyCount           = 0,
                TransferType        = TransferType.PointToPoint,
                MarkupType          = MarkupType.Percent,
                MarkupAmount        = 10,
                ReservationDateTime = new DateTime(2022, 1, 10),
                FromLocationId      = 136,
                ToLocationId        = 148,
            };

            var result = _paxDriveClient.SearchVehicle(request);

            Assert.IsTrue(result.Vehicles.Count > 0);
        }

        [Test]
        public void SelectVehicle()
        {
            var request = new SearchVehicleRequest()
            {
                AdultCount          = 1,
                KidCount            = 1,
                BabyCount           = 0,
                TransferType        = TransferType.PointToPoint,
                MarkupType          = MarkupType.Percent,
                MarkupAmount        = 10,
                ReservationDateTime = new DateTime(2022, 1, 10),
                FromLocationId      = 136,
                ToLocationId        = 148,
            };

            var result = _paxDriveClient.SearchVehicle(request);

            var request1 = new SelectVehicleRequest()
            {
                SearchId  = result.SearchId,
                Quantity  = 1,
                VehicleId = result.Vehicles[0].Id
            };
            request1.ExtraServices.Add(result.Vehicles[0].ExtraServices[0].Id);

            var result1 = _paxDriveClient.SelectVehicle(request1);

            Assert.IsTrue(result1.Vehicle.Id > 0);
        }

        [Test]
        public void CreateCard()
        {
            var request = new SearchVehicleRequest()
            {
                AdultCount          = 1,
                KidCount            = 1,
                BabyCount           = 0,
                TransferType        = TransferType.PointToPoint,
                MarkupType          = MarkupType.Percent,
                MarkupAmount        = 10,
                ReservationDateTime = new DateTime(2022, 1, 10),
                FromLocationId      = 136,
                ToLocationId        = 148,
            };

            var result = _paxDriveClient.SearchVehicle(request);

            var request1 = new SelectVehicleRequest()
            {
                SearchId  = result.SearchId,
                Quantity  = 1,
                VehicleId = result.Vehicles[0].Id
            };
            request1.ExtraServices.Add(result.Vehicles[0].ExtraServices[0].Id);

            var result1 = _paxDriveClient.SelectVehicle(request1);

            var card = new CreateCardRequest()
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
                Passengers = new List<PassengerRequest>()
                {
                    new PassengerRequest()
                    {
                        PassengerType   = PassengerType.Adult,
                        Name            = "Test Yetiskin",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                    new PassengerRequest()
                    {
                        PassengerType   = PassengerType.Kid,
                        Name            = "test cocuk",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                    new PassengerRequest()
                    {
                        PassengerType   = PassengerType.Baby,
                        Name            = "test bebek",
                        NationalityCode = "TR",
                        IdentityNumber  = "123"
                    },
                }
            };
            var result2 = _paxDriveClient.CreateCard(card);

            Assert.IsTrue(!string.IsNullOrEmpty(result2.Token));

            var totalPrice = result.Vehicles[0].SalesPrice + result.Vehicles[0].ExtraServices[0].SalesPrice;
            Assert.IsTrue(Math.Round(totalPrice) == Math.Round(result2.Total));
        }

        [Test]
        public void GetByCode()
        {
            var reservaation = _paxDriveClient.GetByCode("303981492");

            Assert.IsTrue(reservaation.Code == "303981492");
        }

        [Test]
        public void GetList()
        {
            var reservaations = _paxDriveClient.GetList(new GetListRequest()
            {
                OrderType = OrderType.TransferDateDesc
            });

            Assert.IsTrue(reservaations.Reservations.Count > 0);
        }
    }
}