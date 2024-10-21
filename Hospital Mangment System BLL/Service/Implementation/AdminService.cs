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
            var users = _userManager.Users.ToList();
            var userViewModels = new List<AdminUserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new AdminUserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = roles.FirstOrDefault(),
                    IsLockedOut = await _userManager.IsLockedOutAsync(user)
                });
            }

            return userViewModels;
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

            user.UserName = model.UserName;
            user.Email = model.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return false;

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
            }
            await _userManager.AddToRoleAsync(user, model.Role);

            return true;
        }

        public async Task<bool> SoftDeleteUserWithRelatedEntitiesAsync(string userId)
        {
            // Get related doctor records
            var doctors = await dbContext.Doctors
                .Where(d => d.ApplicationUserId == userId)
                .ToListAsync();

            // Mark related doctors as deleted
            foreach (var doctor in doctors)
            {
                doctor.IsDeleted = true;
            }

            // Get related nurse records
            var nurses = await dbContext.nurses
                .Where(n => n.ApplicationUserId == userId)
                .ToListAsync();

            // Mark related nurses as deleted
            foreach (var nurse in nurses)
            {
                nurse.IsDeleted = true;
            }

            // Get related patient records
            var patients = await dbContext.patients
                .Where(p => p.ApplicationUserId == userId)
                .ToListAsync();

            // Mark related patients as deleted
            foreach (var patient in patients)
            {
                patient.IsDeleted = true;
            }

            // Save changes to mark records as deleted
            await dbContext.SaveChangesAsync();

            // Now mark the user as deleted
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsDeleted = true;
                var result = await _userManager.UpdateAsync(user);
                return result.Succeeded; // Return whether the user deletion was successful
            }

            return false; // User not found
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
