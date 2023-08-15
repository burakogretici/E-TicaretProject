using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProductImages
{
    public interface IProductImageService
    {
        public Task<IResult> UploadImage(Guid productId, IFormFileCollection? formFiles);
      
    }
}
