using System.Collections.Generic;

namespace Hangar.Model.Hangar
{
    public class HangarCheckResponse
    {
        public string user_id { get; set; }
        public string user_partner_id { get; set; }
        public int timestamp { get; set; }
    }

    public class HangarLocationResponse
    {
        public int currentPage { get; set; }
        public int currentItemCount { get; set; }
        public int pageCount { get; set; }
        public int totalItemCount { get; set; }
        public List<HangarLocation> item_ { get; set; }
    }

    public class HangarLocation
    {
        public int loc_id { get; set; }
        public string loc_name { get; set; }
        public string loc_type { get; set; }
        public string loc_code { get; set; }
        public string loc_paximum_uid { get; set; }
        public string loc_gid { get; set; }
        public string loc_lat { get; set; }
        public string loc_lon { get; set; }
        public string point_id { get; set; }
        public int zone_id { get; set; }
        public string zone_name { get; set; }
        public string zone_code { get; set; }
        public string zone_country { get; set; }
        public string zone_country_code { get; set; }
    }


    public class HangarVBookSearchResponse
    {
        public int vara_id { get; set; }
        public int fr_loc_id { get; set; }
        public string fr_loc { get; set; }
        public int to_loc_id { get; set; }
        public string to_loc { get; set; }
        public string date { get; set; }
        public string distance { get; set; }
        public string time { get; set; }
        public List<Vehicle> vehicle_ { get; set; }
    }

    public class Vehicle
    {
        public int _id { get; set; }
        public int _partner_id { get; set; }
        public string _type { get; set; }
        public string _name { get; set; }
        public string _title { get; set; }
        public Info _info_ { get; set; }
        public List<object> _extra_ { get; set; }
        public string _status { get; set; }
        public O o { get; set; }
    }

    public class O
    {
        public Vbook vbook_ { get; set; }
        public Selected selected_ { get; set; }
    }

    public class Selected
    {
        public string quantity { get; set; }
        public UsrPC usrPC_ { get; set; }
        public Brm brm_ { get; set; }
        public Ttl ttl_ { get; set; }
        public object xser_ { get; set; }
    }

    public class Brm
    {
        public UsrPC usrPC_ { get; set; }
        public object xser_ { get; set; }
    }

    public class Ttl
    {
        public UsrPC usrPC_ { get; set; }
    }

    public class Vbook
    {
        public int brmFactor { get; set; }
        public string selectionText { get; set; }
        public int vehicle_count { get; set; }
        public Mu mu_ { get; set; }
        public UsrPC usrPC_ { get; set; }
        public decimal sortPrc { get; set; }
        public object xser_ { get; set; }
    }

    public class Max
    {
        public string pax { get; set; }
        public string suitcase { get; set; }
    }

    public class Hour
    {
        public string book { get; set; }
        public string cncl { get; set; }
        public string edit { get; set; }
    }

    public class Info
    {
        public Max max_ { get; set; }
        public Hour hour_ { get; set; }
        public string photo { get; set; }
    }

    public class BookPC
    {
        public string prc { get; set; }
        public string cid { get; set; }
    }

    public class XserPC
    {
        public string prc { get; set; }
        public string cid { get; set; }
    }

    public class Mu
    {
        public object bookPT { get; set; }
        public BookPC bookPC_ { get; set; }
        public object xserPT { get; set; }
        public XserPC xserPC_ { get; set; }
    }

    public class UsrPC
    {
        public decimal prc { get; set; }
        public int cid { get; set; }
    }

    public class HangarVBookSelectResponse
    {
        public string req_id { get; set; }
        public Vehicle vehicle { get; set; }
    }
    public class HangarCheckoutResponse
    {
        public List<Cart> cart_ { get; set; }
        public List<Vbook2> vbook_ { get; set; }
        public string cart_orid { get; set; }
    }
    public class HangarCreateCardResponse
    {
        public string token { get; set; }
        public CI CI { get; set; }
    }

    public class Pc
    {
        public decimal prc { get; set; }
        public int cid { get; set; }
    }

    public class CI
    {
        public bool enabled { get; set; }
        public Pc pc_ { get; set; }
    }

    public class HangarReservationResponse
    {
        public List<Vbook2> vbook_ { get; set; }
        public List<Cart> cart_ { get; set; }
    }

    public class Vbook2
    {
        public int vbook_id { get; set; }
        public string vbook_code { get; set; }
        public string vbook_type { get; set; }
        public string vbook_fr { get; set; }
        public string vbook_fr_a { get; set; }
        public object vbook_fr_b { get; set; }
        public string vbook_fr_type { get; set; }
        public string vbook_fr_type_r { get; set; }
        public string vbook_to { get; set; }
        public string vbook_to_a { get; set; }
        public string vbook_to_b { get; set; }
        public string vbook_to_type { get; set; }
        public string vbook_to_type_r { get; set; }
        public string vbook_date { get; set; }
        public string vbook_name { get; set; }
        public string vbook_mpno { get; set; }
        public string vbook_mail { get; set; }
        public string vbook_idno { get; set; }
        public object vbook_driver_x_ { get; set; }
        public int vbook_pax_adt { get; set; }
        public int vbook_pax_kid { get; set; }
        public int vbook_pax_bby { get; set; }
        public string vbook_note_ur { get; set; }
        public string vbook_vehicle_title { get; set; }
        public int vbook_vehicle_count { get; set; }
        public string vbook_info_max_pax { get; set; }
        public string vbook_info_max_suitcase { get; set; }
        public object vbook_info_hour_freeCancel { get; set; }
        public object vbook_info_hour_freeChange { get; set; }
        public object vbook_info_pax_name_ { get; set; }
        public object vbook_info_pax_idno_ { get; set; }
        public List<object> vbook_info_t_ { get; set; }
        public string vbook_hash { get; set; }
    }

    public class Cart
    {
        public int cart_id { get; set; }
        public string cart_object { get; set; }
        public int cart_object_id { get; set; }
        public string cart_usr_prc { get; set; }
        public int cart_usr_cid { get; set; }
        public string cart_title { get; set; }
        public string cart_infoa { get; set; }
        public string cart_infob { get; set; }
        public string cart_infoc { get; set; }
        public string cart_infod { get; set; }
        public string cart_pay_case { get; set; }
        public string cart_paya { get; set; }
        public string cart_payb { get; set; }
        public string cart_payc { get; set; }
        public string cart_payd { get; set; }
        public string cart_case { get; set; }
        public string cart_done_date { get; set; }
        public string cart_paid_date { get; set; }
        public string cart_cncl_date { get; set; }
        public object cart_rfnd_date { get; set; }
        public string cart_status { get; set; }
    }

    public class HangarGetListResponse
    {
        public List<Cart> cart_ { get; set; }
        public List<Vbook2> vbook_ { get; set; }
    }

    public class HangarCancelResponse
    {
        public bool success { get; set; }
    }


    public class HangarEditDateResponse
    {
        public bool success { get; set; }
    }

    public class HangarEditResponse
    {
        public bool success { get; set; }
    }

}