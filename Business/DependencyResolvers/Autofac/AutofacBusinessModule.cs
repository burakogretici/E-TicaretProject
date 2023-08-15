using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Helpers.Jwt;
using Business.Rules;
using Business.Services;
using Business.Services.Brands;
using Business.Services.Colors;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Product
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<ProductRules>().SingleInstance();

            //ProductImage
            builder.RegisterType<ProductImageRepository>().As<IProductImageRepository>().SingleInstance();
            builder.RegisterType<FileRepository>().As<IFileRepository>().SingleInstance();



            //Basket
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().SingleInstance();
            builder.RegisterType<BasketRules>().SingleInstance();

            //Brand
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>();
            builder.RegisterType<BrandRules>().SingleInstance();

            //Menu
            builder.RegisterType<MenuRepository>().As<IMenuRepository>();
            builder.RegisterType<MenuRules>().SingleInstance();

            //User
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<UserRules>().SingleInstance();

            //Category
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();
            builder.RegisterType<CategoryRules>().SingleInstance();

            //Order
           
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<OrderRules>().SingleInstance();

            //Address
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().SingleInstance();
            builder.RegisterType<AddressRules>().SingleInstance();

            //City
            builder.RegisterType<CityRepository>().As<ICityRepository>().SingleInstance();
            builder.RegisterType<CityRules>().SingleInstance();

            //Country
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().SingleInstance();
            builder.RegisterType<CountryRules>().SingleInstance();          

            //Color
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<ColorRepository>().As<IColorRepository>().SingleInstance();
            builder.RegisterType<ColorRules>().SingleInstance();

            //Supplier
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>().SingleInstance();
            builder.RegisterType<SupplierRules>().SingleInstance();

            //UserOperationClaim
            builder.RegisterType<UserOperationClaimRepository>().As<IUserOperationClaimRepository>().SingleInstance();
            builder.RegisterType<UserOperationClaimRules>().SingleInstance();

            //OperationClaim
            builder.RegisterType<OperationClaimRepository>().As<IOperationClaimRepository>().SingleInstance();
            builder.RegisterType<OperationClaimRules>().SingleInstance();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //Auth
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
