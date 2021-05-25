using AdventureWorks.BL.Interfaces;
using AdventureWorks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Web.AW.ProductService;
using AdventureWorks.DTO.Models.BL;

namespace AdventureWorks.Web.Controllers
{
    public class ShowCaseController : Controller
    {

        public async Task<ActionResult> Index()
        {
            var model = new List<SCProductsViewModel>();
            using (var serviceClient = new ProductServiceClient())
            {
                var scProductsBL = await Task.Run(() => serviceClient.GetProducts(1, 24));
                scProductsBL.ToList().ForEach(p => model.Add(new SCProductsViewModel() { Id = p.Id, Name = p.Name }));
            }

            return View(model);
        }

        public async Task<ActionResult> GetImage(int productId)
        {
            byte[] imageData;
            using (var serviceClient = new ProductServiceClient())
            {
                imageData = await Task.Run(() => serviceClient.GetImage(productId));
            }
            
            return File(imageData, "image/gif");
        }

        public async Task<JsonResult> GetProducts(int currentIndex)
        {
            var model = new List<SCProductsViewModel>();
            using (var serviceClient = new ProductServiceClient())
            {
                var scProductsBL = await Task.Run(() => serviceClient.GetProducts(currentIndex, 24));
                scProductsBL.ToList().ForEach(p => model.Add(new SCProductsViewModel() { Id = p.Id, Name = p.Name }));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetDetails(int productId)
        {
            ProductDetailsDTO model = new ProductDetailsDTO();
            using (var serviceClient = new ProductServiceClient())
            {
                model = await Task.Run(() => serviceClient.GetDetails(productId));
            }

            return View(model);
        }
    }
}