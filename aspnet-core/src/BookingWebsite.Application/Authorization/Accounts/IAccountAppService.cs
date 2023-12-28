using System.Threading.Tasks;
using Abp.Application.Services;
using BookingWebsite.Authorization.Accounts.Dto;

namespace BookingWebsite.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
