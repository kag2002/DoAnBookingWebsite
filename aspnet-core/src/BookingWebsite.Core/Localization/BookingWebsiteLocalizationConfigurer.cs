using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BookingWebsite.Localization
{
    public static class BookingWebsiteLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BookingWebsiteConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BookingWebsiteLocalizationConfigurer).GetAssembly(),
                        "BookingWebsite.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
