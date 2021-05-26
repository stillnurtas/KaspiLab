using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class BasketController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}