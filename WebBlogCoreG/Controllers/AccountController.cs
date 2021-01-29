using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebBlogCoreG.Helper;
using WebBlogCoreG.Models;

namespace WebBlogCoreG.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _user;
        private string _error;

        public AccountController(IUserService user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var userID = _user.Login(model.EMail, PasswordEncrypter.CreateMD5(model.Password), out _error);

            if (string.IsNullOrEmpty(model.EMail) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.error = "შეავსე ყველა ველი";
                return View();
            }
            else if (userID == null)
            {
                ViewBag.error = _error;
                return View();
            }
            else
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, model.EMail)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel regModel)
        {

            if (string.IsNullOrEmpty(regModel.Email) || string.IsNullOrEmpty(regModel.FirstName) || string.IsNullOrEmpty(regModel.LastName) || string.IsNullOrEmpty(regModel.Password))
            {
                ViewBag.error = "შეავსე ყველა ველი";
                return View();
            }
            else if (regModel.Password.Length < 4)
            {
                ViewBag.error = "პაროლი უნდა აღემატებოდეს 3 სიმბოლოს ";
                return View();
            }
            else if (_user.CheckMail(regModel.Email))
            {
                ViewBag.error = "ესეთი Email უკვე არსებობს";
                return View();
            }
            else
            {
                _user.Add(_user.CreateUser(regModel.FirstName, regModel.LastName, regModel.Email, PasswordEncrypter.CreateMD5(regModel.Password), regModel.Avatar));
                _user.Commit();
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
