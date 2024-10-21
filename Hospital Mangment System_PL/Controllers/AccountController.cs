using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.AuthenticationVM;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
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
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result);
            }
            return View(model);
        }

    }
}
