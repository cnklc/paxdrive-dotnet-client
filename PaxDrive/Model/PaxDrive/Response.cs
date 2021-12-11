using System.Collections.Generic;

namespace PaxDrive.Model.PaxDrive
{
    public class PaxDriveCheckResponse
    {
        public string user_id { get; set; }
        public string user_partner_id { get; set; }
        public int timestamp { get; set; }
    }

    public class PaxDriveLocationResponse
    {
        public int currentPage { get; set; }
        public int currentItemCount { get; set; }
        public int pageCount { get; set; }
        public int totalItemCount { get; set; }
        public List<PaxDriveLocation> item_ { get; set; }
    }

    public class PaxDriveLocation
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

    public class PaxDriveVBookSearchResponse
    {
        public int vara_id { get; set; }
        public string fr_loc_id { get; set; }
        public string fr_loc { get; set; }
        public string fr_loc_paximum_uid { get; set; }
        public string fr_loc_gid { get; set; }
        public string to_loc_id { get; set; }
        public string to_loc { get; set; }
        public string to_loc_paximum_uid { get; set; }
        public string to_loc_gid { get; set; }
        public string zone { get; set; }
        public string date { get; set; }
        public string distance { get; set; }
        public string time { get; set; }
        public string fr_loc_meet_img { get; set; }
        public string fr_loc_meet_txt { get; set; }
        public List<Vehicle_> vehicle_ { get; set; }
    }

    public class PaxDriveVBookSelectResponse
    {
        public string req_id { get; set; }
        public Vehicle vehicle { get; set; }
    }

    public class PaxDriveCreateCardResponse
    {
        public string token { get; set; }
        public CI CI { get; set; }
    }

    public class PaxDriveCancelResponse
    {
        public bool success { get; set; }
    }

    public class PaxDriveEditDateResponse
    {
        public bool success { get; set; }
    }

    public class PaxDriveEditResponse
    {
        public bool success { get; set; }
    }
    
    public class PaxDriveGetListResponse
    {
        public List<Cart> cart_ { get; set; }
        public List<Vbook> vbook_ { get; set; }
    }

    public class VbookFeed
    {
        public List<string> mail_ { get; set; }
        public string prf { get; set; }
        public string lng { get; set; }
    }

