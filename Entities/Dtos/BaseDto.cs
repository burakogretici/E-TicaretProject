using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class BaseDto : IDto
    {
        public Guid Id { get; set; }
    }
}
