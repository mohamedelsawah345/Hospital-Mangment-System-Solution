using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseService nurseService;

        public NurseController(INurseService nurseService)
        {
            this.nurseService = nurseService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllNurses()
        {

            var result = nurseService.getAll();


            return View(result);

        }
        public IActionResult GetNurseById(string id)
        {

            var result = nurseService.getbyId(id);

            return View(result);

        }
        [HttpGet]
        public IActionResult AddNurse()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddNurse(CreateNurseVM nurseVM)
        {


            nurseService.add(nurseVM);
            return RedirectToAction("GetAllNurses");
            //return View();

        }
        //comment test

        public IActionResult DeleteNurse(string Id)
        {
            nurseService.delete(Id);

            return RedirectToAction("GetAllNurses");
        }
        [HttpGet]
        public IActionResult UpdateNurse()
        {

            return View();


        }

        [HttpPost]
        public IActionResult UpdateNurse(UpdateNurseVM nurseVM)
        {
            nurseService.update(nurseVM);

            return RedirectToAction("GetAllNurses");


        }
    }
}
