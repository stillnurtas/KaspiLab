using AdventureWorks.EF.Contexts;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.Repositories;
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
            Address = new AddressRepository(_context);
            BusinessEntity = new BusinessEntityRepository(_context);
            BusinessEntityAddress = new BusinessEntityAddressRepository(_context);
            PersonPhone = new PersonPhoneRepository(_context);
            StateProvince = new StateProvinceRepository(_context);
            Customer = new CustomerRepository(_context);
            SalesPerson = new SalesPersonRepository(_context);
            SalesOrderHeader = new SalesOrderHeaderRepository(_context);
            SalesOrderDetail = new SalesOrderDetailRepository(_context);
            ShoppingCartItem = new ShoppingCartItemRepository(_context);
            SalesTerritory = new SalesTerritoryRepository(_context);
            Product = new ProductRepository(_context);
            ProductCategory = new ProductCategoryRepository(_context);
            ProductDescription = new ProductDescriptionRepository(_context);
            ProductInventory = new ProductInventoryRepository(_context);
            ProductListPriceHistory = new ProductListPriceHistoryRepository(_context);
            ProductPhoto = new ProductPhotoRepository(_context);
            ProductProductPhoto = new ProductProductPhotoRepository(_context);
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
