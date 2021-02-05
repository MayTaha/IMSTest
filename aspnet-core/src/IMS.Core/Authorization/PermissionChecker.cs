using Abp.Authorization;
using IMS.Authorization.Roles;
using IMS.Authorization.Users;

namespace IMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
