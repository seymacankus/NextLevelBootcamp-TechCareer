using Microsoft.AspNetCore.Mvc;
using Next_Level_Bootcamp_Task1.Models;
using Next_Level_Bootcamp_Task1.Models.ViewModels;
using System.Diagnostics;

namespace Next_Level_Bootcamp_Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindDbContext _northwindDbContext;

        public HomeController(ILogger<HomeController> logger, NorthwindDbContext northwindDbContext)
        {
            _logger = logger;
            _northwindDbContext = northwindDbContext;
        }

        public IActionResult Index()
        {
            var employees = _northwindDbContext.Employees.ToList();
            return View(employees);
            
        }

        public IActionResult ShowOrders(int id)
        {
            var ordersOfEmployee = _northwindDbContext.Orders.Where(x => x.EmployeeId == id).ToList();
            ViewBag.Employee = _northwindDbContext.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View("OrdersOfEmployee",ordersOfEmployee);
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var employeeViewModel = new EmployeeViewModel();
            return View(employeeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.HomePhone = model.HomePhone;
                employee.HireDate = model.HireDate;
                employee.BirthDate = model.BirthDate;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.Region = model.Region;
                employee.Country = model.Country;
                employee.Notes = model.Notes;
                employee.PostalCode = model.PostalCode;
                employee.ReportsTo = model.ReportsTo;
                employee.Title = model.Title;
                employee.TitleOfCourtesy = model.TitleOfCourtesy;
                employee.Extension = model.Extension;

                await _northwindDbContext.Employees.AddAsync(employee);
                await _northwindDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
            
        }
    }
}