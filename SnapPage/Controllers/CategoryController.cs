using Microsoft.AspNetCore.Mvc;
using SnapPage.Database;
using SnapPage.Models;

namespace SnapPage.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _dbContext.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
