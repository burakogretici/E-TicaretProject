using Business.BusinessAspects;
using Business.Constants;
using Business.Services.Products;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Baskets
{
    public class BasketManager : ServiceBase, IBasketService
    {
        private readonly IProductService _productService;
        public BasketManager(IServiceProvider serviceProvider, IProductService productService) : base(serviceProvider)
        {
            _productService = productService;
        }
        public async Task<IDataResult<BasketItemDto>> AddItemToBasket(BasketItemDto basketDetailDto)
        {

            var basket = await GetBasket(basketDetailDto.BasketId);
            if (basket == null)
            {
                throw new Exception("Sepet bulunamadı");
            }


            var existingItem = basket.Data.BasketItems?.FirstOrDefault(item => item.ProductId == basketDetailDto.ProductId);

            if (existingItem != null)
            {
                existingItem.Amount += basketDetailDto.Amount;
                existingItem.Price = existingItem.Price * (decimal)existingItem.Amount;
                await _unitOfWork.BasketItemRepository.UpdateAsync(existingItem);
            }
            else
            {
                var product = await _productService.GetByIdAsync(basketDetailDto.ProductId);

                var newItem = new BasketItem
                {
                    Id = Guid.NewGuid(),
                    BasketId = basketDetailDto.BasketId,
                    ProductId = basketDetailDto.ProductId,
                    Amount = basketDetailDto.Amount,
                    Price = product.Data.UnitPrice,
                };

                basket.Data.BasketItems.Add(newItem);

                await _unitOfWork.BasketItemRepository.AddAsync(newItem);


            }
            await _unitOfWork.Commit();

            return new SuccessDataResult<BasketItemDto>(basketDetailDto, "Sepete Ürün eklendi");

        }

        public async Task<IResult> ClearBasket(Guid basketId)
        {
            var basket = await GetBasket(basketId);
            if (basket == null)
            {
                throw new Exception("Sepet bulunamadı");
            }

            basket.Data.BasketItems.Clear();
            var mapper = _mapper.Map<Basket>(basket);
            await _unitOfWork.BasketRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult("Sepete Silindi");
        }

        public async Task<IDataResult<BasketDto>> CreateBasket(BasketDto basketDto)
        {
            var mapper = _mapper.Map<Basket>(basketDto);
            await _unitOfWork.BasketRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<BasketDto>(basketDto, "Sepet eklendi");
        }

        public async Task<IDataResult<BasketDto>> GetBasket(Guid basketId)
        {
            var result = await _unitOfWork.BasketRepository.GetAsync(br => br.Id == basketId, x => x.Include(x => x.BasketItems));
            if (result == null) throw new BusinessException(Messages.CityNotFound);

            var mapper = _mapper.Map<BasketDto>(result);
            return new SuccessDataResult<BasketDto>(mapper);
        }

        public async Task<IDataResult<BasketDto>> GetBasketByUserId(Guid userId)
        {
            var result = await _unitOfWork.BasketRepository.GetAsync(br => br.UserId == userId);
            //if (result == null) throw new BusinessException("Sepet bulunamadı!");

            var mapper = _mapper.Map<BasketDto>(result);
            return new SuccessDataResult<BasketDto>(mapper);
        }

     
        public async Task<IResult> RemoveItemFromBasket(Guid id)
        {
            var basketItem = await _unitOfWork.BasketItemRepository.GetAsync(br => br.Id == id,x=>x.Include(x=>x.Product));

            var basket = await GetBasket(basketItem.BasketId);
            if (basket == null)
            {
                throw new Exception("Sepet bulunamadı");
            }

            var existingItem = basket.Data.BasketItems.FirstOrDefault(item => item.ProductId == basketItem.ProductId);
            if (existingItem == null)
            {
                throw new Exception("Ürün sepetinizde bulunamadı");
            }

            if (existingItem.Amount > 1)
            {
                existingItem.Amount -= 1;
                existingItem.Price = basketItem.Product.UnitPrice * (decimal)existingItem.Amount; 

                var mapper = _mapper.Map<BasketItem>(existingItem);
                await _unitOfWork.BasketItemRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
            }
            else
            {
                basket.Data.BasketItems.Remove(existingItem);

                await _unitOfWork.BasketItemRepository.DeleteAsync(existingItem);
                await _unitOfWork.Commit();
            }

            return new SuccessResult("Sepetten Ürün Silindi");
        }


        [SecuredOperation("Basket.List,Admin")]
        public async Task<PaginatedResult<BasketListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var includes = new Expression<Func<BasketItem, object>>[]
            {
                x => x.Basket,
                x => x.Product,
                x => x.Basket.User
            };

            var basketItems = await _unitOfWork.BasketItemRepository.GetListForTableSearch(tableGlobalFilter, includes);

            var mapped = _mapper.Map<PaginatedResult<BasketListDto>>(basketItems);
            return mapped;

        }
        public async Task<IResult> UpdateItemInBasket(BasketItemDto basketDetailDto)
        {
            var basket = await GetBasket(basketDetailDto.BasketId);
            if (basket == null)
            {
                throw new Exception("Sepet bulunamadı");
            }

            var existingItem = basket.Data.BasketItems.FirstOrDefault(item => item.ProductId == basketDetailDto.ProductId);
            if (existingItem == null)
            {
                throw new Exception("Ürün sepetinizde bulunamadı");
            }

            var mapper = _mapper.Map<BasketItem>(existingItem);
            await _unitOfWork.BasketItemRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult("Sepetten Güncellendi");

        }

    }
}