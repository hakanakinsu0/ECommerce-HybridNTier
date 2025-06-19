using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models.PageVms;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly IProductManager _productManager;
        readonly ICategoryManager _categoryManager;

        public ProductController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _productManager.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            CreateProductPageVm cpVm = new()
            {
                Categories = _categoryManager.GetActives()
            };
            return View(cpVm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductPageVm model, IFormFile formFile)
        {
            #region ResimKodlari
            Guid uniqueName = Guid.NewGuid();
            string extension = Path.GetExtension(formFile.FileName); //Dosyanın uzantısını ele gecirdik

            //if(extension != "png" || extension != "gif" || extension != "jpeg")
            //{

            //}

            //Db'inizin bilecegi yol icin hazırlıkları
            model.Product.ImagePath = $"/images/{uniqueName}{extension}";

            //Server'daki yol icin hazırlık(Resmin asıl kaydolacagı directory)..Otomatik olarak projenin bulundugu server'i tespit ettirmemiz lazım ki oraya kaydedilsin
            string path = $"{Directory.GetCurrentDirectory()}/wwwroot/{model.Product.ImagePath}";

            FileStream stream = new(path, FileMode.Create);
            formFile.CopyTo(stream);




            #endregion


            await _productManager.CreateAsync(model.Product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            TempData["Saklanan"] = id;

            Product productToUpdate = await _productManager.GetByIdAsync(id);

            if (productToUpdate == null)
            {
                TempData["ErrorMessage"] = "Güncellenecek ürün bulunamadı.";
                return RedirectToAction("Index");
            }

            CreateProductPageVm vm = new()
            {
                Product = productToUpdate,
                Categories = _categoryManager.GetActives()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateProductPageVm model, IFormFile? formFile)
        {
            if (model.Product.Id == Convert.ToInt32(TempData["Saklanan"]))
            {
                // Eğer yeni resim yüklendiyse, mevcut resim yolunu güncelle
                if (formFile != null)
                {
                    Guid uniqueName = Guid.NewGuid();
                    string extension = Path.GetExtension(formFile.FileName);
                    model.Product.ImagePath = $"/images/{uniqueName}{extension}";
                    string path = $"{Directory.GetCurrentDirectory()}/wwwroot/{model.Product.ImagePath}";

                    using FileStream stream = new(path, FileMode.Create);
                    formFile.CopyTo(stream);
                }

                await _productManager.UpdateAsync(model.Product);
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Geçersiz güncelleme girişimi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pacify(int id)
        {
            await _productManager.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            TempData["Message"] = await _productManager.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
