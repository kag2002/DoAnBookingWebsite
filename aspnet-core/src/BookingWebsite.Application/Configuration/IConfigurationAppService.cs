using System.Threading.Tasks;
using BookingWebsite.Configuration.Dto;

namespace BookingWebsite.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
