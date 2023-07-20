using CarRent.Data;
using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRent.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _service;
        private readonly ICustomerService _customerService;
        private readonly ICarsService _carsService;

        public ReservationsController(IReservationService service, ICustomerService customerService, ICarsService carsService)
        {
            _service = service;
            _customerService = customerService;
            _carsService = carsService;
        }
        public async Task<IActionResult> Index()
        {
            var data =  _service.GetAll();
            foreach(var reservation in data)
            {
                reservation.Car = await _carsService.GetByIdAsync(reservation.CarId);
                reservation.Customer = await _customerService.GetByIdAsync(reservation.CustomerId);
            }
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var reservations = _service.GetAll();
            foreach (var reservation in reservations)
            {
                reservation.Car = await _carsService.GetByIdAsync(reservation.CarId);
                reservation.Customer = await _customerService.GetByIdAsync(reservation.CustomerId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = reservations.Where(c => string.Equals(c.Customer.FirstName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Customer.LastName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Customer.City, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Nr.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Car.ModelType, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Car.Brand, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNew);
            }
            return View("Index", reservations);
        }
        public async Task<IActionResult> Create(int carId)
        {
            var car = await _carsService.GetByIdAsync(carId);
            var existingReservations = await _service.GetByCarIdAsync(carId);

            var reservedDates = existingReservations.Select(r => new { From = r.StartDate, To = r.EndDate })
                                                    .SelectMany(r => Enumerable.Range(0, 1 + r.To.Subtract(r.From).Days)
                                                    .Select(offset => r.From.AddDays(offset).ToString("yyyy-MM-dd")))
                                                    .ToList();
            ViewData["ReservedDates"] = JsonSerializer.Serialize(reservedDates);
            ViewData["CarId"] = carId;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,EndDate,TotalFee")] Reservation reservation, Customer customer, int carId)
        {
            ModelState.Remove("Car");
            ModelState.Remove("Customer");
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
                var dbCustomer = await _customerService.GetAsync(customer);
                if (dbCustomer == null)
                {
                    customer.Nr = _customerService.MaxNr() + 1;
                    await _customerService.AddAsync(customer);
                    dbCustomer = await _customerService.GetAsync(customer);
                }                                                           
                reservation.CarId = carId;
                reservation.CustomerId = dbCustomer.Id;
                reservation.Nr = _service.MaxNr() + 1;
                await _service.AddAsync(reservation);

                return RedirectToAction("Index");
            }
            else
            {
                var car = await _carsService.GetByIdAsync(carId);
                var existingReservations = await _service.GetByCarIdAsync(carId);

                var reservedDates = existingReservations.Select(r => new { From = r.StartDate, To = r.EndDate })
                                                        .SelectMany(r => Enumerable.Range(0, 1 + r.To.Subtract(r.From).Days)
                                                        .Select(offset => r.From.AddDays(offset).ToString("yyyy-MM-dd")))
                                                        .ToList();
                ViewData["ReservedDates"] = JsonSerializer.Serialize(reservedDates);
                ViewData["CarId"] = carId;
                ViewData["Category"] = (decimal)car.Category;
                reservation.Customer = new Customer();
                if(customer.Address != null)
                reservation.Customer.Address = customer.Address;
                if(customer.City != null)
                reservation.Customer.City = customer.City;
                if(customer.FirstName != null)
                reservation.Customer.FirstName = customer.FirstName;
                if(customer.LastName != null)
                reservation.Customer.LastName = customer.LastName;
                return View(reservation);
            }
                
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _service.GetByIdAsync(id);          
            var existingReservations = await _service.GetByCarIdAsync(reservation.CarId);

            var reservedDates = existingReservations.Select(r => new { From = r.StartDate, To = r.EndDate })
                                                    .SelectMany(r => Enumerable.Range(0, 1 + r.To.Subtract(r.From).Days)
                                                    .Select(offset => r.From.AddDays(offset).ToString("yyyy-MM-dd")))
                                                    .ToList();
            ViewData["ReservedDates"] = JsonSerializer.Serialize(reservedDates);
            ViewData["CarId"] = reservation.CarId;

            if (reservation == null) return View("empty");
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("StartDate,EndDate,TotalFee")] Reservation reservation, string firstName, string lastName, string address, string city, int carId)
        {
            ModelState.Remove("Car");
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(carId, reservation);
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var reservation = await _service.GetByIdAsync(id);
            return View(reservation);
        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveConfirmed(int resId)
        {
            _service.Delete(resId);
            return RedirectToAction("Index");
        }

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
    }
}
