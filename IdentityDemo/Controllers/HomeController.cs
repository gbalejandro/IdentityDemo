﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace IdentityDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                var user = await userManager.GetUserAsync(HttpContext.User);
                //await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("CategoriaEmpleado", "4"));
                var claims = User.Claims.ToList();
            }

            return View();
        }

        public async Task<IActionResult> About()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    await roleManager.CreateAsync(new IdentityRole("Admin"));
            //    var user = await userManager.GetUserAsync(HttpContext.User);
            //    await userManager.AddToRoleAsync(user, "Admin");
            //}

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //[Authorize(Roles = "Admin")]
        [Authorize(Policy = "PolicyCategoriaEmpleado")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
