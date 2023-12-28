using Abp.Application.Services;
using BookingWebsite.MultiTenancy.Dto;

namespace BookingWebsite.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

