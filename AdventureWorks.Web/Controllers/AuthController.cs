﻿using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.Web.AW.AuthService;
using AdventureWorks.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
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
        private IAuthenticationManager AuthMng { get { return HttpContext.GetOwinContext().Authentication; } }


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
                using (AuthServiceClient client = new AuthServiceClient())
                {
                    UserDTO userDTO = new UserDTO { Email = model.Email, Password = model.Password };
                    ClaimsIdentity claim = await Task.Run(() => client.Authenticate(userDTO));
                    if (claim == null)
                    {
                        ModelState.AddModelError("", "Incorrect password or login");
                    }
                    else
                    {
                        AuthMng.SignOut();
                        AuthMng.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);

                        return RedirectToAction("Index", "Home");
                    }
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
                using(AuthServiceClient client = new AuthServiceClient())
                {
                    RegisDTO regisDTO = new RegisDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Role = "customer",
                        Address = model.Address,
                        City = model.City,
                        PostalCode = model.PostalCode,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        StateProvinceID = model.State
                    };
                    OperationDetails operationDetails = await Task.Run(() => client.Register(regisDTO));
                    if (operationDetails.Status == OperationDetails.Statuses.Success)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(operationDetails.Status.ToString(), operationDetails.Message);
                    }
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            using (AuthServiceClient client = new AuthServiceClient())
            {
                var res = await Task.Run(() => client.GetRegisInfo());
                res.Provinces.ForEach(p => model.States.Add(new SelectListItem { Text = p.Name, Value = Convert.ToString(p.Id) }));
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthMng.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}