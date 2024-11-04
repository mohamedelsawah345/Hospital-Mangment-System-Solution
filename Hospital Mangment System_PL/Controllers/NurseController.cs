using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseService _nurseService;

        public NurseController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllNurses()
        {
            var result = await _nurseService.GetAllAsync(); 
            return View(result);
        }

        public async Task<IActionResult> GetNurseById(string id)
        {
            var result = await _nurseService.GetByIdAsync(id); 
            return View(result);
        }

        [HttpGet]
        public IActionResult AddNurse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNurse(CreateNurseVM nurseVM)
        {
            if (ModelState.IsValid) 
            {
                await _nurseService.AddAsync(nurseVM); 
                return RedirectToAction("GetAllNurses");
            }
            return View(nurseVM); 
        }

        public async Task<IActionResult> DeleteNurse(string id)
        {
            await _nurseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNurse(string id)
        {
            var nurse = await _nurseService.GetByIdAsync(id); 
            if (nurse == null)
            {
                return NotFound(); 
            }
            return View(nurse); 
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNurse(UpdateNurseVM nurseVM)
        {
            if (ModelState.IsValid) 
            {
                await _nurseService.UpdateAsync(nurseVM); 
                return RedirectToAction("GetAllNurses");
            }
            return View(nurseVM); 
        }
    }

}
