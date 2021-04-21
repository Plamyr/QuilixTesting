using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QulixApp.BusinessLogicLayer.Services.Interfaces;
using QulixApp.PresentationLayer.Mapper;
using QulixApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QulixApp.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyService _companyService;
        private readonly IEmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger, ICompanyService companyService, IEmployeeService employeeService)
        {
            _logger = logger;
            _companyService = companyService;
            _employeeService = employeeService;
        }

        public IActionResult Companies()
        {
            var allCompanies = _companyService.GetAllCompanies();
            var listOfViewModels = new List<CompanyViewModel>();
            foreach (var item in allCompanies) 
            { 
                listOfViewModels.Add(MapperViewModel.Map(item)); 
            }
            return View(listOfViewModels);
        }
        public IActionResult Employees()
        {
            var allEmployees = _employeeService.GetAllEmployees();
            var listOfViewModels = new List<EmployeeViewModel>();
            foreach (var item in allEmployees)
            {
                listOfViewModels.Add(MapperViewModel.Map(item));
            }
            return View(listOfViewModels);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            _companyService.GetAllCompanies();
            List<CompanyViewModel> model = new List<CompanyViewModel>();
            foreach (var item in _companyService.GetAllCompanies())
            {
                model.Add(MapperViewModel.Map(item));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel model)
        {
            var dto = MapperViewModel.Map(model);
            _employeeService.AddEmployee(dto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            _companyService.GetAllCompanies();
            List<CompanyViewModel> model = new List<CompanyViewModel>();
            foreach (var item in _companyService.GetAllCompanies())
            {
                model.Add(MapperViewModel.Map(item));
            }
            ViewBag.EmployeeId = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeViewModel model)
        {
            var dto = MapperViewModel.Map(model);
            _employeeService.UpdateEmployee(dto);
            return RedirectToAction("Employees", "Home");
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyViewModel model)
        {
            var dto = MapperViewModel.Map(model);
            _companyService.CreateCompany(dto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UpdateCompany(int id)
        {
            ViewBag.CompanyId = id;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCompany(CompanyViewModel model)
        {
            var dto = MapperViewModel.Map(model);
            _companyService.UpdateCompany(dto);
            return RedirectToAction("Companies", "Home");
        }

        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Employees", "Home");
        }
        public IActionResult DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
            return RedirectToAction("Companies", "Home");
        }
    }
}
