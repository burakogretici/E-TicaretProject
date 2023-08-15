using System;
using System.Collections.Generic;

namespace Entities.Dtos.Menus
{
    public class MenuDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? ParentMenuId { get; set; }
        public string ParentMenu { get; set; }
        public string Url { get; set; }
        public bool Hidden { get; set; }
        public bool IsAdmin { get; set; }

        public int DisplayOrder { get; set; }

        public List<MenuDto> Childs { get; set; }
    }
}
