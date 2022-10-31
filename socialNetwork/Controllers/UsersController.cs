using Microsoft.AspNetCore.Mvc;
using socialNetwork.midelware;
using socialNetwork.source.Core.Application.helpers;
using socialNetwork.source.Core.Application.Interfaces.services;
using socialNetwork.source.Core.Application.ViewModel.Users;

namespace socialNetwork.Controllers
{
    public class UsersController : Controller
    {

        private IUsersServices _user;
        private readonly userSessionValidations _userSessionValidations;

        public UsersController(IUsersServices iuser, userSessionValidations us)
        {
            _user = iuser;
            _userSessionValidations = us;
        }

        //logging
        public async Task<IActionResult> logging()
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> logging(UsersLoggingViewModel uvm)
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(uvm);
            }

            UsersViewModel userVm = await _user.Logging(uvm);

            if (userVm != null)
            {
                HttpContext.Session.set<UsersViewModel>("user", userVm);//create session
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "UserName or password wrong");
            }

            return View(uvm);
        }

        //register
        public async Task<IActionResult> UserRegister()
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View("register", new SaveUsersViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(SaveUsersViewModel suvm)
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            //for validate the form
            if (!ModelState.IsValid)
            {
                return View("register", suvm);
            }

            //for validate the user name
            if (!await _user.confirmUsersNickName(suvm))
            {
                ViewBag.validator = true;
                return View("register", suvm);
            }

            await _user.Add(suvm);
            return RedirectToRoute(new { controller = "Users", action = "logging" });
        }
    }
}
