using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Services.ProductImages;
using Core.Utilities.Results;
using Core.Utilities.Storage;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Enums;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Business.Handlers.Orders.Commands
{
    public class UploadProductImageCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public IFormFileCollection? Files { get; set; }

        public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, IResult>
        {
       
            readonly IProductImageService _productImageService;

            public UploadProductImageCommandHandler(IProductImageService productImageService)
            {         
                _productImageService = productImageService;
            }

            public async Task<IResult> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
            {


                //List<FilePathInfo> result = await _storageService.UploadAsync("photo-images", request.Files);

                await _productImageService.UploadImage(request.Id, request.Files);
                // Product product = await _productReadRepository.GetByIdAsync(request.Id);


                //await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProductImageFile
                //{
                //    FileName = r.fileName,
                //    Path = r.pathOrContainerName,
                //    Storage = _storageService.StorageName,
                //    Products = new List<Domain.Entities.Product>() { product }
                //}).ToList());

                //await _productImageFileWriteRepository.SaveAsync();

                return new SuccessResult();
            }
        }
    }
}

