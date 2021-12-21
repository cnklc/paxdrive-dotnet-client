namespace Hangar.Enum
{
    public class VehicleType : Enumeration
    {
        public static VehicleType Shuttle = new("Paylaşımlı", "SHRD");
        public static VehicleType Automobile = new("Standart Binek", "CARC");
        public static VehicleType BussinessAutomobile = new("Business Binek", "CARD");
        public static VehicleType ExecutiveAutomobile = new("Executive Binek", "CARE");
        public static VehicleType FirstClassAutomobile = new("First Class Binek", "CARF");
        public static VehicleType Mini = new("Mini", "MINC");
        public static VehicleType VipMini = new("Vip Mini", "MICV");
        public static VehicleType Minibus = new("Minibüs", "MIND");
        public static VehicleType Midibus = new("Midibüs", "MIDC");
        public static VehicleType Bus = new("Otobüs", "BUSC");

        private VehicleType(string name, string value) : base(name, value)
        {
        }
    }
}