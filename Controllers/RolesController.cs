using EF_test_01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var listOfUsers = _userManager.Users.ToList();
            //ViewBag.Users = new SelectList(_userManager.Users, "Id", "UserName");
            var listOfRoles = _roleManager.Roles.ToList();
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Id", "Name");           
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConnectUserToRole(string userId, string roleId)
        {
            var _user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(_user, roleId);

            return RedirectToAction("Index");
        }
    }
}
