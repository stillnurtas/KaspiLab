using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.IdentityManagers;
using AdventureWorks.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region repos
        IAddressRepository Address { get; }
        IBusinessEntityRepository BusinessEntity { get; }
        IBusinessEntityAddressRepository BusinessEntityAddress { get; }
        IPersonPhoneRepository PersonPhone { get; }
        IStateProvinceRepository StateProvince { get; }
        ICustomerRepository Customer { get; }
        ISalesPersonRepository SalesPerson { get; }
        ISalesOrderHeaderRepository SalesOrderHeader { get; }
        ISalesOrderDetailRepository SalesOrderDetail { get; }
        IShoppingCartItemRepository ShoppingCartItem { get; }
        ISalesTerritoryRepository SalesTerritory { get; }
        IProductRepository Product { get; }
        IProductCategoryRepository ProductCategory { get; }
        IProductDescriptionRepository ProductDescription { get; }
        IProductInventoryRepository ProductInventory { get; }
        IProductListPriceHistoryRepository ProductListPriceHistory { get; }
        IProductPhotoRepository ProductPhoto { get; }
        IProductProductPhotoRepository ProductProductPhoto { get; }
        IPersonRepository Person { get; }
        #endregion

        AWContext Context { get; }
        Task<int> Save();
    }
}
