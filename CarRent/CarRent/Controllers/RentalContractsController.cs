using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace CarRent.Controllers
{
    public class RentalContractsController : Controller
    {
        private readonly IRentalContractsService _service;
        private readonly IReservationService _reservationService;

        public RentalContractsController( IRentalContractsService service, IReservationService reservationService)
        {
            _service = service;
            _reservationService = reservationService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();        
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var rentalContracts = await _service.GetAllAsync();            
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
        public async Task<IActionResult> Create(int resId)
        {
            var existingContract = await _service.GetContractByReservationId(resId);
            if (existingContract != null)
            {
                TempData["AlertMessage"] = "Rental contract already exists for this reservation.";
                return RedirectToAction("Index", "Reservations");
            }

            var reservation = await _reservationService.GetByIdAsync(resId);
            if (reservation != null)
            {
                RentalContract ren = new RentalContract();
                ren.Reservation = reservation;
                return View(ren);
            }
            else
                return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalContract rentalContract, int resId)
        {
            ModelState.Remove("Car");
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {               
                rentalContract.ReservationId = resId;
                rentalContract.Nr = _service.MaxNr() + 1;
                await _service.AddAsync(rentalContract);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Reservations");

        }      

        public async Task<IActionResult> Remove(int id)
        {
            var rentalContract = await _service.GetByIdAsync(id);
            return View(rentalContract);
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
