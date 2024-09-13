// Controllers/CarsApiController.cs
using Microsoft.AspNetCore.Mvc;
using AutoDataHub.Models;
using System.Collections.Generic;
using System.Linq;
using AutoDataHub.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        // Sample in-memory data store (replace with your data source)
        private static readonly List<CarsViewModel> Cars = new List<CarsViewModel>
        {
            new CarsViewModel { Id = 1, Brand = "Toyota", Model = "Corolla", LicensePlate = "ABC123" },
            new CarsViewModel { Id = 2, Brand = "Honda", Model = "Civic", LicensePlate = "XYZ789" }
        };

        // GET: api/cars
        [HttpGet]
        public ActionResult<IEnumerable<CarsViewModel>> GetCars()
        {
            return Ok(Cars);
        }

        // GET: api/cars/5
        [HttpGet("{id}")]
        public ActionResult<CarsViewModel> GetCar(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // POST: api/cars
        [HttpPost]
        public ActionResult<CarsViewModel> CreateCar(CarsViewModel car)
        {
            car.Id = Cars.Max(c => c.Id) + 1; // Simulate auto-increment
            Cars.Add(car);
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // PUT: api/cars/5
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, CarsViewModel updatedCar)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.LicensePlate = updatedCar.LicensePlate;
            return NoContent();
        }

        // DELETE: api/cars/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            Cars.Remove(car);
            return NoContent();
        }
    }
}
