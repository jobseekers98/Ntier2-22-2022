using BAL;
using BAL.IService;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTier_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBAL _employeeBAL;
        public EmployeeController(IEmployeeBAL employeeBAL)
        {
            _employeeBAL = employeeBAL;
        }
        public async Task<IActionResult> Index()
        {

            var data = await _employeeBAL.GetEmployee();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeBAL.AddEmployee(employee);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _employeeBAL.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmp(int id)
        {

            var data = await _employeeBAL.GetEmployeeId(id);
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateEmp(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeBAL.UpdateEmployee(employee);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }






    }
}
