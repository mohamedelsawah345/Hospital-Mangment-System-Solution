using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllDepartments()
        {

            var result = departmentService.getAll();


            return View(result);

        }
        public IActionResult GetDepartmentById()
        {

            var result = departmentService.getbyId(6);

            return View(result);

        }
        [HttpGet]
        public IActionResult AddDepartment()
        {


            return View();

        }
        [HttpPost]
        public IActionResult AddDepartment(CreateDepartmentVM departmentVM)
        {


            departmentService.add(departmentVM);
            return RedirectToAction("GetAllDepartments");
            //return View();

        }
        //comment test

        public IActionResult DeleteDepartment(int Dnum)
        {
            departmentService.delete(Dnum);

            return RedirectToAction("GetAllDepartments");
        }
        [HttpGet]
        public IActionResult UpdateDepartment()
        {

            return View();


        }

        [HttpPost]
        public IActionResult UpdateDepartment(UpdateDepartmentVM departmentVM)
        {
            departmentService.update(departmentVM);

            return RedirectToAction("GetAllDepartments");


        }
    }
}
