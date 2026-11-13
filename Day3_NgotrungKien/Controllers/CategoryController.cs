using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_NgotrungKien.Data;

namespace Day3_NgotrungKien.Controllers
{
    public class CategoryController : Controller
    {   //Ilogger<CategoryController> _logger;
        private readonly ILogger<CategoryController> _logger;
            // public CategoryController(ILogger<CategoryController> logger)
            public CategoryController(ILogger<CategoryController> logger)
        {
            _logger=logger;
        }
        // GET: Category
        public ActionResult Index(string? search, int page = 1)
        {
            const int pageSize = 2;
            var filteredCategories = SeedData.category.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                filteredCategories = filteredCategories.Where(c =>
                    (c.Name?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    c.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            var totalItems = filteredCategories.Count();
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
            page = Math.Clamp(page, 1, totalPages);

            var categories = filteredCategories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Search = search;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            _logger.LogInformation("Details action called with id: {id}", id);
            _logger.LogError("This is a test error log for category details with id: {id}", id);
            // lay ra id laasy tu dataseed
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
        public ActionResult Delete( int id)
        {
            var category = SeedData.category.FirstOrDefault(category => category.ID==id);
            if (category==null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([FromRoute] int id)
        {
            var esistingCategory = SeedData.category.FirstOrDefault(c => c.ID==id);
            if (esistingCategory==null)
            {
                return NotFound();
            }
            SeedData.category.Remove(esistingCategory);
            return RedirectToAction(nameof(Index));
        }
    }
}
