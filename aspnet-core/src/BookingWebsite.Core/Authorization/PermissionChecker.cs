using Abp.Authorization;
using BookingWebsite.Authorization.Roles;
using BookingWebsite.Authorization.Users;

namespace BookingWebsite.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
