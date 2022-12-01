using Entities.Dtos.Menus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Areas.Components
{
    public class Menu : ViewComponent
    {

        private readonly IApiHelper _apiHelper;

        public Menu(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public IViewComponentResult Invoke()
        {
            var menu = new List<MenuDto>();
            var menus =  _apiHelper.Get<MenuDto>("menus/getall").Result.Where(a=>!a.ParentMenuId.HasValue);
            if (menus != null)
            {
                foreach (var item in menus)
                {
                    var menuDto = (MenuDto)item;
                    FillChilds(ref menuDto);
                    menu.Add(menuDto);
                }
            }
            return View(menu);
        }
        private void FillChilds(ref MenuDto model)
        {
            if (model == null)
                return;

            Guid? parentId = model.Id;
            var children = _apiHelper.Get<MenuDto>($"menus/GetAllByParentMenu/{parentId}").Result;
            if (children != null)
            {
                model.Childs = new List<MenuDto>();
                foreach (var item in children)
                {
                    var childModel = (MenuDto)item;

                    FillChilds(ref childModel);
                    model.Childs.Add(childModel);
                }
            }
        }
    }
}
