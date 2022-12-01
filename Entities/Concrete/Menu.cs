using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Menu : BaseEntity<Guid>
    {
        public Menu()
        {
            Childeren = new HashSet<Menu>();
        }
        public string Name { get; set; }

        public string Icon { get; set; }

        public Guid? ParentMenuId { get; set; }

        public int DisplayOrder { get; set; }

        public string Url { get; set; }
        public bool Hidden { get; set; }

        public virtual Menu ParentMenu { get; set; }
        public virtual ICollection<Menu> Childeren { get; set; }
    }
}
