using WPFBoilerPlate.Models;

namespace WPFBoilerPlate.Utils
{
    public static class DebugDataSeeder


    {
        public static void Seed(AppDBContext db)
        {
            if (db.Products.Any())
            {
                return;
            }

            db.Products.AddRange(
                new Product { Name = "Wireless Bluetooth Earbuds", CategoryId = 1 },
                new Product { Name = "27-inch UHD Monitor", CategoryId = 1 },
                new Product { Name = "Mechanical Wireless Keyboard", CategoryId = 1 },
                new Product { Name = "Fast Charging Power Bank", CategoryId = 1 },
                new Product { Name = "Smart AI Speaker", CategoryId = 1 },
                new Product { Name = "Multi-purpose Cleaning Spray", CategoryId = 2 },
                new Product { Name = "Eco-friendly Dish Soap", CategoryId = 2 },
                new Product { Name = "Antibacterial Wet Wipes", CategoryId = 2 },
                new Product { Name = "Large Roll Tissue Pack", CategoryId = 2 },
                new Product { Name = "Non-slip Bathroom Mat", CategoryId = 2 },
                new Product { Name = "Organic Brown Rice", CategoryId = 3 },
                new Product { Name = "Low-Sugar Greek Yogurt", CategoryId = 3 },
                new Product { Name = "High-Protein Chicken Steak", CategoryId = 3 },
                new Product { Name = "Premium Drip Coffee", CategoryId = 3 },
                new Product { Name = "Sugar-Free Nut Mix", CategoryId = 3 },
                new Product { Name = "Slim Fit Denim Jeans", CategoryId = 4 },
                new Product { Name = "Lightweight Padded Jacket", CategoryId = 4 },
                new Product { Name = "Oversized Hoodie", CategoryId = 4 },
                new Product { Name = "Performance Running Leggings", CategoryId = 4 },
                new Product { Name = "A4 Premium Copy Paper", CategoryId = 4 },
                new Product { Name = "Silent Wireless Mouse", CategoryId = 5 },
                new Product { Name = "Ergonomic Keyboard Pad", CategoryId = 5 },
                new Product { Name = "Multi-Compartment Desk Organizer", CategoryId = 5 },
                new Product { Name = "Multi-purpose Cleaning Spray", CategoryId = 5 },
                new Product { Name = "Premium Ballpoint Pen Set", CategoryId = 5 }
                );

            db.SaveChanges();
        }
    }
}
