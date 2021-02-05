using System.Threading.Tasks;
using IMS.Configuration.Dto;

namespace IMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
