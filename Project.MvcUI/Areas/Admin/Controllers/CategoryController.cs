using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Models;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryManager.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {

            await _categoryManager.CreateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            TempData["Saklanan"] = id;
            Category guncellenecek = await _categoryManager.GetByIdAsync(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category model)
        {
            if (model.Id == Convert.ToInt32(TempData["Saklanan"]))
            {
                await _categoryManager.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Seni gidi hacker seni";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Pacify(int id)
        {
            await _categoryManager.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            TempData["Message"] = await _categoryManager.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
