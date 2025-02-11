using CarStore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("role/set-role")]
        public async Task<IActionResult> SetRole()
        {
            List<string> roles = Enum.GetNames(typeof(Roles)).ToList();
            List<string?> users = await _userManager.Users.Select(u => u.UserName).ToListAsync();

            SetUserRoleViewModel model = new SetUserRoleViewModel
            {
                Roles = roles,
                Users = users
            };

            return View(model);
        }

        [HttpPost]
        [Route("role/set-role")]
        public async Task<IActionResult> SetRole(string role, string user)
        {
            IdentityUser? identityUser = await _userManager.FindByNameAsync(user);

            if (identityUser == null)
            {
                return BadRequest();
            }

            try
            {
                bool ifAdminExists = await _userManager.GetUsersInRoleAsync(nameof(Roles.Admin)) != null;
                if(ifAdminExists)
                {
                    return View("Admin exists");
                }

                bool roleExists = await _roleManager.RoleExistsAsync(role);
                if(!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                await _userManager.AddToRoleAsync(identityUser, role);
                return RedirectToAction(actionName:"Index", controllerName:"Home");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}