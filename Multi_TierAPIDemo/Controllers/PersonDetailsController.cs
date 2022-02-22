using BAL.IService;
using BAL.Services;
using DAL.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Multi_TierAPIDemo.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {

        private readonly IPersonService<PersonModel> _employeeBAL;
        public PersonDetailsController(IPersonService<PersonModel> employeeBAL)
        {
            _employeeBAL = employeeBAL;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var data = await _employeeBAL.GetAll();
            return Ok();
        }

        public Task<PersonModel> GetById(int id)
        {
            return _employeeBAL.GetById(id);
        }

        [HttpPost]       
        public async Task<ActionResult> Create(PersonModel employee)
        {
                await _employeeBAL.Create(employee);
                return Ok();           
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _employeeBAL.DeleteEmployee(id);
            return Ok();
        }


        
        [HttpPost]
        public async Task<ActionResult> UpdateEmp(PersonModel employee)
        {                
                await _employeeBAL.Update(employee);
                return Ok();                       
        }


    }
}

