using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;
using PortalGrup.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PortalGrup.Controllers
{
    public class HomeController : Controller
    {

        private IEnumerable<ICustomerService> _customerService;
       
        public HomeController(IEnumerable<ICustomerService> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(GetAllCustomers());
        }

        public List<CustomerListModel> GetAllCustomers()
        {
            var customerService = _customerService.SingleOrDefault(s => s.GetType() == typeof(CustomerManager));
            var targetList = customerService.GetAllCustomers()
                .Select(x => new CustomerListModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IdentityNumber = x.IdentityNumber,
                    DateOfBirth = x.DateOfBirth,
                    Company = x.CompanyId
                }).ToList();

            return targetList;
        }

        [HttpPost]
        public IActionResult Index(Customer customer)
        {

            if (customer.CompanyId == 1)
            {
                var starbucksService = _customerService.SingleOrDefault(s => s.GetType() == typeof(StarbuckCustomerManager));
                if (starbucksService.Create(customer))
                {
                    return View(GetAllCustomers());
                }
            }

            if (customer.CompanyId == 2)
            {
                var portalCoffeeService = _customerService.SingleOrDefault(s => s.GetType() == typeof(PortalCoffeeCustomerManager));
                if (portalCoffeeService.Create(customer))
                {
                    return View(GetAllCustomers());
                }
            }

            return View(GetAllCustomers());
        }

        [HttpGet]
        public IActionResult DeletePerson(int customerId)
        {

            var customerService = _customerService.SingleOrDefault(s => s.GetType() == typeof(CustomerManager));
            var person = customerService.GetById(customerId);
            customerService.Delete(person);

            return RedirectToAction("index","home");
        }

        [HttpGet]
        public IActionResult UpdatePerson(int customerId)
        {
            var customerService = _customerService.SingleOrDefault(s => s.GetType() == typeof(CustomerManager));

            var customer = customerService.GetById(customerId);

            return View(
                new CustomerModel()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    IdentityNumber = customer.IdentityNumber,
                    DateOfBirth = customer.DateOfBirth,
                    Company = customer.CompanyId
                });
        }

        [HttpPost]
        public IActionResult UpdatePerson(CustomerModel model)
        {
            
            if (model.Company == 1)
            {
                var starbucksService = _customerService.SingleOrDefault(s => s.GetType() == typeof(StarbuckCustomerManager));
                starbucksService.Update(new Customer()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IdentityNumber = model.IdentityNumber,
                    DateOfBirth = model.DateOfBirth,
                    CompanyId = model.Company
                });
            }

            if (model.Company == 2)
            {
                var portalCoffeeService = _customerService.SingleOrDefault(s => s.GetType() == typeof(PortalCoffeeCustomerManager));
                portalCoffeeService.Update(new Customer()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IdentityNumber = model.IdentityNumber,
                    DateOfBirth = model.DateOfBirth,
                    CompanyId = model.Company
                });
            }
            return RedirectToAction("index","home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
