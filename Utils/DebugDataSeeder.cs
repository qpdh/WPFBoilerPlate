using WPFBoilerPlate.Models.Entities;

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
                new ProductEntity { Name = "Wireless Bluetooth Earbuds", CategoryId = 1 },
                new ProductEntity { Name = "27-inch UHD Monitor", CategoryId = 1 },
                new ProductEntity { Name = "Mechanical Wireless Keyboard", CategoryId = 1 },
                new ProductEntity { Name = "Fast Charging Power Bank", CategoryId = 1 },
                new ProductEntity { Name = "Smart AI Speaker", CategoryId = 1 },
                new ProductEntity { Name = "Multi-purpose Cleaning Spray", CategoryId = 2 },
                new ProductEntity { Name = "Eco-friendly Dish Soap", CategoryId = 2 },
                new ProductEntity { Name = "Antibacterial Wet Wipes", CategoryId = 2 },
                new ProductEntity { Name = "Large Roll Tissue Pack", CategoryId = 2 },
                new ProductEntity { Name = "Non-slip Bathroom Mat", CategoryId = 2 },
                new ProductEntity { Name = "Organic Brown Rice", CategoryId = 3 },
                new ProductEntity { Name = "Low-Sugar Greek Yogurt", CategoryId = 3 },
                new ProductEntity { Name = "High-Protein Chicken Steak", CategoryId = 3 },
                new ProductEntity { Name = "Premium Drip Coffee", CategoryId = 3 },
                new ProductEntity { Name = "Sugar-Free Nut Mix", CategoryId = 3 },
                new ProductEntity { Name = "Slim Fit Denim Jeans", CategoryId = 4 },
                new ProductEntity { Name = "Lightweight Padded Jacket", CategoryId = 4 },
                new ProductEntity { Name = "Oversized Hoodie", CategoryId = 4 },
                new ProductEntity { Name = "Performance Running Leggings", CategoryId = 4 },
                new ProductEntity { Name = "A4 Premium Copy Paper", CategoryId = 4 },
                new ProductEntity { Name = "Silent Wireless Mouse", CategoryId = 5 },
                new ProductEntity { Name = "Ergonomic Keyboard Pad", CategoryId = 5 },
                new ProductEntity { Name = "Multi-Compartment Desk Organizer", CategoryId = 5 },
                new ProductEntity { Name = "Multi-purpose Cleaning Spray", CategoryId = 5 },
                new ProductEntity { Name = "Premium Ballpoint Pen Set", CategoryId = 5 }
                );

            db.SaveChanges();
        }
    }
}