using CarRent.Data;
using CarRent.Data.Services;
using CarRent.Models;
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("empty");
            return View(carDetails);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Nr,PictureUrl,Category,Brand,ModelType")] Car car)
        {
            if (ModelState.IsValid)
            {              
                _service.Add(car);

                return RedirectToAction("Index");
            }

            return View(car);
        }
       
        public IActionResult Remove(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
    }
}