    public class Vbook
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
        public object vbook_to_b { get; set; }
        public string vbook_to_type { get; set; }
        public string vbook_to_type_r { get; set; }
        public string vbook_date { get; set; }
        public string vbook_name { get; set; }
        public string vbook_idno { get; set; }
        public string vbook_nation { get; set; }
        public string vbook_nationR { get; set; }
        public string vbook_mpno { get; set; }
        public string vbook_mail { get; set; }
        public object vbook_driver_x_ { get; set; }
        public int vbook_pax_adt { get; set; }
        public object vbook_pax_kid { get; set; }
        public object vbook_pax_bby { get; set; }
        public object vbook_note_ur { get; set; }
        public string vbook_vehicle_type { get; set; }
        public string vbook_vehicle_type_r { get; set; }
        public string vbook_info_max_pax { get; set; }
        public string vbook_info_max_suitcase { get; set; }
        public string vbook_info_hour_freeCancel { get; set; }
        public string vbook_info_hour_freeChange { get; set; }
        public object vbook_info_pax_name_ { get; set; }
        public object vbook_info_pax_idno_ { get; set; }
        public object vbook_info_pax_nation_ { get; set; }
        public string vbook_info_fr_loc_meet_img { get; set; }
        public string vbook_info_fr_loc_meet_txt { get; set; }
        public object vbook_info_t_ { get; set; }
        public VbookFeed vbook_feed_ { get; set; }
        public string vbook_hash { get; set; }
    }

    public class Cart
    {
        public int cart_id { get; set; }
        public string cart_code { get; set; }
        public string cart_object { get; set; }
        public int cart_object_id { get; set; }
        public string cart_mpno { get; set; }
        public string cart_mail { get; set; }
        public string cart_name { get; set; }
        public string cart_sys_prc { get; set; }
        public int cart_sys_cid { get; set; }
        public string cart_usr_prc { get; set; }
        public int cart_usr_cid { get; set; }
        public string cart_end_prc { get; set; }
        public int cart_end_cid { get; set; }
        public string cart_title { get; set; }
        public string cart_infoa { get; set; }
        public string cart_infob { get; set; }
        public string cart_infoc { get; set; }
        public string cart_infod { get; set; }
        public string cart_infoe { get; set; }
        public string cart_pay_case { get; set; }
        public string cart_paya { get; set; }
        public string cart_payb { get; set; }
        public object cart_payc { get; set; }
        public object cart_payd { get; set; }
        public object cart_paye { get; set; }
        public string cart_case { get; set; }
        public string cart_done_date { get; set; }
        public string cart_paid_date { get; set; }
        public object cart_cncl_date { get; set; }
        public object cart_rfnd_date { get; set; }
        public string cart_status { get; set; }
    }

    public class PaxDriveReservationResponse
    {
        public List<Vbook> vbook_ { get; set; }
        public List<Cart> cart_ { get; set; }
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

    public class Vehicle
    {
        public int _id { get; set; }
        public int _partner_id { get; set; }
        public string _type { get; set; }
        public string _name { get; set; }
        public string _title { get; set; }
        public _Info_ _info_ { get; set; }
        public List<object> _extra_ { get; set; }
        public string _status { get; set; }
        public O o { get; set; }
    }


    public class Selected
    {
        public string quantity { get; set; }
        public Syspc_ sysPC_ { get; set; }

        public Usrpc_ usrPC_ { get; set; }
        // public List<Xser> xser_ { get; set; }
        // public Brm brm_ { get; set; }
        // public Ttl ttl_ { get; set; }
    }

    public class Vehicle_
    {
        public int _id { get; set; }
        public int _partner_id { get; set; }
        public string _type { get; set; }
        public string _name { get; set; }
        public string _title { get; set; }
        public _Info_ _info_ { get; set; }
        public object[] _extra_ { get; set; }
        public string _status { get; set; }
        public O o { get; set; }
    }

    public class _Info_
    {
        public Max_ max_ { get; set; }
        public Hour_ hour_ { get; set; }
        public string photo { get; set; }
    }

    public class Max_
    {
        public string pax { get; set; }
        public string suitcase { get; set; }
    }

    public class Hour_
    {
        public string booking { get; set; }
        public string freeCancel { get; set; }
        public string freeChange { get; set; }
    }

    public class O
    {
        public Vbook_ vbook_ { get; set; }
        public Selected selected_ { get; set; }
    }

    public class Vbook_
    {
        public int brmFactor { get; set; }
        public Usrmu_ usrMU_ { get; set; }
        public Syspc_ sysPC_ { get; set; }
        public Usrpc_ usrPC_ { get; set; }
        public int suggestedVehicleCount { get; set; }
        public float sortPrc { get; set; }
        public List<Xser_> xser_ { get; set; }
    }

    public class Usrmu_
    {
        public string bookPT { get; set; }
        public object bookPC_ { get; set; }
    }

    public class Syspc_
    {
        public decimal prc { get; set; }
        public string cid { get; set; }
    }

    public class Usrpc_
    {
        public decimal prc { get; set; }
        public string cid { get; set; }
    }

    public class Xser_
    {
        public int uid { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string descr { get; set; }
        public Syspc_1 sysPC_ { get; set; }
        public Usrpc_1 usrPC_ { get; set; }
    }

    public class Syspc_1
    {
        public decimal prc { get; set; }
        public string cid { get; set; }
    }

    public class Usrpc_1
    {
        public decimal prc { get; set; }
        public string cid { get; set; }
    }
}