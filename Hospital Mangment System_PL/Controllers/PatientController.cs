using Microsoft.AspNetCore.Mvc;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;
namespace Hospital_Mangment_System_PL.Controllers
{
    public class PatientController : Controller
    {
      private readonly  IPatientService _patientService;//خلي بالك انت بتعمل انستنس من الكلاس الانترفيس

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllPatient()
        {

           var result= _patientService.getAll();


            return View(result);

        }
        public IActionResult GetPatientById()
        {

            var result = _patientService.getbyId(5);

            return View(result);

        }
        [HttpGet]
        public IActionResult AddPatient()
        {


            return View();

        }
        [HttpPost]
        public IActionResult AddPatient(CreatePatientVM patientVM)
        {


            _patientService.add(patientVM);
          return  RedirectToAction("GetAllPatient");
            //return View();

        }

        public IActionResult DeletePatient(int id)
        {
            _patientService.delete(8);

          return  RedirectToAction("GetAllPatient");
        }
        [HttpGet]
        public IActionResult UpdatePatient()
        {
           
            return View();


        }

        [HttpPost]
        public IActionResult UpdatePatient(UpdatePatientVM patientvm)
        {
            _patientService.update(patientvm);

            return RedirectToAction("GetAllPatient");


        }





    }
}
