using AdventureWorks.BL.Services;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using AdventureWorks.Repository.Interfaces;

namespace AdventureWorks.Web.Controllers
{
    public class ShowCaseController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICacheManager _cacheManager;

        public ShowCaseController(IProductService productService,
                                  ICacheManager cacheManager)
        {
            _productService = productService;
            _cacheManager = cacheManager;
        }

        public async Task<ActionResult> Index()
        {
            var model = new List<SCProductsViewModel>();
            var scProductsBL = await _productService.GetProducts(1, 24);

            scProductsBL.ToList().ForEach(p => model.Add(new SCProductsViewModel() { Id = p.Id, Name = p.Name }));

            return View(model);
        }

        public async Task<ActionResult> GetImage(int productId)
        {
            var imageData = (byte[])_cacheManager.Get($"product_image_{productId}");
            
            if(imageData == null)
            {
                imageData = await _productService.GetImage(productId);
                _cacheManager.Set($"product_image_{productId}", imageData);
            }
            
            return File(imageData, "image/gif");
        }

        public async Task<JsonResult> GetProducts(int currentIndex)
        {
            var model = new List<SCProductsViewModel>();
            var scProductsBL = await _productService.GetProducts(currentIndex, 24);

            scProductsBL.ToList().ForEach(p => model.Add(new SCProductsViewModel() { Id = p.Id, Name = p.Name }));

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetDetails(int productId)
        {
            var model = new SCProductsViewModel();
            var prodDetails = await _productService.GetDetails(productId);
            return View(prodDetails);
        }
    }
}