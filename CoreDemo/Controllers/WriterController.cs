using Business.Abstract;
using Core.Entities.Concrete;
using CoreDemo.Models;
using CoreDemo.Models.UserForProfile;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        IUserService _userManager;
        IAuthService _authManager;

        public WriterController(IUserService userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authManager = authService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index","Dashboard");
        }
        
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var user = _userManager.GetById(9);
            var result = _userManager.GetUserForUpdate(user);
            return View(result);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(UserForUpdateDto userForUpdateDto)
        {
            userForUpdateDto.UserId = 9;
            userForUpdateDto.Email = "default2@ozgun.com";
            var result = _authManager.UpdateUser(userForUpdateDto);
            if (result.Success)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWriter(UserForCreateModel userForCreateModel)
        {
            var userExists = _authManager.UserExists(userForCreateModel.Email);
            if (!userExists.Success)
            {
                return View(userExists.Message);
            }

            if (userExists.Success)
            {
                UserProfileModel userProfileModel = new UserProfileModel();
                var user = userProfileModel.AddUser(userForCreateModel);
                var result = _authManager.CreateUser(user);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                return View(result.Message);
            }

            return View();
        }
    }
}
