using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model.AuthenticationVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IDepartmentRepo departmentRepo;

        public AccountController(IAuthService authService, IDepartmentRepo departmentRepo)
        {
            _authService = authService;
            this.departmentRepo = departmentRepo;
        }

        // Register
        public IActionResult Register()
        {
            return View();
        }

        // Register Doctor
        [HttpGet]
        public IActionResult RegisterDoctor()
        {
            var departments = departmentRepo.getAll(); // Returns a list of departments
            ViewBag.Departments = departments;
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterDoctorAsync(model);
                if (result)
                {
                    // Optionally send confirmation email
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Registration failed");
            }
            ViewBag.Departments = departmentRepo.getAll();
            return View(model);
        }

        // Register Nurse
        [HttpGet]
        public IActionResult RegisterNurse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNurse(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterNurseAsync(model);
                if (result)
                {
                    // Optionally send confirmation email
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Registration failed");
            }
            return View(model);
        }

        // Register Patient
        [HttpGet]
        public IActionResult RegisterPatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterPatientAsync(model);
                if (result)
                {
                    // Optionally send confirmation email
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Registration failed");
            }
            return View(model);
        }

        // Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(model);
                if (result == "Login successful")
                {
                    HttpContext.Session.SetString("Username", model.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result);
            }
            return View(model);
        }
        public async Task<IActionResult> SignOut()
        {
            try
            {
                await _authService.SignOutAsync(); // Await the async sign-out operation
                HttpContext.Session.Remove("Username"); // Optional: Remove the username from session
                return RedirectToAction("Index", "Home"); // Redirect to Home after sign-out
            }
            catch
            {
                // Optionally log the error and return error message
                ModelState.AddModelError("", "An error occurred while signing out.");
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
