using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BOROMOTORS.Data;
using BOROMOTORS.Models;
using System;

namespace BOROMOTORS.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rentals = _context.Rentals.ToList();
            return View(rentals);
        }

        public IActionResult Rent(int motorId)
        {
            var motor = _context.Motors.Find(motorId);
            if (motor == null)
            {
                return NotFound();
            }

            var rental = new Rental { MotorId = motor.Id, Price = motor.PricePerDay };      

            return View(rental);
        }

        [HttpPost]
        public IActionResult Rent(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Rentals.Add(rental);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental);
        }
    }
}
