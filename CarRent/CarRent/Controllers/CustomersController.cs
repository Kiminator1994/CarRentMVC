﻿using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRent.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var customers = await _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = customers.Where(c => string.Equals(c.FirstName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                        string.Equals(c.LastName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                        string.Equals(c.City, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                        string.Equals(c.Nr.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                        string.Equals(c.Address, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", customers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("FirstName,LastName,Address,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Create a new customer
                var newCustomer = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    City = customer.City
                };
                var dbCustomer =  await _service.GetAsync(customer);
                if (dbCustomer == null)
                {
                    customer.Nr = _service.MaxNr() + 1;
                    await _service.AddAsync(customer);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Customer already exists";
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null) 
                return View("empty");
            return View(customerDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,Id,FirstName,LastName,Address,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, customer);
                return RedirectToAction("Index");
            }
            else
                return View(customer);
        }

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            return View(customer);
        }

        [HttpPost, ActionName("Remove")]
        public IActionResult RemoveConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
