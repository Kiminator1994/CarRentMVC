using CarRent.Data;
using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _service;
        private readonly ICustomerService _customerService;

        public ReservationsController(IReservationService service, ICustomerService customerService)
        {
            _service = service;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,EndDate,TotalFee")] Reservation reservation, string firstName, string lastName, string address, string city)
        {
            if (ModelState.IsValid)
            {
                // Create a new customer
                var customer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city
                };

                // Assign the customer to the reservation
                reservation.Customer = customer;

                // Save the customer and reservation
                _customerService.Add(customer);
                _service.Add(reservation);

                return RedirectToAction("Index");
            }

            return View(reservation);
        }
    }
}
