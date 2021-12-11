using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using PaxDrive.Enum;
using PaxDrive.Exception;
using PaxDrive.Model;
using PaxDrive.Model.PaxDrive;
using Vehicle = PaxDrive.Model.Vehicle;

namespace PaxDrive
{
    public class PaxDriveClient
    {
        private readonly string _baseUrl;
        private readonly Currency _currency;

        private readonly HttpClient _httpClient;
        private readonly Language _language;
        private readonly string _query;
        private readonly string _token;
        private readonly string dateFormat = "yyyy-MM-dd HH:mm";
        private readonly string responseDateFormat = "yyyy-MM-dd HH:mm:ss";

        public PaxDriveClient(string baseUrl, string token) : this(baseUrl, token, Currency.Try)
        {
        }

        public PaxDriveClient(string baseUrl, string token, Currency currency) : this(baseUrl, token, currency, Language.Turkish)
        {
        }

        public PaxDriveClient(string baseUrl, string token, Currency currency, Language language)
        {
            _baseUrl  = baseUrl;
            _token    = token;
            _currency = currency;
            _language = language;

            _httpClient = new HttpClient {BaseAddress = new Uri(_baseUrl)};
            _httpClient.DefaultRequestHeaders.Add("pax-token", _token);

            _query = $"?cid={_currency.Value}&lng={_language.Value}";
        }

        public CheckResponse Check()
        {
            string path = "check";

            var resultJson = _httpClient.GetAsync(path).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveCheckResponse>(resultJson);

            return new CheckResponse
            {
                PartnerId = result.user_partner_id,
                UserId    = result.user_id,
                TimeStamp = result.timestamp
            };
        }

