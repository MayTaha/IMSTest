using System.Threading.Tasks;
using Abp.Application.Services;
using IMS.Authorization.Accounts.Dto;

namespace IMS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
