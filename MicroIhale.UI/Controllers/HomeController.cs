using MicroIhale.Core.Entities;
using MicroIhale.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroIhale.UI.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel,string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (result.Succeeded)
                        //return RedirectToAction("Index");
                        return LocalRedirect(returnUrl);
                    else
                        ModelState.AddModelError("", "Email address is not valid Or Password");
                }
                else
                    ModelState.AddModelError("", "Email address is not valid Or Password");
            }
              
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(AddUserViewModel addModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.Email = addModel.Email;
                user.FirstName = addModel.FirstName;
                user.LastName = addModel.LastName;
                user.PhoneNumber = addModel.PhoneNumber;
                user.UserName = addModel.UserName;
                if (addModel.UserSelectTypeId == 1)
                {
                    user.IsBuyer = true;
                    user.IsSeller = false;
                }
                else
                {
                    user.IsSeller = true;
                    user.IsBuyer = false;
                }

                var result =await _userManager.CreateAsync(user,addModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(addModel);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}