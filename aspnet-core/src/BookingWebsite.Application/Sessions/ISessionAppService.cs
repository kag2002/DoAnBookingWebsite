using System.Threading.Tasks;
using Abp.Application.Services;
using BookingWebsite.Sessions.Dto;

namespace BookingWebsite.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
