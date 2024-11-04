using Hospital_Mangment_System_BLL.Service.Abstraction;
using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllAppointment()
        {
            var result = _appointmentService.GetAll();
            return View(result);
        }

        public IActionResult GetAppointmentById(int id)
        {
            var result = _appointmentService.GetById(id);
            if (result == null)
            {
                TempData["Error"] = "Appointment not found!";
                return RedirectToAction("GetAllAppointment");
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        // إضافة موعد جديد
        [HttpPost]
        public IActionResult AddAppointment(AddAppointmentVM appointmentVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid data. Please try again.";
                return View(appointmentVM);
            }

            var success = _appointmentService.Add(appointmentVM); // تأكد من استخدام Add
            if (success)
            {
                TempData["Success"] = "Appointment added successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to add appointment!";
            }
            return RedirectToAction("GetAllAppointment");
        }
    }
}
