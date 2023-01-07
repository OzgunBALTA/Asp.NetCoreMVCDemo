using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService _authManager;
        RegisterValidator _registerValidator;

        public RegisterController(IAuthService authManager, RegisterValidator registerValidator)
        {
            _authManager = authManager;
            _registerValidator = registerValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserForRegisterDto userForRegisterDto)
        {
            ValidationResult results = _registerValidator.Validate(userForRegisterDto);
            if (results.IsValid)
            {
                var userExist = _authManager.UserExists(userForRegisterDto.Email);
                if (!userExist.Success)
                {
                    return BadRequest(userExist.Message);
                }

                var registerResult = _authManager.Register(userForRegisterDto);
                var result = _authManager.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Blog");
                }
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
    }
}
