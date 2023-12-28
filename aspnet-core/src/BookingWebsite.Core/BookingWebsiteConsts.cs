using BookingWebsite.Debugging;

namespace BookingWebsite
{
    public class BookingWebsiteConsts
    {
        public const string LocalizationSourceName = "BookingWebsite";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e36b8a359277472f91b6ed8a31baf965";
    }
}
