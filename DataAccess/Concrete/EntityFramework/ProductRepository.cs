using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.Products;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductRepository : EfEntityRepositoryBase<Product, EticaretContext>, IProductRepository
    {
        public ProductRepository(EticaretContext context) : base(context)
        {

        }
        public async Task<List<ProductDetailDto>> GetProductDetails()
        {
            var list = await (from p in Context.Products
                              join c in Context.Categories
                                  on p.CategoryId equals c.Id
                              join brand in Context.Brands on p.BrandId equals brand.Id
                              join color in Context.Colors on p.ColorId equals color.Id

                              select new ProductDetailDto
                              {
                                  ProductName = p.Name,
                                  CategoryName = c.Name,
                                  BrandName = brand.Name,
                                  ColorName = color.Name,
                                  UnitPrice = p.UnitPrice
                              }).ToListAsync();
            return list;


        }
    }


}
