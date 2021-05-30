using AdventureWorks.BL.Infrastructure;
using AdventureWorks.Web.AW.BasketService;
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
            return View();
        }

        public async Task<ActionResult> AddProduct(int productId, int quantity = 1)
        {
            OperationDetails result;
            using(BasketServiceClient client = new BasketServiceClient())
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
            }

            return Json(result.Status.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}