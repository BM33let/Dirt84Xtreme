using BOROMOTORS.Data;
using BOROMOTORS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Dashboard()
    {
        var total = await _context.DirtBikes.CountAsync();
        var avg = await _context.DirtBikes.AverageAsync(b => b.Price);
        var min = await _context.DirtBikes.MinAsync(b => b.Price);
        var top = await _context.DirtBikes
            .GroupBy(b => b.Manufacturer)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefaultAsync();

        var vm = new DashboardViewModel
        {
            TotalBikes = total,
            AveragePrice = avg.GetValueOrDefault(),
            CheapestBike = min.GetValueOrDefault(),
            TopManufacturer = top
        };

        return View(vm);
    }

    // ✅ ChartData е извън Dashboard – правилно
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChartData()
    {
        var brandCounts = await _context.DirtBikes
            .GroupBy(b => b.Manufacturer)
            .Select(g => new { label = g.Key, value = g.Count() })
            .ToListAsync();

        return Json(brandCounts);
    }
}
