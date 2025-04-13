using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BOROMOTORS.Data;
using BOROMOTORS.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            var userEmail = User.Identity.Name;
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == userEmail);

            var orders = await _context.Orders
                .Where(o => o.CustomerId == customer.Id)
                .Include(o => o.DirtBike)
                .ToListAsync();

            return View(orders);
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
