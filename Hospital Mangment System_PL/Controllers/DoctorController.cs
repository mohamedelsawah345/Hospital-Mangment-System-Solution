using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;//خلي بالك انت بتعمل انستنس من الكلاس الانترفيس

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllDoctors()
        {

            var result = _doctorService.getAll();


            return View(result);

        }
        public IActionResult GetDoctorById()
        {

            var result = _doctorService.getbyId(5);

            return View(result);

        }
        [HttpGet]
        public IActionResult AddDoctor()
        {


            return View();

        }
        [HttpPost]
        public IActionResult AddDoctort(CreateDoctorVM DoctorVM)
        {


            _doctorService.add(DoctorVM);
            return RedirectToAction("GetAllDoctors");
            //return View();

        }
        //comment test

        public IActionResult DeleteDoctor(int id)
        {
            _doctorService.delete(8);

            return RedirectToAction("GetAllDoctors");
        }
        [HttpGet]
        public IActionResult UpdateDoctor()
        {

            return View();


        }

        [HttpPost]
        public IActionResult UpdateDoctor(UpdateDoctorVM DoctorVM)
        {
            _doctorService.update(DoctorVM);

            return RedirectToAction("GetAllDoctors");


        }



    }
}
