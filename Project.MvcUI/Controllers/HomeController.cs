using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Entities.Models;
using Project.MvcUI.Models;
using Project.MvcUI.Models.PureVms.AppUsers;
using System.Diagnostics;
using Project.Common.Tools;
using System.Threading.Tasks;
using Project.Bll.Managers.Abstracts;

namespace Project.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly IAppUserRoleManager appUserRoleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IAppUserRoleManager appUserRoleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.appUserRoleManager = appUserRoleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region RegisterAction

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel item)
        {
            //TODO : is validse kontrolu yapilacak
            Guid specId = Guid.NewGuid();

            //Mapleme iþlemi
            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                ActivationCode = specId,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, item.Password);

            if (result.Succeeded)
            {

                AppRole appRole = await _roleManager.FindByNameAsync("Member");

                if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Member" });

                AppUserRole appUserRole = new()
                {
                    RoleId = appRole.Id,
                    UserId = appUser.Id
                };

                await appUserRoleManager.CreateAsync(appUserRole);


                string message = $"Hesabiniz olusturulmustur. Uyeliginizi olusturmak icin lutfen http://localhost:5116/Home/ConfirmEmail?specId={specId}&id={appUser.Id} linkine tiklayiniz.";

                MailSender.Send(item.Email, body: message);
                TempData["Message"] = "Lutfen hesabinizi onaylamak icin emailinizi kontrol ediniz.";

                return RedirectToAction("RedirectPanel");
            }
            return View();
        }

        public IActionResult RedirectPanel()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(Guid specId, string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id.ToString());

            if (appUser == null)
            {
                TempData["Message"] = "Kullanici Bulunamadi";
                return RedirectToAction("RedirectPanel");
            }
            else if (appUser.ActivationCode == specId)
            {
                appUser.EmailConfirmed = true;
                await _userManager.UpdateAsync(appUser);
                TempData["Message"] = "Hesabiniz onaylandi. Lutfen giris yapiniz.";
                return RedirectToAction("SignIn");
            }
            return RedirectToAction("Register");
        }

        #endregion

        #region SignInAction

        public IActionResult SignIn()
        {
            return View();
        } 

        #endregion
    }
}
