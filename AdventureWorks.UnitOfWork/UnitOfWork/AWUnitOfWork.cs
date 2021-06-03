using AdventureWorks.Auth.CustomIdentity;
using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.IdentityManagers;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models.IdentityModels;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.UnitOfWork
{
    public class AWUnitOfWork : IUnitOfWork
    {
        private readonly AWContext _context;
        public AWUnitOfWork(AWContext context)
        {
            _context = context;
            Address = new AddressRepository(context);
            BusinessEntity = new BusinessEntityRepository(context);
            BusinessEntityAddress = new BusinessEntityAddressRepository(context);
            PersonPhone = new PersonPhoneRepository(context);
            StateProvince = new StateProvinceRepository(context);
            Customer = new CustomerRepository(context);
            SalesPerson = new SalesPersonRepository(context);
            SalesOrderHeader = new SalesOrderHeaderRepository(context);
            SalesOrderDetail = new SalesOrderDetailRepository(context);
            ShoppingCartItem = new ShoppingCartItemRepository(context);
            SalesTerritory = new SalesTerritoryRepository(context);
            Product = new ProductRepository(context);
            ProductCategory = new ProductCategoryRepository(context);
            ProductDescription = new ProductDescriptionRepository(context);
            ProductInventory = new ProductInventoryRepository(context);
            ProductListPriceHistory = new ProductListPriceHistoryRepository(context);
            ProductPhoto = new ProductPhotoRepository(context);
            ProductProductPhoto = new ProductProductPhotoRepository(context);
            Person = new PersonRepository(context);
        }

        #region repos property
        public IAddressRepository Address { get; private set; }

        public IBusinessEntityRepository BusinessEntity { get; private set; }

        public IBusinessEntityAddressRepository BusinessEntityAddress { get; private set; }

        public IPersonPhoneRepository PersonPhone { get; private set; }

        public IStateProvinceRepository StateProvince { get; private set; }

        public ICustomerRepository Customer { get; private set; }

        public ISalesPersonRepository SalesPerson { get; private set; }

        public ISalesOrderHeaderRepository SalesOrderHeader { get; private set; }

        public ISalesOrderDetailRepository SalesOrderDetail { get; private set; }

        public IShoppingCartItemRepository ShoppingCartItem { get; private set; }

        public ISalesTerritoryRepository SalesTerritory { get; private set; }

        public IProductRepository Product { get; private set; }

        public IProductCategoryRepository ProductCategory { get; private set; }

        public IProductDescriptionRepository ProductDescription { get; private set; }

        public IProductInventoryRepository ProductInventory { get; private set; }

        public IProductListPriceHistoryRepository ProductListPriceHistory { get; private set; }

        public IProductPhotoRepository ProductPhoto { get; private set; }

        public IProductProductPhotoRepository ProductProductPhoto { get; private set; }
        public IPersonRepository Person { get; private set; }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
