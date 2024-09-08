using Identity.Data;
using Identity.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountsController : Controller
    {
        public ApplicationDbContext Context { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountsController(ApplicationDbContext context , UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            IdentityUser user = new IdentityUser()
            { 
                Email = reg.Email,
                PhoneNumber = reg.Phone,
                UserName = reg.Email
            };

            var result = await UserManager.CreateAsync(user,reg.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(Register));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel payload)
        {
            var result = await SignInManager.PasswordSignInAsync(payload.Email, payload.Password, payload.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index" , "Home");
            }
            return View(payload);
        }
    }
}
