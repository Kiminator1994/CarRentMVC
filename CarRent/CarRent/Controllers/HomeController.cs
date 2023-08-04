using CarRent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
       
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}