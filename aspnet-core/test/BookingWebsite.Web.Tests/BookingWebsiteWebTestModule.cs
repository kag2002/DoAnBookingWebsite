using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookingWebsite.EntityFrameworkCore;
using BookingWebsite.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BookingWebsite.Web.Tests
{
    [DependsOn(
        typeof(BookingWebsiteWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BookingWebsiteWebTestModule : AbpModule
    {
        public BookingWebsiteWebTestModule(BookingWebsiteEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookingWebsiteWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BookingWebsiteWebMvcModule).Assembly);
        }
    }
}