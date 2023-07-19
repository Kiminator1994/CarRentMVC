using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRent.Controllers
{
    public class RentalContractsController : Controller
    {
        private readonly IRentalContractsService _service;
        private readonly IReservationService _reservationService;
        private readonly ICustomerService _customerService;
        private readonly ICarsService _carsService;

        public RentalContractsController( IRentalContractsService service, IReservationService reservationService, ICustomerService customerService, ICarsService carsService)
        {
            _service = service;
            _reservationService = reservationService;
            _customerService = customerService;
            _carsService = carsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            foreach (var rentalContract in data)
            {
                rentalContract.Reservation = await _reservationService.GetByIdAsync(rentalContract.ReservationId);
                rentalContract.Reservation.Car = await _carsService.GetByIdAsync(rentalContract.Reservation.CarId);
                rentalContract.Reservation.Customer = await _customerService.GetByIdAsync(rentalContract.Reservation.CustomerId);
            }
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var rentalContracts = await _service.GetAllAsync();
            foreach (var rentalContract in rentalContracts)
            {
                rentalContract.Reservation = await _reservationService.GetByIdAsync(rentalContract.ReservationId);
                rentalContract.Reservation.Car = await _carsService.GetByIdAsync(rentalContract.Reservation.CarId);
                rentalContract.Reservation.Customer = await _customerService.GetByIdAsync(rentalContract.Reservation.CustomerId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = rentalContracts.Where(c => string.Equals(c.Reservation.Customer.FirstName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Reservation.Customer.LastName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Reservation.Customer.City, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Nr.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Reservation.Car.ModelType, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                                string.Equals(c.Reservation.Car.Brand, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNew);
            }
            return View("Index", rentalContracts);
        }
        public async Task<IActionResult> Create(int carId)
        {          

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,EndDate,TotalFee")] Reservation reservation, Customer customer, int carId)
        {
            return View();

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
    }
}
