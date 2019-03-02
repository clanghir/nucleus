using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Nucleus.MultiTenancy.Dto;

namespace Nucleus.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

