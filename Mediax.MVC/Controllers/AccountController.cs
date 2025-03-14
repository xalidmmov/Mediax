﻿using Mediax.BL.ViewModels.Auths;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mediax.BL.Extensions;
using Mediax.Core.Enums;
namespace Mediax.MVC.Controllers
{
    public class AccountController(MediaxDbContext _context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Username ve ya password sehdir");
            }
            var result = await signInManager.PasswordSignInAsync(user!, vm.Password, vm.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("UserName", "username ve ya password sefdir");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (await _context.Users.AnyAsync(x => x.UserName == vm.UserName))
            {
                ModelState.AddModelError("UserName", "Username or password is wrong");
            }
            User user = new()
            { 
                UserName = vm.UserName,
                Email = vm.UserName,
                FullName = vm.FullName,
            };
            await userManager.CreateAsync(user, vm.Password);
            //var roleResult = await userManager.AddToRoleAsync(user, nameof(Roles.User));
            //if (!roleResult.Succeeded)
            //{
            //    return View();
            //}
            return RedirectToAction(nameof(Login));

        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
