using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Abstract.AddressService;
using Business.Abstract.OrderService;
using Business.Abstract.UserService;
using Business.Concrete;
using Business.Concrete.AddressManager;
using Business.Concrete.OrderManager;
using Business.Concrete.UserManager;
using Business.Helpers.Jwt;
using Business.Rules;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Abstract.AddressDal;
using DataAccess.Abstract.OrderDal;
using DataAccess.Abstract.UserDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.EfAddressDal;
using DataAccess.Concrete.EntityFramework.EfOrderDal;
using DataAccess.Concrete.EntityFramework.EfUserDal;
using Entities.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Product
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<ProductRules>().SingleInstance();
            
            //Basket
            builder.RegisterType<BasketManager>().As<IBasketService>().SingleInstance();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>().SingleInstance();
            builder.RegisterType<BasketRules>().SingleInstance();

            //Brand
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<BrandRules>().SingleInstance();

            //User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserRules>().SingleInstance();

            //Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CategoryRules>().SingleInstance();

            //Order
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<OrderRules>().SingleInstance();

            //Address
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();
            builder.RegisterType<AddressRules>().SingleInstance();

            //City
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<CityRules>().SingleInstance();

            //Country
            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
            builder.RegisterType<CountryRules>().SingleInstance();

            //OrderDetail
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();
            builder.RegisterType<OrderDetailRules>().SingleInstance();

            //Customer
            builder.RegisterType<CustomerManager>(typeof()).As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<CustomerRules>().SingleInstance();

            //Color
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<ColorRules>().SingleInstance();

            //Supplier
            builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
            builder.RegisterType<EfSupplierDal>().As<ISupplierDal>().SingleInstance();
            builder.RegisterType<SupplierRules>().SingleInstance();

            //OrderStatus
            builder.RegisterType<OrderStatusManager>().As<IOrderStatusService>().SingleInstance();
            builder.RegisterType<EfOrderStatusDal>().As<IOrderStatusDal>().SingleInstance();
            builder.RegisterType<OrderRules>().SingleInstance();

            //UserOperationClaim
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();
            builder.RegisterType<UserOperationClaimRules>().SingleInstance();

            //OperationClaim
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();
            builder.RegisterType<OperationClaimRules>().SingleInstance();

            //Auth
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
         
         
            


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
