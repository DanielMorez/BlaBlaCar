using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BlaBlaCar.Domain.DB;
using BlaBlaCar.Domain;
using BlaBlaCar.ViewModels.Account;
using BlaBlaCar.Security;

namespace BlaBlaCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RouteDbContext _routeDbContext;

        /// <summary>
        /// Конструктор класса <see cref="AccountController"/>
        /// </summary>
        /// <param name="userManager">Менеджер пользователей</param>
        /// <param name="routeDbContext">Контекст базы данных</param>
        public AccountController(UserManager<User> userManager, RouteDbContext routeDbContext)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _routeDbContext = routeDbContext ?? throw new ArgumentNullException(nameof(routeDbContext));
        }

        /// <summary>
        /// Форма входа в систему
        /// </summary>
        /// <param name="returnUrl">Путь перехода после авторизации</param>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Очистить существующие куки для корректного логина
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// Авторизация в системе
        /// </summary>
        /// <param name="signInManager">Менеджер авторизации</param>
        /// <param name="model">Входные данные с формы</param>
        /// <param name="returnUrl">Путь перехода после авторизации</param>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromServices] SignInManager<User> signInManager, LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(model.Login).Result;
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Проверьте имя пользователя и пароль");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                    return RedirectToLocal(returnUrl);

                if (result.IsLockedOut)
                    return RedirectToAction(nameof(Lockout));

                ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                return View(model);
            }

            return View(model);
        }


        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        [HttpGet]
        public IActionResult RegistrationNewUser()
        {
            return View();
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="model">Данные о новом пользователе</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationNewUserAsync(NewUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_userManager.Users.Any(x => x.UserName.ToLower() == model.UserName.ToLower()))
                ModelState.AddModelError("Username", "Пользователь с таким именем пользователя уже существует!");

            if (_userManager.Users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                ModelState.AddModelError("Email", "Такой email уже используеся в системе");

            if (ModelState.ErrorCount > 0)
                return View(model);

            var profile = new Employee
            {
                FirstName = model.FirstName,
                Surname = model.Surname
            };

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Employee = profile
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            await _userManager.AddToRoleAsync(user, SecurityConstants.CustomerRole);
            _routeDbContext.SaveChanges();

            return RedirectToAction("Index", "Home"); /*"Index", "Blog"*/
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        /// <param name="signInManager">Менеджер авторизации</param>
        [HttpGet]
        public async Task<IActionResult> Logout([FromServices] SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();


            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Возвращение страницы в случае блокировки пользователя
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        /// <summary>
        /// Подтверждение сброса пароля
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        /// Страница запрета доступа
        /// </summary>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}
