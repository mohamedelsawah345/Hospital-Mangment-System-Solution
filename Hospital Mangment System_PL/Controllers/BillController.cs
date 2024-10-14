using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.BillVM;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
        }
        public IActionResult Index()
        {
            var res=billService.getAll().ToList();
            return View(res);
        }
        // GET: Bill/Create
        public IActionResult DetailsForSpecificBill()
        {
            return Content("the details of the bill");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]/// Used to protect the application from CSRF attacks by verifying the presence of a valid token in the request
        public IActionResult Create(CreateBillVM bill)
        {
            if (ModelState.IsValid)
            {
                var result = billService.add(bill);
                if (result)
                {
                    return RedirectToAction("Index");// writing t
                }
            }
            return View(bill);
        }
        [HttpGet]
        public IActionResult Edit(int id ) { 
            var bill=billService.getbyId(id);
            if(bill == null)
            {
                return NotFound();
            }
            else
            {
                return View(bill);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateBillVM bill)
        {
            var res = billService.update(bill);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View(bill);
        }
        // GET: Bill/Delete/5
     
        public IActionResult Delete(int id)
        {
            var bill = billService.getbyId(id);
            if (bill.IsDeleted==true)
            {
                return Content("الفاتورة مش موجودة ");
            }
            return View(bill);
        }

        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = billService.delete(id);
            if (result)
            {
           
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}
