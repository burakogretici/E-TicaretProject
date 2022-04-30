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
        IBasketDetailRepository BasketDetailRepository { get; }
        IBasketRepository BasketRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        IColorRepository ColorRepository { get; }
        ICityRepository  CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IOperationClaimRepository OperationClaimRepository { get; }

        Task Commit();
    }
}
