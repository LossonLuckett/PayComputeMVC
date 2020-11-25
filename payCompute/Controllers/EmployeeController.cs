using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;using Microsoft.AspNetCore.Mvc;
using payCompute.Entity;
using payCompute.Models;
using payCompute.Services;

namespace payCompute.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                ImageUrl = employee.ImageUrl,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Designation = employee.Designation,
                City = employee.City,
                DateJoined = employee.DateJoined
            }).ToList();
               
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,

                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    SocialSecurityNo = model.SocialSecurityNo,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    Designation = model.Designation,
                    PhoneNumber = model.PhoneNumber,
                    Postcode = model.Postcode 
                };

                if(model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";

                }
            }
        }

    }
}
