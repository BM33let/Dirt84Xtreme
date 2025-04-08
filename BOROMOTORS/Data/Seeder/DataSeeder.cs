
using BOROMOTORS.Models;
using Microsoft.AspNetCore.Identity;

namespace BOROMOTORS.Data.Seeder
{
    public static class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            await SeedRoles(roleManager);
            await SeedUsers(userManager, roleManager);
            await SeedBikes(context);
        }

        private static async Task SeedBikes(ApplicationDbContext context)
        {
            List<DirtBike> dirtBikes = new List<DirtBike>
        {
            new DirtBike { Model = "Honda CRF450R", Manufacturer = "Honda", Price = 9599,
                   Horsepower = 55, Weight = 244,
                   TopSpeed = "90 mph (145 km/h)",
                   Description = "Known for its excellent handling and stability, the CRF450R has a lightweight aluminum frame, superior suspension, and an advanced fuel injection system for smooth throttle response.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIq835m0k5UNvtfnO0Lu0bjaygM4PPvi0B3A&s" },

    new DirtBike { Model = "Yamaha YZ450F", Manufacturer = "Yamaha", Price = 9799,
                   Horsepower = 58, Weight = 245,
                   TopSpeed = "85 mph (137 km/h)",
                   Description = "Equipped with Yamaha’s Power Tuner app, this bike allows riders to adjust engine mapping via their smartphone. The YZ450F also has a lightweight chassis and KYB suspension, providing excellent balance and control.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGnX7RJZb_nIfqsaVf4YAYMhUAXQFlycVHeQ&s" },

    new DirtBike { Model = "KTM 250 SX-F", Manufacturer = "KTM", Price = 8499,
                   Horsepower = 47, Weight = 231,
                   TopSpeed = "85 mph (137 km/h)",
                   Description = "The KTM 250 SX-F offers a powerful engine and lightweight design, providing excellent acceleration and handling on both trails and tracks. It’s highly regarded for its precision and performance under demanding conditions.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwtcH6NyzcY5p8Wcio6V79DarvsseMdyC1YQ&s" },

    new DirtBike { Model = "Kawasaki KX250", Manufacturer = "Kawasaki", Price = 7799,
                   Horsepower = 47, Weight = 234,
                   TopSpeed = "82 mph (132 km/h)",
                   Description = "The Kawasaki KX250 is designed with high-performance motocross riders in mind, featuring a strong engine and advanced suspension. It's perfect for riders looking to get ahead of the competition.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYBUBN8gtmNfzSFru9CKIF6rw15C7ixLdThA&s" },

    new DirtBike { Model = "Suzuki RMX450Z", Manufacturer = "Suzuki", Price = 8699,
                   Horsepower = 51, Weight = 258,
                   TopSpeed = "85 mph (137 km/h)",
                   Description = "The RMX450Z is an enduro-focused bike that balances power with control, making it ideal for long-distance off-road riding. With a robust engine and durable design, it excels in challenging conditions.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHWgFgoZLAzrBuQ2X5lzWSl3VdnpCT1pXipQ&s" },

    new DirtBike { Model = "KTM 300 XC-W", Manufacturer = "KTM", Price = 9099,
                   Horsepower = 55, Weight = 233,
                   TopSpeed = "87 mph (140 km/h)",
                   Description = "The KTM 300 XC-W is known for its high power-to-weight ratio and excellent trail performance. It’s a two-stroke engine that delivers incredible torque and acceleration, perfect for tough, technical riding.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRD6kdGeAwWtIW1wb_ZygShYLLvGsMPpybokw&s" },

    new DirtBike { Model = "Yamaha WR250F", Manufacturer = "Yamaha", Price = 8599,
                   Horsepower = 44, Weight = 245,
                   TopSpeed = "85 mph (137 km/h)",
                   Description = "The WR250F is an exceptional enduro bike with excellent suspension, power delivery, and overall durability. It’s built for long-distance trail riding and can handle any obstacles with ease.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3btyu1_WLesvmf_RX1Y_zvAaZm8Yp8GoV8Q&s" },

    new DirtBike {  Model = "Beta 300 RR", Manufacturer = "Beta", Price = 9299,
                   Horsepower = 50, Weight = 235,
                   TopSpeed = "85 mph (137 km/h)",
                   Description = "The Beta 300 RR is an agile and powerful two-stroke machine that offers a balanced ride for trail and enduro riders. It provides excellent power and precise handling on rough terrain.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSW3GnLeBi-Gn8gXOUOCoQsDpknvj9T-x9v2Q&s" },

    new DirtBike { Model = "Sherco 300 SE-R", Manufacturer = "Sherco", Price = 9699,
                   Horsepower = 50, Weight = 239,
                   TopSpeed = "86 mph (138 km/h)",
                   Description = "The Sherco 300 SE-R is built for extreme conditions, with advanced suspension and a powerful engine that provides excellent traction and performance on tough trails and obstacles.",
                   ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVFc144i4PTsjDYZq9wsRVl8D205bKNEzUFQ&s" }
        };

            if (context.DirtBikes.Count() == 0)
            {
                await context.DirtBikes.AddRangeAsync(dirtBikes);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedUsers(UserManager<IdentityUser>? userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminUser = new IdentityUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            string password = "Admin1!";
            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var created = await userManager.CreateAsync(adminUser, password);
                if (created.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            var regularUser = new IdentityUser()
            {
                UserName = "user@user.com",
                Email = "user@user.com",
                EmailConfirmed = true
            };
            var userPassword = "User1!";
            var regularUserExist = await userManager.FindByEmailAsync(regularUser.Email);
            if (regularUserExist == null)
            {

                var created = await userManager.CreateAsync(regularUser, userPassword);
                if (created.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }

        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
