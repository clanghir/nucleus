using System.Collections.Generic;
using Nucleus.Roles.Dto;

namespace Nucleus.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}