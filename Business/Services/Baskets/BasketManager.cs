using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Baskets;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Baskets
{
    public class BasketManager : ServiceBase, IBasketService
    {
        public BasketManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {

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
                await _unitOfWork.BasketItemRepository.UpdateAsync(existingItem);
            }
            else
            {
                var newItem = new BasketItem
                {
                    Id = Guid.NewGuid(),
                    BasketId = basketDetailDto.BasketId,
                    ProductId = basketDetailDto.ProductId,
                    Amount = basketDetailDto.Amount,
                    //Price = basketDetailDto.Price,
                };
                basket.Data.BasketItems.Add(newItem);
                // Veritabanına yeni öğe ekleme işlemi

                await _unitOfWork.BasketItemRepository.AddAsync(newItem);

                // Değişiklikleri kaydetme işlemi

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

        public async Task<IResult> RemoveItemFromBasket(Guid basketId, Guid productId)
        {
            var basket = await GetBasket(basketId);
            if (basket == null)
            {
                throw new Exception("Sepet bulunamadı");
            }

            var existingItem = basket.Data.BasketItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem == null)
            {
                throw new Exception("Ürün sepetinizde bulunamadı");
            }

            basket.Data.BasketItems.Remove(existingItem);
            var mapper = _mapper.Map<BasketItem>(existingItem);
            await _unitOfWork.BasketItemRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult("Sepetten Ürün Silindi");
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