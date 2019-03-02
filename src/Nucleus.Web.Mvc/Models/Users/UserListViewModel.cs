using System.Collections.Generic;
using Nucleus.Roles.Dto;
using Nucleus.Users.Dto;

namespace Nucleus.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
