using Azure.Core;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.AuthenticationVM;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDoctorRepo _doctorRepo; 
        private readonly INurseRepo _nurseRepo;
        private readonly IPatientsRepo _patientRepo;
        private readonly IEmailSender _emailSender;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDoctorRepo doctorRepo,
            INurseRepo nurseRepo,
            IPatientsRepo patientRepo,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _doctorRepo = doctorRepo;
            _nurseRepo = nurseRepo;
            _patientRepo = patientRepo;
            _emailSender = emailSender;
        }

        // Register a Doctor
        public async Task<bool> RegisterDoctorAsync(RegisterVM model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                PhoneNumber = model.Phone,
                Role_Type = "Doctor"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var doctor = new Doctor
                {
                    ApplicationUserId = user?.Id,
                    Phone = model.Phone,
                    Speciality = model?.Speciality,
                    Dnum = (int)model?.DepartmentId
                };

                await _doctorRepo.AddAsync(doctor);
                await _userManager.AddToRoleAsync(user, "Doctor");

                return true;
            }

            return false;
        }

        // Register a Nurse
        public async Task<bool> RegisterNurseAsync(RegisterVM model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                PhoneNumber = model.Phone,
                Role_Type = "Nurse"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var nurse = new Nurse
                {
                    ApplicationUserId = user.Id,
                    Dnum = (int)model.DepartmentId,
                    Phone = model.Phone
                };

                await _nurseRepo.AddAsync(nurse);
                await _userManager.AddToRoleAsync(user, "Nurse");

                return true;
            }

            return false;
        }

        // Register a Patient
        public async Task<bool> RegisterPatientAsync(RegisterVM model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                PhoneNumber = model.Phone,
                Role_Type = "Patient"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var patient = new Patient
                {
                    ApplicationUserId = user.Id,
                    Phone = model.Phone,
                    birthday = (DateOnly)model.Birthday,
                    Gender = model.Gender
                };

                await _patientRepo.AddAsync(patient);
                await _userManager.AddToRoleAsync(user, "Patient");

                return true;
            }

            return false;
        }
        //// Send Email
        //public async Task<IdentityResult> RegisterUserAsync(RegisterVM model)
        //{
        //    // After creating the user...
        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

        //    await _emailSender.SendEmailAsync(user.Email, "Confirm your email", $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>Confirm Email</a>");
        //}
        // Login a user
        public async Task<string> LoginAsync(LoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return "Login successful";
            }
            return "Invalid login attempt";
        }
    }

}
