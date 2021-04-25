using KaspiWareHouse.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Models.WareHouse;
using System.Threading.Tasks;

namespace KaspiWareHouse.Helpers
{
    class ReportHelper
    {
        public static async Task<List<BaseProduct>> GetSortedProducts(BaseWareHouse target)
        {
            List<BaseProduct> sortedProducts = new List<BaseProduct>();
            await Task.Run(() => {
                sortedProducts = target.ProductList.Where(pl => pl.Quantity < 3).OrderBy(d => d.Quantity).ToList();
            });
            return sortedProducts;
        }

        public static async Task<List<BaseProduct>> GetUniqueProducts(BaseWareHouse target)
        {
            List<BaseProduct> uniqueProducts = new List<BaseProduct>();
            await Task.Run(() => {
                uniqueProducts = target.ProductList.Distinct().ToList();
            });
            return uniqueProducts;
        }

        public static async Task<List<BaseProduct>> GetGreatestNumberProducts(BaseWareHouse target)
        {
            List<BaseProduct> greatestNumberProducts = new List<BaseProduct>();
            await Task.Run(() => { 
                greatestNumberProducts = target.ProductList.OrderByDescending(pl => pl.Quantity).Take(3).ToList();
            });
            return greatestNumberProducts;
        }

        public static async Task<List<BaseWareHouse>> GetFilteredWareHouses(List<BaseWareHouse> target)
        {
            List<BaseWareHouse> filteredWareHouses = new List<BaseWareHouse>();
            await Task.Run(() => {
                filteredWareHouses = target.Where(t => t is ClosedWareHouse).ToList();
            });
            return filteredWareHouses;
        }

        public static async Task<float> GetAverageNumberOfProducts(List<BaseWareHouse> target)
        {
            float averageNumberOfProducts = 0;
            await Task.Run(() => { 
                averageNumberOfProducts = target.Average(bwh => bwh.ProductList.Average(n => n.Quantity));
            });
            return averageNumberOfProducts;
        }

        public static void ReportsInParallel(BaseWareHouse target)
        {
            Parallel.Invoke(async () => {
                await GetSortedProducts(target);
                await GetUniqueProducts(target);
                await GetGreatestNumberProducts(target);
            });
        }
    }
}
