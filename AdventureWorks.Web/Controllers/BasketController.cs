using AdventureWorks.BL.Infrastructure;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.Web.AW.BasketService;
using AdventureWorks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class BasketController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<BasketViewModel>();
            var basketItems = (BasketDTO)Session["BasketItems"];
            basketItems?.Basket.ForEach(b =>
            {
                model.Add(new BasketViewModel
                {
                    ProductID = b.ProductID,
                    ProductName = b.ProductName,
                    Price = b.ProductPrice,
                    Quantity = b.Quantity,
                    TotalPrice = b.TotalPrice
                });
            });
            ViewBag.TotalPrice = basketItems?.BasketPrice;
            return View(model);
        }

        public async Task<ActionResult> AddProduct(int productId, int quantity = 1)
        {
            OperationDetails result;

            using (BasketServiceClient client = new BasketServiceClient())
            {
                string basketId;
                if ((string)Session["BasketID"] == null)
                {
                    basketId = await Task.Run(() => client.GenerateBasketId());
                    Session["BasketID"] = basketId;
                }
                else
                {
                    basketId = (string)Session["BasketID"];
                }

                result = await Task.Run(() => client.AddProduct(basketId, productId, quantity));
                if(result.Status == OperationDetails.Statuses.Success)
                {
                    Session["BasketItems"] = await Task.Run(() => client.GetBasketItems(basketId));
                }
            }

            return Json(result.Status.ToString(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> RemoveProduct(int productId, int quantity = 1)
        {
            OperationDetails result;
            var basketId = (string)Session["BasketID"];
            using (BasketServiceClient client = new BasketServiceClient())
            {
                result = await Task.Run(() => client.RemoveProduct(basketId, productId, quantity));

                if (result.Status == OperationDetails.Statuses.Success)
                {
                    Session["BasketItems"] = await Task.Run(() => client.GetBasketItems(basketId));
                }
            }

            return Json(result.Status.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}