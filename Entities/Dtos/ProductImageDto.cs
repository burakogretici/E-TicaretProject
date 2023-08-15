using Entities.Concrete;
using Entities.Dtos.Files;
using System.Collections.Generic;


namespace Entities.Dtos
{
    public class ProductImageDto : FileDto
    {
        public bool Showcase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
