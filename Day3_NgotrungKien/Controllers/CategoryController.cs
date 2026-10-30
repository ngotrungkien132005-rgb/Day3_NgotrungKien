using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_NgotrungKien.Data;

namespace Day3_NgotrungKien.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var _categories = SeedData.category;
            return View(_categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {

            var category = SeedData.category.FirstOrDefault(c => c.ID==id);
            // neu category==null thi tr ve trang loi
            if (category==null)
            {
                return NotFound();
            }
            // neu category khac null thi tra vef view vaf truyen category vo view
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Category category)
        {
            if (ModelState.IsValid)
            {
                //lay max id trong danh sacsh seeddata.category
                int maxId = SeedData.category.Max(c => c.ID);
                //set id cho category
                category.ID=maxId+1;
                // them category vao danh sasch seeddata.category
                SeedData.category.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var category = SeedData.category.FirstOrDefault(category => category.ID==id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Category category)
        {
            var eistingCategory = SeedData.category.FirstOrDefault(c => c.ID==category.ID);
            if(eistingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                eistingCategory.Name=category.Name;
                eistingCategory.Description=category.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
