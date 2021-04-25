using System;
using System.Collections.Generic;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.Products;
using KaspiWareHouse.Models.Employees;
using System.Linq;
using NLog;

namespace KaspiWareHouse.Models.WareHouse
{
    public abstract class BaseWareHouse
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        public Address Address { get; private set; }
        public float Square { get; private set; }
        public Employee ResponsibleEmployee { get; private set; }
        public List<BaseProduct> ProductList { get; private set; }

        protected event Action<BaseWareHouse, WareHouseEventArgs> OnCorrectProduct;

        public BaseWareHouse()
        {
            Address = new Address();
            ProductList = new List<BaseProduct>();
        }

        public BaseProduct FindProductBySku(string sku)
        {
            return this.ProductList.Find(pl => pl.SKU == sku);
        }

        public void TotalSum(out decimal totalSum)
        {
            totalSum = 0;
            try
            {
                totalSum = this.ProductList.Sum(a => (decimal)a.Quantity * a.Price);
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        public void SetResponsible(Employee employee)
        {
            try
            {
                ResponsibleEmployee = employee;
            }
            catch(Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        public void TransferProduct(BaseProduct product, BaseWareHouse wareHouse, float quantity)
        {
            try
            {
                var sku = SKUHelper.CreateSKU(product);
                var productIn = this.ProductList.Find(f => f.SKU == sku);
                if (productIn.Quantity >= quantity)
                {
                    productIn.Quantity += quantity;
                    wareHouse.ProductList.Find(pl => pl.SKU == sku).Quantity -= quantity;
                    logger.Debug($"{product.Name} transferred successfully !");
                }
                else logger.Debug($"{product.Name} is less than available in warehouse !");
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        protected void RaiseEvent(BaseProduct product)
        {
            OnCorrectProduct?.Invoke(this, new WareHouseEventArgs(product, OnCorrectProduct.Method.Name));
        }

        public abstract void SubscribeToEvent();
        public abstract void AddProduct(BaseProduct product);
    }
}