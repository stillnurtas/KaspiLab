using System;
using System.Collections.Generic;
using KaspiWareHouse.Helpers;

namespace KaspiWareHouse.DTO
{
    public abstract class WareHouse
    {
        public string Address { get; set; }
        public float Square { get; set; }
        public Employee ResponsibleEmployee { get; set; }
        public List<Product> ProductList { get; set; }

        public WareHouse(string address, float square)
        {
            Address = address;
            Square = square;
            ProductList = new List<Product>();
        }

        public Product FindProductBySku(string sku)
        {
            return this.ProductList.Find(pl => pl.SKU == sku);
        }

        public void TotalSum(out decimal totalSum, out string message)
        {
            totalSum = 0;
            message = String.Empty;
            try
            {
                foreach (var product in this.ProductList)
                {
                    totalSum += (decimal)product.Quantity * product.Price;
                }
            }
            catch (Exception e)
            {
                message = e.ToString();
            }
        }

        public void SetResponsible(Employee employee, out string message)
        {
            message = String.Empty;
            try
            {
                this.ResponsibleEmployee = employee;
            }
            catch(Exception e)
            {
                message = e.ToString();
            }
        }

        public void TransferProduct(Product product, WareHouse wareHouse, float quantity, out string message)
        {
            message = String.Empty;
            try
            {
                var sku = SKUHelper.CreateSKU(product);
                var productIn = this.ProductList.Find(f => f.SKU == sku);
                if (productIn.Quantity >= quantity)
                {
                    productIn.Quantity -= quantity;
                    wareHouse.ProductList.Find(pl => pl.SKU == sku).Quantity += quantity;
                    message = $"{product.Name} transferred successfully !";
                }
                else message = $"{product.name} is less than available in warehouse !";
            }
            catch (Exception e)
            {
                message = e.ToString();
            }
        }
        public abstract void AddProduct(Product product, out string message);
    }
}