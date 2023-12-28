using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BookingWebsite.Controllers
{
    public abstract class BookingWebsiteControllerBase: AbpController
    {
        protected BookingWebsiteControllerBase()
        {
            LocalizationSourceName = BookingWebsiteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
