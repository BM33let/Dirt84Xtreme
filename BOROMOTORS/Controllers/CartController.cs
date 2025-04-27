using Microsoft.AspNetCore.Mvc;
using BOROMOTORS.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOROMOTORS.Controllers
{
    public class CartController : Controller
    {
        private static List<DirtBike> allBikes = new List<DirtBike>
        {
            new DirtBike { Model = "Honda CRF450R", Manufacturer = "Honda", Price = 9599, Horsepower = 55, Weight = 244, TopSpeed = "90 mph (145 km/h)", Category = "4-тактови", Description = "Known for its excellent handling and stability, the CRF450R has a lightweight aluminum frame, superior suspension, and an advanced fuel injection system.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIq835m0k5UNvtfnO0Lu0bjaygM4PPvi0B3A&s" },
            new DirtBike { Model = "Yamaha YZ450F", Manufacturer = "Yamaha", Price = 9799, Horsepower = 58, Weight = 245, TopSpeed = "85 mph (137 km/h)", Category = "4-тактови", Description = "Equipped with Yamaha’s Power Tuner app and lightweight chassis.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGnX7RJZb_nIfqsaVf4YAYMhUAXQFlycVHeQ&s" },
            new DirtBike { Model = "KTM 250 SX-F", Manufacturer = "KTM", Price = 8499, Horsepower = 47, Weight = 231, TopSpeed = "85 mph (137 km/h)", Category = "4-тактови", Description = "The KTM 250 SX-F offers powerful engine and lightweight design.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwtcH6NyzcY5p8Wcio6V79DarvsseMdyC1YQ&s" },
            new DirtBike { Model = "Kawasaki KX250", Manufacturer = "Kawasaki", Price = 7799, Horsepower = 47, Weight = 234, TopSpeed = "82 mph (132 km/h)", Category = "2-тактови", Description = "Designed for high-performance motocross riders.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYBUBN8gtmNfzSFru9CKIF6rw15C7ixLdThA&s" },
            new DirtBike { Model = "Suzuki RMX450Z", Manufacturer = "Suzuki", Price = 8699, Horsepower = 51, Weight = 258, TopSpeed = "85 mph (137 km/h)", Category = "4-тактови", Description = "Enduro-focused bike balancing power with control.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHWgFgoZLAzrBuQ2X5lzWSl3VdnpCT1pXipQ&s" },
            new DirtBike { Model = "KTM 300 XC-W", Manufacturer = "KTM", Price = 9099, Horsepower = 55, Weight = 233, TopSpeed = "87 mph (140 km/h)", Category = "2-тактови", Description = "High power-to-weight ratio perfect for trails.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRD6kdGeAwWtIW1wb_ZygShYLLvGsMPpybokw&s" },
            new DirtBike { Model = "Yamaha WR250F", Manufacturer = "Yamaha", Price = 8599, Horsepower = 44, Weight = 245, TopSpeed = "85 mph (137 km/h)", Category = "4-тактови", Description = "Enduro bike for long-distance trail riding.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3btyu1_WLesvmf_RX1Y_zvAaZm8Yp8GoV8Q&s" },
            new DirtBike { Model = "Beta 300 RR", Manufacturer = "Beta", Price = 9299, Horsepower = 50, Weight = 235, TopSpeed = "85 mph (137 km/h)", Category = "2-тактови", Description = "Agile and powerful two-stroke machine.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSW3GnLeBi-Gn8gXOUOCoQsDpknvj9T-x9v2Q&s" },
            new DirtBike { Model = "Sherco 300 SE-R", Manufacturer = "Sherco", Price = 9699, Horsepower = 50, Weight = 239, TopSpeed = "86 mph (138 km/h)", Category = "2-тактови", Description = "Built for extreme conditions.", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVFc144i4PTsjDYZq9wsRVl8D205bKNEzUFQ&s" }
        };

        private static List<DirtBike> cartItems = new List<DirtBike>();

        public IActionResult Index()
        {
            return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            var bike = allBikes.ElementAtOrDefault(id);
            if (bike != null)
            {
                cartItems.Add(bike);
                return Json(new { success = true, count = cartItems.Count });
            }
            else
            {
                return Json(new { success = false, message = "Моторът не е намерен." });
            }
        }
    }
}