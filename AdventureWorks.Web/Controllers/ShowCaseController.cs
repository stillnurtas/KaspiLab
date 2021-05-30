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
using AdventureWorks.BL.Infrastructure.Enums;

namespace AdventureWorks.Web.Controllers
{
    public class ShowCaseController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetSCImage(int productId)
        {
            byte[] imageData;
            using (var serviceClient = new ProductServiceClient())
            {
                imageData = await Task.Run(() => serviceClient.GetImage(productId, ImageType.Nail));
            }
            
            return File(imageData, "image/gif");
        }

        public async Task<ActionResult> GetDetailImage(int productId)
        {
            byte[] imageData;
            using (var serviceClient = new ProductServiceClient())
            {
                imageData = await Task.Run(() => serviceClient.GetImage(productId, ImageType.Large));
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