        public LocationResponse GetLocations(int page = 1)
        {
            string path = "point/getLocList" + _query;

            var values = new List<KeyValuePair<string, string>>
            {
                new("page", page.ToString())
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveLocationResponse>(resultJson);

            return new LocationResponse
            {
                CurrentPage = result.currentPage,
                Count       = result.pageCount,
                TotalPage   = result.pageCount,
                TotalCount  = result.totalItemCount,
                Locations = result.item_.Select(x => new Location
                {
                    Id             = x.loc_id,
                    Name           = x.loc_name,
                    Type           = x.loc_type,
                    Code           = x.loc_code,
                    PaximumId      = x.loc_paximum_uid,
                    GlobalUniqueId = x.loc_gid,
                    Latitude       = x.loc_lat,
                    Longitude      = x.loc_lon,
                    PointId        = x.point_id,
                    ZoneId         = x.zone_id,
                    ZoneCode       = x.zone_code,
                    ZoneName       = x.zone_name,
                    Country        = x.zone_country,
                    CountryCode    = x.zone_country_code
                }).ToList()
            };
        }

        public LocationResponse GetLocations(LocationRequest locationRequest)
        {
            string path = "point/searchLoc" + _query;

            var values = new List<KeyValuePair<string, string>>
            {
                new("term", locationRequest.Search),
                new("vara_fr_id", locationRequest.FromLocationId.ToString()),
                new("paximum_uid", locationRequest.PaximumId),
                new("vara_fr_paximum_uid", locationRequest.FromPaximumId),
                new("gid", locationRequest.GlobalId),
                new("vara_fr_gid", locationRequest.FromGlobalId)
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<List<PaxDriveLocation>>(resultJson);

            return new LocationResponse
            {
                CurrentPage = 1,
                Count       = result.Count,
                TotalPage   = 1,
                TotalCount  = result.Count,
                Locations = result.Select(x => new Location
                {
                    Id             = x.loc_id,
                    Name           = x.loc_name,
                    Type           = x.loc_type,
                    Code           = x.loc_code,
                    PaximumId      = x.loc_paximum_uid,
                    GlobalUniqueId = x.loc_gid,
                    Latitude       = x.loc_lat,
                    Longitude      = x.loc_lon,
                    PointId        = x.point_id,
                    ZoneId         = x.zone_id,
                    ZoneCode       = x.zone_code,
                    ZoneName       = x.zone_name,
                    Country        = x.zone_country,
                    CountryCode    = x.zone_country_code
                }).ToList()
            };
        }

        public SearchVehicleResponse SearchVehicle(SearchVehicleRequest searchVehicleRequest)
        {
            string path = "vbook/search" + _query;

            var values = new List<KeyValuePair<string, string>>
            {
                new("vara_fr_id", searchVehicleRequest.FromLocationId.ToString()),
                new("vara_to_id", searchVehicleRequest.ToLocationId.ToString()),
                new("vara_fr_paximum_uid", searchVehicleRequest.FromPaximumId),
                new("vara_to_paximum_uid", searchVehicleRequest.ToPaximumId),
                new("vara_fr_gid", searchVehicleRequest.FromGlobalUniqueId),
                new("vara_to_gid", searchVehicleRequest.ToGlobalUniqueId),
                new("vara_date", searchVehicleRequest.ReservationDateTime.ToString(dateFormat)),
                new("vara_pax_adt", searchVehicleRequest.AdultCount.ToString()),
                new("vara_pax_kid", searchVehicleRequest.KidCount.ToString()),
                new("vara_pax_bby", searchVehicleRequest.BabyCount.ToString()),
                new("_type", searchVehicleRequest.TransferType.Value),
                new("usr_mu_type", searchVehicleRequest.MarkupType.Value),
                new("usr_mu_amnt", searchVehicleRequest.MarkupAmount.ToString())
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveVBookSearchResponse>(resultJson);


            return new SearchVehicleResponse
            {
                SearchId            = result.vara_id,
                FromLocationId      = int.Parse(result.fr_loc_id),
                ToLocationId        = int.Parse(result.to_loc_id),
                FromGlobalUniqueId  = result.fr_loc_gid,
                ToGlobalUniqueId    = result.to_loc_gid,
                FromPaximumId       = result.fr_loc_paximum_uid,
                ToPaximumId         = result.to_loc_paximum_uid,
                FromLocationName    = result.fr_loc,
                ToLocationName      = result.to_loc,
                ZoneName            = result.zone,
                Distance            = result.distance,
                RoadTime            = result.time,
                MeetingImage        = result.fr_loc_meet_img,
                MeetingDescription  = result.fr_loc_meet_txt,
                ReservationDateTime = DateTime.ParseExact(result.date, responseDateFormat, null),
                Vehicles = result.vehicle_.Select(v => new Vehicle
                {
                    Id                = v._id,
                    PartnerId         = v._partner_id,
                    VehicleType       = VehicleType.GetByValue<VehicleType>(v._type),
                    Name              = v._name,
                    Title             = v._title,
                    VehicleStatusType = VehicleStatusType.GetByValue<VehicleStatusType>(v._status),
                    Image             = v._info_.photo,
                    PassengerCount    = v._info_.max_.pax,
                    SuitcaseCount     = v._info_.max_.suitcase,
                    BookingTime       = v._info_.hour_.booking,
                    FreeChangeTime    = v._info_.hour_.freeChange,
                    FreeCancelTime    = v._info_.hour_.freeCancel,
                    Quantity          = v.o.vbook_.suggestedVehicleCount,
                    CurrencyId        = int.Parse(v.o.vbook_.sysPC_.cid),
                    Currency          = Currency.GetByValue<Currency>(v.o.vbook_.sysPC_.cid),
                    Price             = v.o.vbook_.sysPC_.prc,
                    SalesPrice        = v.o.vbook_.usrPC_.prc,
                    ExtraServices = v.o.vbook_.xser_.Select(e => new ExtraService
                    {
                        Id          = e.uid,
                        Code        = e.code,
                        Title       = e.title,
                        Description = e.descr,
                        CurrencyId  = int.Parse(e.sysPC_.cid),
                        Currency    = Currency.GetByValue<Currency>(e.sysPC_.cid),
                        Price       = e.sysPC_.prc,
                        SalesPrice  = e.usrPC_.prc
                    }).ToList()
                }).ToList()
            };
        }

        public SelectVehicleResponse SelectVehicle(SelectVehicleRequest selectVehicleRequest)
        {
            string path = "vbook/select" + _query;

            var values = new List<KeyValuePair<string, string>>
            {
                new("vara_id", selectVehicleRequest.SearchId.ToString()),
                new("vehicle_id", selectVehicleRequest.VehicleId.ToString()),
                new("quantity", selectVehicleRequest.Quantity.ToString())
            };

            foreach (var extraServiceRequest in selectVehicleRequest.ExtraServices) values.Add(new KeyValuePair<string, string>("xser_uid_[]", extraServiceRequest.ToString()));

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveVBookSelectResponse>(resultJson);


            return new SelectVehicleResponse
            {
                SelectId = result.req_id,
                Vehicle = new Vehicle
                {
                    Id                = result.vehicle._id,
                    PartnerId         = result.vehicle._partner_id,
                    VehicleType       = VehicleType.GetByValue<VehicleType>(result.vehicle._type),
                    Name              = result.vehicle._name,
                    Title             = result.vehicle._title,
                    VehicleStatusType = VehicleStatusType.GetByValue<VehicleStatusType>(result.vehicle._status),
                    Image             = result.vehicle._info_.photo,
                    PassengerCount    = result.vehicle._info_.max_.pax,
                    SuitcaseCount     = result.vehicle._info_.max_.suitcase,
                    BookingTime       = result.vehicle._info_.hour_.booking,
                    FreeChangeTime    = result.vehicle._info_.hour_.freeChange,
                    FreeCancelTime    = result.vehicle._info_.hour_.freeCancel,
                    Quantity          = result.vehicle.o.vbook_.suggestedVehicleCount,
                    CurrencyId        = int.Parse(result.vehicle.o.vbook_.sysPC_.cid),
                    Currency          = Currency.GetByValue<Currency>(result.vehicle.o.vbook_.sysPC_.cid),
                    Price             = result.vehicle.o.vbook_.sysPC_.prc,
                    SalesPrice        = result.vehicle.o.vbook_.usrPC_.prc,
                    ExtraServices = result.vehicle.o.vbook_.xser_.Select(e => new ExtraService
                    {
                        Id          = e.uid,
                        Code        = e.code,
                        Title       = e.title,
                        Description = e.descr,
                        CurrencyId  = int.Parse(e.sysPC_.cid),
                        Currency    = Currency.GetByValue<Currency>(e.sysPC_.cid),
                        Price       = e.sysPC_.prc,
                        SalesPrice  = e.usrPC_.prc
                    }).ToList()
                }
            };
        }

        public CreateCardResponse CreateCard(CreateCardRequest createCardRequest)
        {
            string path = "cart/vbook" + _query;

            var values = new List<KeyValuePair<string, string>>
            {
                new("req_id", createCardRequest.SelectId),
                new("remote_fr_name", createCardRequest.FromLocationName),
                new("vbook_fr_a", createCardRequest.fromMessage),
                new("vbook_fr_b", createCardRequest.FromDescription),
                new("remote_to_name", createCardRequest.ToLocationName),
                new("vbook_to_a", createCardRequest.ToMessage),
                new("vbook_to_b", createCardRequest.ToDescription),
                new("vbook_name", createCardRequest.PassengerName),
                new("vbook_mail", createCardRequest.PassengerEmail),
                new("vbook_mpno", createCardRequest.PassengerPhone),
                new("vbook_nation", createCardRequest.PassengerNationalityCode),
                new("vbook_idno", createCardRequest.PassengerIdentityNumber),
                new("vbook_note_ur", createCardRequest.Note),
                new("cart_name", createCardRequest.PassengerName),
                new("cart_mail", createCardRequest.PassengerEmail),
                new("cart_mpno", createCardRequest.PassengerPhone)
            };

            int adultCount = 0, kidCount = -1, babyCount = -1;

            foreach (var passenger in createCardRequest.Passengers)
            {
                string key = passenger.PassengerType.Value;

                if (passenger.PassengerType.Value == PassengerType.Adult.Value)
                {
                    adultCount++;
                    key = passenger.PassengerType.Value + adultCount;
                }

                if (passenger.PassengerType.Value == PassengerType.Kid.Value)
                {
                    kidCount++;
                    key = passenger.PassengerType.Value + kidCount;
                }

                if (passenger.PassengerType.Value == PassengerType.Baby.Value)
                {
                    babyCount++;
                    key = passenger.PassengerType.Value + babyCount;
                }


                values.Add(new KeyValuePair<string, string>($"paxName_[{key}]", passenger.Name));
                values.Add(new KeyValuePair<string, string>($"paxNation_[{key}]", passenger.NationalityCode));
                values.Add(new KeyValuePair<string, string>($"paxIdno_[{key}]", passenger.IdentityNumber));
            }

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveCreateCardResponse>(resultJson);

            if (!result.CI.enabled) throw new Exception("Bir hata oluştu", new Exception(resultJson));

            return new CreateCardResponse
            {
                Token      = result.token,
                Total      = result.CI.pc_.prc,
                CurrencyId = result.CI.pc_.cid,
                Currency   = Currency.GetByValue<Currency>(result.CI.pc_.cid)
            };
        }

        public GetListResponse GetList(GetListRequest getListRequest)
        {
            string path = "vbook/list";

            var values = new List<KeyValuePair<string, string>>
            {
                new("page", getListRequest.Page.ToString()),
                new("order", getListRequest.OrderType.Value)
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveGetListResponse>(resultJson);

            return new GetListResponse
            {
                CurrentPage = 0,
                Count       = 0,
                TotalCount  = 0,
                TotalPage   = 0,
                Reservations = result.vbook_.Select(x => new Reservation
                {
                    Id                       = x.vbook_id,
                    Code                     = x.vbook_code,
                    TransferType             = TransferType.GetByValue<TransferType>(x.vbook_type),
                    FromLocationName         = x.vbook_fr,
                    FromDescription          = x.vbook_fr_a,
                    FromMessage              = x.vbook_fr_b,
                    ToLocationName           = x.vbook_to,
                    ToDescription            = x.vbook_to_a,
                    ToMessage                = x.vbook_to_b,
                    ReservationDate          = DateTime.ParseExact(x.vbook_date, responseDateFormat, null),
                    PassengerName            = x.vbook_name,
                    PassengerIdentityNumber  = x.vbook_idno,
                    PassengerEmail           = x.vbook_mail,
                    PassengerPhone           = x.vbook_mpno,
                    PassengerNationalityCode = x.vbook_nation,
                    VehicleType              = VehicleType.GetByValue<VehicleType>(x.vbook_vehicle_type),
                    Cards = result.cart_.Where(c => c.cart_object_id == x.vbook_id).Select(c => new Card
                    {
                        Id = c.cart_id
                    }).ToList()
                }).ToList()
            };
        }

        public EditCardResponse EditCard(EditCardRequest editCardRequest)
        {
            string path = "vbook/save";

            var values = new List<KeyValuePair<string, string>>
            {
                new("vbook_code", editCardRequest.OrderCode),
                new("vbook_fr_a", editCardRequest.FromDescription),
                new("vbook_fr_b", editCardRequest.fromMessage),
                new("vbook_to_a", editCardRequest.ToDescription),
                new("vbook_to_b", editCardRequest.ToMessage),
                new("vbook_name", editCardRequest.PassengerName),
                new("vbook_mail", editCardRequest.PassengerEmail),
                new("vbook_mpno", editCardRequest.PassengerPhone),
                new("vbook_idno", editCardRequest.PassengerIdentityNumber),
                new("vbook_nation", editCardRequest.PassengerNationalityCode),
                new("vbook_note_ur", editCardRequest.Note),
                new("vbook_pax_adt", (editCardRequest.Passengers.Count(x => x.PassengerType == PassengerType.Adult) + 1).ToString()),
                new("vbook_pax_kid", editCardRequest.Passengers.Count(x => x.PassengerType == PassengerType.Kid).ToString()),
                new("vbook_pax_bby", editCardRequest.Passengers.Count(x => x.PassengerType == PassengerType.Baby).ToString()),
                new("cart_name", editCardRequest.PassengerName),
                new("cart_mail", editCardRequest.PassengerEmail),
                new("cart_mpno", editCardRequest.PassengerPhone)
            };

            int adultCount = 0, kidCount = -1, babyCount = -1;

            foreach (var passenger in editCardRequest.Passengers)
            {
                string key = passenger.PassengerType.Value;

                if (passenger.PassengerType.Value == PassengerType.Adult.Value)
                {
                    adultCount++;
                    key = passenger.PassengerType.Value + adultCount;
                }

                if (passenger.PassengerType.Value == PassengerType.Kid.Value)
                {
                    kidCount++;
                    key = passenger.PassengerType.Value + kidCount;
                }

                if (passenger.PassengerType.Value == PassengerType.Baby.Value)
                {
                    babyCount++;
                    key = passenger.PassengerType.Value + babyCount;
                }

                values.Add(new KeyValuePair<string, string>($"paxName_[{key}]", passenger.Name));
                values.Add(new KeyValuePair<string, string>($"paxNation_[{key}]", passenger.NationalityCode));
                values.Add(new KeyValuePair<string, string>($"paxIdno_[{key}]", passenger.IdentityNumber));
            }

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveEditResponse>(resultJson);


            return new EditCardResponse
            {
                Status = result.success
            };
        }

        public EditReservationDateResponse EditReservationDate(EditReservationDateRequest editReservationDateRequest)
        {
            string path = "vbook/editDate";

            var values = new List<KeyValuePair<string, string>>
            {
                new("vbook_code", editReservationDateRequest.OrderCode),
                new("vbook_date", editReservationDateRequest.ReservationDate.ToString(dateFormat))
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveEditDateResponse>(resultJson);

            return new EditReservationDateResponse
            {
                Status = result.success
            };
        }

        public Reservation GetByCode(string orderCod)
        {
            string path = "vbook/view";

            var values = new List<KeyValuePair<string, string>>
            {
                new("vbook_code", orderCod)
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveReservationResponse>(resultJson);

            return result.vbook_.Select(x => new Reservation
            {
                Id                       = x.vbook_id,
                Code                     = x.vbook_code,
                TransferType             = TransferType.GetByValue<TransferType>(x.vbook_type),
                FromLocationName         = x.vbook_fr,
                FromDescription          = x.vbook_fr_a,
                FromMessage              = x.vbook_fr_b,
                ToLocationName           = x.vbook_to,
                ToDescription            = x.vbook_to_a,
                ToMessage                = x.vbook_to_b,
                ReservationDate          = DateTime.ParseExact(x.vbook_date, responseDateFormat, null),
                PassengerName            = x.vbook_name,
                PassengerIdentityNumber  = x.vbook_idno,
                PassengerEmail           = x.vbook_mail,
                PassengerPhone           = x.vbook_mpno,
                PassengerNationalityCode = x.vbook_nation,
                VehicleType              = VehicleType.GetByValue<VehicleType>(x.vbook_vehicle_type),
                Cards                    = result.cart_.Select(c => new Card {Id = c.cart_id}).ToList()
            }).FirstOrDefault();
        }

        public CancelResponse CancelCard(CancelRequest cancelRequest)
        {
            string path = "vbook/cancel";

            var values = new List<KeyValuePair<string, string>>
            {
                new("cart_id", cancelRequest.CardId.ToString())
            };

            var resultJson = _httpClient.PostAsync(path, new FormUrlEncodedContent(values)).Result.Content.ReadAsStringAsync().Result;
            var result     = JsonConvert.DeserializeObject<PaxDriveCancelResponse>(resultJson);

            return new CancelResponse
            {
                Status = result.success
            };
        }


        ////
        public CancelResponse CancelReservation(string orderCode)
        {
            try
            {
                var reservation = GetByCode(orderCode);

                foreach (var card in reservation.Cards)
                {
                    var result = CancelCard(new CancelRequest {CardId = card.Id});
                    if (result.Status == false) throw new PaxDriveException("error", "iptal işlemi sırasında bir hata oluştur.", "Transfer");
                }

                return new CancelResponse
                {
                    Status = true
                };
            }
            catch (Exception e)
            {
                return new CancelResponse
                {
                    Status = false
                };
            }
        }

        public EditReservationResponse EditReservation(EditReservationRequest editReservationRequest)
        {
            try
            {
                var resultCard = EditCard(new EditCardRequest
                {
                    OrderCode                = editReservationRequest.OrderCode,
                    FromDescription          = editReservationRequest.FromDescription,
                    fromMessage              = editReservationRequest.fromMessage,
                    ToDescription            = editReservationRequest.ToDescription,
                    ToMessage                = editReservationRequest.ToMessage,
                    PassengerName            = editReservationRequest.PassengerName,
                    PassengerEmail           = editReservationRequest.PassengerEmail,
                    PassengerPhone           = editReservationRequest.PassengerPhone,
                    PassengerNationalityCode = editReservationRequest.PassengerNationalityCode,
                    PassengerIdentityNumber  = editReservationRequest.PassengerIdentityNumber,
                    Note                     = editReservationRequest.Note,
                    Passengers               = editReservationRequest.Passengers
                });
                var resutDate = EditReservationDate(new EditReservationDateRequest
                {
                    OrderCode       = editReservationRequest.OrderCode,
                    ReservationDate = editReservationRequest.ReservationDate
                });

                return new EditReservationResponse
                {
                    Status = resultCard.Status && resutDate.Status
                };
            }
            catch (Exception e)
            {
                return new EditReservationResponse
                {
                    Status = false
                };
            }
        }
    }
}