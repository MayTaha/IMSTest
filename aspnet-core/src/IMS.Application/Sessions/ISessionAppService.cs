using System.Threading.Tasks;
using Abp.Application.Services;
using IMS.Sessions.Dto;

namespace IMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
