using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Nucleus.Configuration.Dto;

namespace Nucleus.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NucleusAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
