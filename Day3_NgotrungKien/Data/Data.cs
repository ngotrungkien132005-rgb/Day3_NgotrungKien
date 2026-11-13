using Day3_NgotrungKien.Models;

namespace Day3_NgotrungKien.Data
{
    public class Data
    {
        public static List<Models.Product> products = new List<Models.Product>
            {
            new Models.Product(){ID=1,Name="Product 1",Price= 1000, Description="San pham danh muc 1",CategoryID=1 },
            new Models.Product(){ID=2,Name="Product 2", Price=2000,Description="San pham danh muc 2", CategoryID=2},
            new Models.Product(){ID=3, Name="Product 3",Price=1200,Description="San pham danh muc 3", CategoryID=3}
        };

    }
}
