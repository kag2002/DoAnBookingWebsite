using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookingWebsite.Authorization;

namespace BookingWebsite
{
    [DependsOn(
        typeof(BookingWebsiteCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BookingWebsiteApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BookingWebsiteAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BookingWebsiteApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
