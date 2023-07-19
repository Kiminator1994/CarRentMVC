using CarRent.Data;
using CarRent.Data.Services;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _service;

        public CarsController(ICarsService service)
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
            var cars = await _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {               
                var filteredResultNew =  cars.Where(c => string.Equals(c.Brand, searchString, StringComparison.CurrentCultureIgnoreCase) || 
                                                        string.Equals(c.ModelType, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                        string.Equals(c.Nr.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                                        string.Equals(c.Category.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", cars);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("empty");
            return View(carDetails);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsRemove(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Description,PictureUrl,Category,Brand,ModelType")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.Nr = _service.MaxNr() + 1;
                _service.AddAsync(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
    }
}
