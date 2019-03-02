using System.Threading.Tasks;
using Abp.Application.Services;
using Nucleus.Authorization.Accounts.Dto;

namespace Nucleus.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
