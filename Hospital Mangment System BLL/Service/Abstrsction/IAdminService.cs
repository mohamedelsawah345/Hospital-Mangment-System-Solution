using Hospital_Mangment_System_BLL.View_model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminUserViewModel>> GetAllUsersAsync();
        Task<AdminUserViewModel> GetUserByIdAsync(string userId);
        Task<bool> UpdateUserAsync(AdminUserViewModel model);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> LockUnlockUserAsync(string userId, bool lockUser);
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
    }
}
