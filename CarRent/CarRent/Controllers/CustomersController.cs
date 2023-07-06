using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Nr,FirstName,LastName,Address,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _service.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);           
        }

        public async Task<IActionResult> Edit(int id)
        {

            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null) return View("empty");
            return View(customerDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nr,FirstName,LastName,Address,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
               await  _service.UpdateAsync(id, customer);
                return RedirectToAction("Index");
            }
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
