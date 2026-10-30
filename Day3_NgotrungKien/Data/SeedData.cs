using Day3_NgotrungKien.Models;
namespace Day3_NgotrungKien.Data
{
    public class SeedData
    {
        //Gia lap du lieu ban dau cho database
        public static List<Models.Category> category=new List<Models.Category>
        {
            new Models.Category(){ID=1,Name="Category 1", Description="Description 1"},
            new Models.Category(){ID=2,Name="Category 2", Description="Description 2"},
            new Models.Category(){ID=3,Name="Category 3", Description="Description 3"},
        };
    }
}
