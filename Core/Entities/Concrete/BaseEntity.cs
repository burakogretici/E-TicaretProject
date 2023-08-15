using System;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public abstract class BaseEntity : BaseEntity<Guid> { }
    public abstract class BaseEntity<T> : IEntity
    {
        public virtual T Id { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }

    }
}
