using CarRent.Data;
using CarRent.Data.Services;
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

        public async Task<IActionResult> Details(int id)
        {
            var carDetails = _service.GetById(id);
            if (carDetails == null) return View("empty");
            return View(carDetails);
        }
    }
}
