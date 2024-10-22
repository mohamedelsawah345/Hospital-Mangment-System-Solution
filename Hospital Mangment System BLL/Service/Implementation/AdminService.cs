using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.Admin;
using Hospital_Mangment_System_DAL.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDBcontext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(ApplicationDBcontext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<AdminUserViewModel>> GetAllUsersAsync()
        {
            var users = await dbContext.Users
        .Select(user => new AdminUserViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Role = user.Role_Type,
            IsLockedOut = user.LockoutEnd != null && user.LockoutEnd > DateTime.UtcNow,
            IsDeleted = user.IsDeleted // Make sure IsDeleted is included in the view model
        }).ToListAsync();

            return users;
        }

        public async Task<AdminUserViewModel> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new AdminUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = roles.FirstOrDefault(),
                IsLockedOut = await _userManager.IsLockedOutAsync(user)
            };
        }

        public async Task<bool> UpdateUserAsync(AdminUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return false;

            user.Email = model.Email;
            user.UserName = model.UserName;

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            var addRoleResult = await _userManager.AddToRoleAsync(user, model.Role);

            if (!addRoleResult.Succeeded)
            {
                // Log errors from adding role
                var errors = addRoleResult.Errors.Select(e => e.Description);
                // Optionally log these errors
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                var user = await dbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null) return false;

                // Set IsDeleted to true in ApplicationUser
                user.IsDeleted = true;

                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LockUnlockUserAsync(string userId, bool lockUser)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            if (lockUser)
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, null);
            }

            return true;
        }
        public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
        {
            // Validate the role exists
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return false; // Return false if role does not exist
            }

            // Find the user by ID
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // Return false if user does not exist
            }

            // Check if the user is already in the role
            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                return true; // User is already in the role
            }

            // Add the user to the role
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded; // Return true if the operation succeeded
        }

    }

}
