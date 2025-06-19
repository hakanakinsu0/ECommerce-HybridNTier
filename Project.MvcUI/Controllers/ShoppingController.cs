using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms;
using Project.MvcUI.Models.SessionService;
using Project.MvcUI.Models.ShoppingTools;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

namespace Project.MvcUI.Controllers
{
    public class ShoppingController : Controller
    {
        readonly IProductManager _productManager;
        readonly ICategoryManager _categoryManager;
        readonly IOrderManager _orderManager;
        readonly IOrderDetailManager _orderDetailManager;
        readonly UserManager<AppUser> _userManager;
        readonly IHttpClientFactory _httpClientFactory; //API icin entegre ettigimiz fieldir.

        public ShoppingController(IProductManager productManager, ICategoryManager categoryManager, IOrderManager orderManager, IOrderDetailManager orderDetailManager, UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        //ToDo : API icin sistem entegrasyonu yapilacak.

        public async Task<IActionResult> Index(int? page, int? categoryId)
        {
            List<Product> productList = categoryId == null ? await _productManager.GetAllAsync() : _productManager.Where(x => x.CategoryId == categoryId).ToList();

            IPagedList<Product> pagedProducts = productList.ToPagedList(page ?? 1, 5);

            List<Category> categories = await _categoryManager.GetAllAsync();

            ShoppingPageVm spVm = new()
            {
                Products = pagedProducts,
                Categories = categories
            };

            if (categoryId != null) TempData["catId"] = categoryId;

            return View(spVm);
        }

        #region ControllerPrivateMetotlari
        void SetCartForSession(Cart c)
        {
            HttpContext.Session.SetObject("scart", c);
        }

        Cart GetCartFromSession(string key)
        {
            return HttpContext.Session.GetObject<Cart>(key);
        }

        void ControlCart(Cart c)
        {
            if (c.GetCartItems.Count == 0) HttpContext.Session.Remove("scart");
        }

        #endregion

        public async Task<IActionResult> AddToCart(int id)
        {
            Cart c = GetCartFromSession("scart") == null ? new Cart() : GetCartFromSession("scart");

            Product productToBeAdded = await _productManager.GetByIdAsync(id);

            CartItem ci = new()
            {
                Id = productToBeAdded.Id,
                ProductName = productToBeAdded.ProductName,
                UnitPrice = productToBeAdded.UnitPrice,
                ImagePath = productToBeAdded.ImagePath,
                CategoryId = productToBeAdded.CategoryId,
                CategoryName = productToBeAdded.Category == null ? "Kategorisi yok" : productToBeAdded.Category.CategoryName
            };

            c.AddToCart(ci);

            SetCartForSession(c);
            TempData["Message"] = $"{ci.ProductName} isimli ürün sepete eklenmiştir";
            return RedirectToAction("Index");

        }

        public IActionResult CartPage()
        {
            if (GetCartFromSession("scart") == null)
            {
                TempData["Message"] = "Sepetiniz su anda bos";
                return RedirectToAction("Index");
            }
            Cart c = GetCartFromSession("scart");
            return View(c);
        }


        //ToDo : Refaktor edilmesi lazim. Benzer kodlar var.
        public IActionResult RemoveFromCart(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.RemoveFromCart(id);
                SetCartForSession(c);
                ControlCart(c);
            }

            return RedirectToAction("CartPage");
        }

        public IActionResult DecreaseFromCart(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.Decrease(id);
                SetCartForSession(c);
                ControlCart(c);
            }
            return RedirectToAction("CartPage");
        }

        public IActionResult IncreaseCartItem(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.IncreaseCartItem(id);
                SetCartForSession(c);
                ControlCart(c);
            }
            return RedirectToAction("CartPage");
        }

        public IActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(OrderRequestPageVm ovm)
        {
            Cart c = GetCartFromSession("scart");
            ovm.Order.Price = c.TotalPrice;
            #region APIBankEntegrasyonu

            #endregion

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ovm.Order.AppUserId = appUser.Id;
            }

            await _orderManager.CreateAsync(ovm.Order);

            foreach (CartItem item in c.GetCartItems)
            {
                OrderDetail orderDetail = new();
                orderDetail.OrderId = ovm.Order.Id;
                orderDetail.ProductId = item.Id;
                orderDetail.Amount = item.Amount;
                orderDetail.UnitPrice = item.UnitPrice;

                await _orderDetailManager.CreateAsync(orderDetail);

                //ToDo : Urun stok miktarini azaltma islemi yapilacak. Urun update edilecek.





            }

            TempData["Message"] = "Siparisiniz alinmistir. Teşekkür ederiz.";
            HttpContext.Session.Remove("scart"); //Sepeti bosaltma islemi yapildi.
            return RedirectToAction("Index");
        }
    }
}
