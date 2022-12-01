using System;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EticaretContext _eticaretContext;
        public UnitOfWork(EticaretContext eticaretContext) => _eticaretContext = eticaretContext;


        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_eticaretContext);
                }
                return _userRepository;
            }
        }

        private IAddressRepository _addressRepository;
        public IAddressRepository AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    _addressRepository = new AddressRepository(_eticaretContext);
                }
                return _addressRepository;
            }
        }

        private IUserOperationClaimRepository _userOperationClaimRepository;
        public IUserOperationClaimRepository UserOperationClaimRepository
        {
            get
            {
                if (_userOperationClaimRepository == null)
                {
                    _userOperationClaimRepository = new UserOperationClaimRepository(_eticaretContext);
                }
                return _userOperationClaimRepository;
            }
        }

        private IBasketDetailRepository _basketDetailRepository;
        public IBasketDetailRepository BasketDetailRepository
        {
            get
            {
                if (_basketDetailRepository == null)
                {
                    _basketDetailRepository = new BasketDetailRepository(_eticaretContext);
                }
                return _basketDetailRepository;
            }
        }

        private IBasketRepository _basketRepository;
        public IBasketRepository BasketRepository
        {
            get
            {
                if (_basketRepository == null)
                {
                    _basketRepository = new BasketRepository(_eticaretContext);
                }
                return _basketRepository;
            }
        }

        private IBrandRepository _brandRepository;
        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_eticaretContext);
                }
                return _brandRepository;
            }
        }

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_eticaretContext);
                }
                return _categoryRepository;
            }
        }

        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_eticaretContext);
                }
                return _customerRepository;
            }
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_eticaretContext);
                }
                return _productRepository;
            }
        }

        private IColorRepository _colorRepository;
        public IColorRepository ColorRepository
        {
            get
            {
                if (_colorRepository == null)
                {
                    _colorRepository = new ColorRepository(_eticaretContext);
                }
                return _colorRepository;
            }
        }

        private ICityRepository _cityRepository;
        public ICityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null)
                {
                    _cityRepository = new CityRepository(_eticaretContext);
                }
                return _cityRepository;
            }
        }

        private ICountryRepository _countryRepository;
        public ICountryRepository CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                {
                    _countryRepository = new CountryRepository(_eticaretContext);
                }
                return _countryRepository;
            }
        }

        private IOrderDetailRepository _orderDetailRepository;
        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                if (_orderDetailRepository == null)
                {
                    _orderDetailRepository = new OrderDetailRepository(_eticaretContext);
                }
                return _orderDetailRepository;
            }
        }

        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_eticaretContext);
                }
                return _orderRepository;
            }
        }

        private ISupplierRepository _supplierRepository;
        public ISupplierRepository SupplierRepository
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new SupplierRepository(_eticaretContext);
                }
                return _supplierRepository;
            }
        }

        private IOperationClaimRepository _operationClaimRepository;
        public IOperationClaimRepository OperationClaimRepository
        {
            get
            {
                if (_operationClaimRepository == null)
                {
                    _operationClaimRepository = new OperationClaimRepository(_eticaretContext);
                }
                return _operationClaimRepository;
            }
        }
        private IMenuRepository _menuRepository;
        public IMenuRepository MenuRepository
        {
            get
            {
                if (_menuRepository == null)
                {
                    _menuRepository = new MenuRepository(_eticaretContext);
                }
                return _menuRepository;
            }
        }

        public async Task Commit() => await _eticaretContext.SaveChangesAsync();



        private bool isDisposed = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
            }
        }
        protected async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _eticaretContext.DisposeAsync();
            }
        }
    }
}
