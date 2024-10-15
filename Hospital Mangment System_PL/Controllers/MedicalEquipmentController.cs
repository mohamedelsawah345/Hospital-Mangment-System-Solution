using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.BillVM;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class MedicalEquipmentController : Controller
    {
        IMedicalEquipmentService _medicalEquipmentService;
        public MedicalEquipmentController(IMedicalEquipmentService medicalEquipmentService)
        {
            _medicalEquipmentService=medicalEquipmentService;
        }
        //MedicalEquipment/index
        public IActionResult Index()
        {
            var res = _medicalEquipmentService.getAll().ToList();
            return View(res);
        }
        // GET: MedicalEquipment/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]/// Used to protect the application from CSRF attacks by verifying the presence of a valid token in the request
        public IActionResult Create(CreateEquipmentVM MedicalEquipment)
        {
            if (ModelState.IsValid)
            {
                var result = _medicalEquipmentService.add(MedicalEquipment);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(MedicalEquipment);
        }
        //MedicalEquipment/Edit/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var  equip = _medicalEquipmentService.getbyId(id);
            if (equip == null)
            {
                return NotFound();
            }
            var updateEquipmentVM = new UpdateEquipmentVM
            {
                Equipment_Id = equip.Equipment_Id,  // Ensure these properties exist in equip
                Equip_name = equip.Equip_name,
                Maintence_date = equip.Maintence_date,
                Dnum = equip.Dnum,
                Department = equip.Department, // Adjust as necessary
                IsDeleted = (bool)equip.IsDeleted
            };
            return View(updateEquipmentVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateEquipmentVM bill)
        {
            var res = _medicalEquipmentService.update(bill);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View(bill);
        }
        // GET: medicalEquipmen/Delete/5

        public IActionResult Delete(int id)
        {
            var medical = _medicalEquipmentService.getbyId(id);

            if (medical == null)
            {
                return Content("a7a");// Return a 404 
            }

            if (medical.IsDeleted == null)
            {
                return Content("الفاتورة مش موجودة");
            }

            return View(medical);
        }


        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _medicalEquipmentService.delete(id);
            if (result)
            {

                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }

}

