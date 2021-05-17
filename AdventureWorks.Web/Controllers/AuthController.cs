using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.BL.Services;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class AuthController : Controller
    {
        private IAuthenticationManager _authMng;
        private IAuthService _authSrc;
        
        public AuthController(IAuthService authService,
                              IAuthenticationManager authenticationManager)
        {
            _authMng = authenticationManager;
            _authSrc = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await _authSrc.Authenticate(userDTO);
                if(claim == null)
                {
                    ModelState.AddModelError("", "Incorrect password or login");
                }
                else
                {
                    _authMng.SignOut();
                    _authMng.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = "customer"
                };

                OperationDetails operationDetails = await _authSrc.Register(userDTO);
                if(operationDetails.Status == OperationDetails.Statuses.Success)
                {
                    return View("Success");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Status.ToString(), operationDetails.Message);
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            _authMng.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}