using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookingWebsite.Configuration;

namespace BookingWebsite.Web.Host.Startup
{
    [DependsOn(
       typeof(BookingWebsiteWebCoreModule))]
    public class BookingWebsiteWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BookingWebsiteWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookingWebsiteWebHostModule).GetAssembly());
        }
    }
}
