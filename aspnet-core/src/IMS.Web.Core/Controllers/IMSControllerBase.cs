using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IMS.Controllers
{
    public abstract class IMSControllerBase: AbpController
    {
        protected IMSControllerBase()
        {
            LocalizationSourceName = IMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
