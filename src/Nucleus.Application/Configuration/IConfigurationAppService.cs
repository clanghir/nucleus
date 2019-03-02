using System.Threading.Tasks;
using Nucleus.Configuration.Dto;

namespace Nucleus.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
