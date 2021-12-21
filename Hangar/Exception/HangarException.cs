namespace Hangar.Exception
{
    public class HangarException : System.Exception
    {
        public HangarException(string errorCode, string errorDescription, string errorGroup)
            : base(errorDescription)
        {
            ErrorCode        = errorCode;
            ErrorDescription = errorDescription;
            ErrorGroup       = errorGroup;
        }

        public string ErrorCode { get; }
        public string ErrorDescription { get; }
        public string ErrorGroup { get; }
    }
}