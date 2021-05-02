using AdventureWorks.BL.Core;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController()
        {
            _product = new Product();
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = new List<SCProductsViewModel>();
            var scProductsBL = _product.GetShowCaseProducts(3, 10);
            foreach(var product in scProductsBL)
            {
                model.Add(new SCProductsViewModel() { Name = product.Name, Image = product.Image });
            }
            return View(model);
        }
    }
}