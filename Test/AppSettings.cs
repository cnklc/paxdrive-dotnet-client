using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Test;

public class AppSettings
{
    public HangarSettings Hangar { get; set; }
    public PaxDriveSettings PaxDrive { get; set; }


    private static string json
    {
        get { return File.ReadAllText(Path.Combine("/Users/can/Projects/Personel/PaxDriveLib/paxdrive-dotnet-client/Test/", "appsettings.json")); }
    }

    public static HangarSettings HangarSettings
    {
        get { return JsonConvert.DeserializeObject<AppSettings>(json).Hangar; }
    }

    public static PaxDriveSettings PaxDriveSettings
    {
        get { return JsonConvert.DeserializeObject<AppSettings>(json).PaxDrive; }
    }
}

public class HangarSettings
{
    public string TokenName { get; set; }
    public string Token { get; set; }
    public string Url { get; set; }
}

public class PaxDriveSettings
{
    public string TokenName { get; set; }
    public string Token { get; set; }
    public string Url { get; set; }
}