using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Nucleus.Controllers
{
    public abstract class NucleusControllerBase: AbpController
    {
        protected NucleusControllerBase()
        {
            LocalizationSourceName = NucleusConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
