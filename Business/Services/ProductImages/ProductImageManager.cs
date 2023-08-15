using Core.Utilities.Results;
using Core.Utilities.Storage;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductImages
{
    public class ProductImageManager : ServiceBase, IProductImageService
    {  
        private readonly IStorageService _storageService;

        public ProductImageManager(IServiceProvider serviceProvider, IStorageService storageService) : base(serviceProvider)
        {

            _storageService = storageService;
        }

        public async Task<IResult> UploadImage(Guid productId, IFormFileCollection formFiles)
        {
            List<FilePathInfo> result = await _storageService.UploadAsync("photo-images", formFiles);

            Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == productId);

            foreach (var r in result)
            {
                await _unitOfWork.ProductImageRepository.AddAsync(new()
                {
                    FileName = r.FileName,
                    Path = r.PathOrContainerName,
                    Storage = _storageService.StorageName,
                    Products = new List<Product>() { product }
                });
                await _unitOfWork.Commit();
            }

            return new SuccessResult();
        }
    }
}
