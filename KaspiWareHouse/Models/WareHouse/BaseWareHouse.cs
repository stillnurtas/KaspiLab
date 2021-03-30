using System;
using System.Collections.Generic;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.Products;
using KaspiWareHouse.Models.Employees;
using System.Linq;

namespace KaspiWareHouse.Models.WareHouse
{
    public abstract class BaseWareHouse
    {
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

        public void TotalSum(out decimal totalSum, out string message)
        {
            totalSum = 0;
            message = String.Empty;
            try
            {
                totalSum = this.ProductList.Sum(a => (decimal)a.Quantity * a.Price);
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }

        public void SetResponsible(Employee employee, out string message)
        {
            message = String.Empty;
            try
            {
                ResponsibleEmployee = employee;
            }
            catch(Exception e)
            {
                message = e.Message;
            }
        }

        public void TransferProduct(BaseProduct product, BaseWareHouse wareHouse, float quantity, out string message)
        {
            message = String.Empty;
            try
            {
                var sku = SKUHelper.CreateSKU(product);
                var productIn = this.ProductList.Find(f => f.SKU == sku);
                if (productIn.Quantity >= quantity)
                {
                    productIn.Quantity += quantity;
                    wareHouse.ProductList.Find(pl => pl.SKU == sku).Quantity -= quantity;
                    message = $"{product.Name} transferred successfully !";
                }
                else message = $"{product.Name} is less than available in warehouse !";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }

        protected void RaiseEvent(BaseProduct product)
        {
            OnCorrectProduct?.Invoke(this, new WareHouseEventArgs(product, OnCorrectProduct.Method.Name));
        }

        public abstract void SubscribeToEvent();
        public abstract void AddProduct(BaseProduct product, out string message);
    }
}