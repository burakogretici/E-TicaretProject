using System;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUserRepository UserRepository { get; }
        IAddressRepository AddressRepository { get; }
        IUserOperationClaimRepository UserOperationClaimRepository { get; }
        IBasketItemRepository BasketItemRepository { get; }
        IBasketRepository BasketRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IColorRepository ColorRepository { get; }
        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        IOrderRepository OrderRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IOperationClaimRepository OperationClaimRepository { get; }
        IMenuRepository MenuRepository { get; }
        ILogRepository LogRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IShipperRepository ShipperRepository { get; }



        Task Commit();
    }
}
