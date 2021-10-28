using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.WebModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using EasyBookStore.Domain.Common;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace EasyBookStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterWebModel());
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterWebModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                UserName = model.UserName,
            };

            var registerResult = await _userManager.CreateAsync(user, model.Password);
            if (registerResult.Succeeded)
            {
                _logger.LogInformation($"Пользователь {user.UserName} успешно зарегистрирован");
                await _signInManager.SignInAsync(user, false);

                await _userManager.AddToRoleAsync(user, Role.Users);

                return RedirectToAction("Index", "Home");
            }
            var errors = registerResult.Errors.Select(e => IdentityErrorCodes.GetDescription(e.Code));
            foreach (var error in errors)
                ModelState.AddModelError("", error);

            _logger.LogError($"Ошибки при регистрации пользователя {user.UserName} в систему: {string.Join(",", errors)}");
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginWebModel { ReturnUrl = returnUrl });
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginWebModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (loginResult.Succeeded)
            {
                _logger.LogInformation($"Пользователь {model.UserName} успешно вошел в систему");
                return LocalRedirect(model.ReturnUrl ?? "/");
            }

            ModelState.AddModelError("", "Ошибка ввода имени пользователя или пароля");
            _logger.LogError($"Ошибка при входе пользователя {model.UserName}");
            return View(model);
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            _logger.LogError($"Выход пользователя из системы");
            await _signInManager.SignOutAsync();
            return LocalRedirect(returnUrl ?? "/");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            _logger.LogError($"В доступе оказано");
            return View();
        }
    }
}
