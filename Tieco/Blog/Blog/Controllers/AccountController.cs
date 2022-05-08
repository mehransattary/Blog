using Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;

        }


        #region //============Register==============//
        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Register")]
        public async Task< IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
               var result=await  accountService.RegisterAsync(registerViewModel , new Claim("value_admin_role", "admin_all_level"));
                

                if (result.Succeeded)
                {
                    return Redirect("/login"); 
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,item.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
        #endregion

        #region //============Login=================//

        [HttpGet("/login")]
        [HttpGet("Account/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string returnUrl=null)
        {
            if(ModelState.IsValid)
            {
                ViewData["returnUrl"] = returnUrl;
                var result =await accountService.SignAsync(loginViewModel);
                if(result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/Admin_Blog/Default/index");
                }
                ModelState.AddModelError(string.Empty, "ورود ناموفق");
            }
            return View(loginViewModel);
        }
        #endregion

        #region //============LogOut================//


        public async Task<IActionResult> LogOut()
        {
            await accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region //============AccessDenied==========//

        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

    }
}
