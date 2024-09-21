using AutoDataHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace AutoDataHub.Controllers
{
    public class CarsController1 : Controller
    {
        public IActionResult Index()
        {
            CarsViewModel c1 = new CarsViewModel
            {
                CarId = 1,
                CarType = "SUV",
                Brand = "Toyota",
                Model = "Fortuner",
                Color = "White",
                LicensePlate = "1234ABC",
            };
            return View(c1);
        }
    }
}
