using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BookingWebsite.Configuration.Dto;

namespace BookingWebsite.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookingWebsiteAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
