using Day3_NgotrungKien.Data;
using Day3_NgotrungKien.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Day3_NgotrungKien.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            var product  = from p in Data.Data.products
                           join c in SeedData.category on p.CategoryID equals c.ID
                           select new Models.ProductNewModel
                           {
                               ID=p.ID,
                               Name=p.Name,
                               Price=p.Price,
                               Description=p.Description,
                               CategoryName=c.Name

                           } ;

            return View(product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = Data.Data.products.FirstOrDefault(p => p.ID==id);
            if (product == null)
            {
                return NotFound();
            }

            product.Category = SeedData.category.FirstOrDefault(c => c.ID == product.CategoryID);

            return View(product);

        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Product product)
        {
            if(ModelState.IsValid)
            {
                var products = new Models.Product
                {
                    ID = Data.Data.products.Max(p => p.ID) + 1,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CategoryID = product.CategoryID
                };
                Data.Data.products.Add(products);
                return RedirectToAction(nameof(Index));
            }


            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var product = Data.Data.products.FirstOrDefault(p => p.ID==id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Product product)
        {
            var eisitingProduct = Data.Data.products.FirstOrDefault(p => p.ID==product.ID);
            if(eisitingProduct==null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                eisitingProduct.Name=product.Name;
                eisitingProduct.Price=product.Price;
                eisitingProduct.Description=product.Description;
                eisitingProduct.CategoryID=product.CategoryID;
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = Data.Data.products.FirstOrDefault(p => p.ID==id);
            if (product==null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([FromRoute] int id)
        {
           var existingProduct = Data.Data.products.FirstOrDefault(p => p.ID==id);
            if (existingProduct==null)
            {
                return NotFound();
            }
            Data.Data.products.Remove(existingProduct);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
