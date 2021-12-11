namespace PaxDrive.Enum
{
    public class VehicleType : Enumeration
    {
        private VehicleType(string name, string value) : base(name, value)
        {
        }

        public static VehicleType Shuttle = new VehicleType("Paylaşımlı", "SHRD");
        public static VehicleType Automobile = new VehicleType("Standart Binek", "CARC");
        public static VehicleType BussinessAutomobile = new VehicleType("Business Binek", "CARD");
        public static VehicleType ExecutiveAutomobile = new VehicleType("Executive Binek", "CARE");
        public static VehicleType FirstClassAutomobile = new VehicleType("First Class Binek", "CARF");
        public static VehicleType Mini = new VehicleType("Mini", "MINC");
        public static VehicleType VipMini = new VehicleType("Vip Mini", "MICV");
        public static VehicleType Minibus = new VehicleType("Minibüs", "MIND");
        public static VehicleType Midibus = new VehicleType("Midibüs", "MIDC");
        public static VehicleType Bus = new VehicleType("Otobüs", "BUSC");
    }
}