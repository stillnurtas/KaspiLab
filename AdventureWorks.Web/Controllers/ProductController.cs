using AdventureWorks.BL.Services;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var model = new List<SCProductsViewModel>();
            var scProductsBL = await _productService.GetShowCaseProductList();

            scProductsBL.ToList().ForEach(p =>
            {
                model.Add(new SCProductsViewModel() { Name = p.Name, Image = p.Image });
            });

            return View(model);
        }
    }
}