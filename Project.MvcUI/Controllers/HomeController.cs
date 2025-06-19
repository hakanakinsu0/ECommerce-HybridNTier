using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Entities.Models;
using Project.MvcUI.Models;
using Project.MvcUI.Models.PureVms.AppUsers;
using System.Diagnostics;
using Project.Common.Tools;
using System.Threading.Tasks;
using Project.Bll.Managers.Abstracts;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Project.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly IAppUserRoleManager _appUserRoleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IAppUserRoleManager appUserRoleManager)
        {

            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appUserRoleManager = appUserRoleManager;
        }

        #region HomeControllerAutomaticActions

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region IndexAction

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region RegisterAction

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            Guid specId = Guid.NewGuid();

            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                ActivationCode = specId,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, item.Password);

            if (result.Succeeded)
            {

                if (!await _roleManager.RoleExistsAsync("Member")) await _roleManager.CreateAsync(new() { Name = "Member" });

                AppRole appRole = await _roleManager.FindByNameAsync("Member");

                AppUserRole appUserRole = new()
                {
                    RoleId = appRole.Id,
                    UserId = appUser.Id
                };

                await _appUserRoleManager.CreateAsync(appUserRole);

                string message = $@"
                Merhaba {item.UserName},<br/><br/>
                Hesabýnýz baþarýyla oluþturuldu. Aktifleþtirmek için lütfen aþaðýdaki linke týklayýn:<br/><br/>
                <a href=""http://localhost:5116/Home/ConfirmEmail?specId={specId}&id={appUser.Id}"">Hesabý Onayla</a><br/><br/>
                Teþekkürler.";

                MailSender.Send(receiver: item.Email, body: message, subject: "Hesap Aktivasyon");

                TempData["Message"] = "Lutfen hesabinizi onaylamak icin emailinizi kontrol ediniz.";

                return RedirectToAction("RedirectPanel");
            }
            foreach (IdentityError err in result.Errors) ModelState.AddModelError(string.Empty, err.Description);

            return View(item);
        }

        public IActionResult RedirectPanel()
        {
            return View();
        }

        #endregion

        #region ConfirmEmailAction

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

        [HttpPost]
        public async Task<IActionResult> SignIn(UserRegisterRequestModel model)
        {
            AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, model.Password, true, true);

            if (result.Succeeded)
            {
                IList<string> roles = await _userManager.GetRolesAsync(appUser);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
                }

                else if (roles.Contains("Member"))
                {
                    return RedirectToAction("Privacy");
                }
                return RedirectToAction("Index");
            }

            else if (result.IsNotAllowed)
            {
                return RedirectToAction("MailPanel");
            }
            TempData["Message"] = "Kullanici bulunamadi";
            return RedirectToAction("SignIn");
        }

        public IActionResult MailPanel()
        {
            return View();
        }

        #endregion
    }
}
