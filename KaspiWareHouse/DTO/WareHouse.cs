﻿using System;
using System.Collections.Generic;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.DTO.Products;
using System.Linq;

namespace KaspiWareHouse.DTO
{
    public abstract class WareHouse
    {
        public Address Address { get; private set; }
        public float Square { get; private set; }
        public Employee ResponsibleEmployee { get; private set; }
        public List<Product> ProductList { get; private set; }

        public WareHouse()
        {
            Address = new Address();
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
                this.ResponsibleEmployee = employee;
            }
            catch(Exception e)
            {
                message = e.Message;
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
        public abstract void AddProduct(Product product, out string message);
    }
}