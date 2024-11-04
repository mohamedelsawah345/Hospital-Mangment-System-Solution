using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _doctorService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> GetDoctorById(string id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(CreateDoctorVM doctorVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _doctorService.AddAsync(doctorVM);
                if (result)
                {
                    return RedirectToAction("GetAllDoctors");
                }
                ModelState.AddModelError("", "Unable to add doctor. Please try again.");
            }

            return View(doctorVM);
        }

        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _doctorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDoctor(string id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorVM doctorVM)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.UpdateAsync(doctorVM);
                return RedirectToAction("GetAllDoctors");
            }
            return View(doctorVM); 
        }
    }

}
