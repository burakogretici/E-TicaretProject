using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class BaseDto : IDto
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
