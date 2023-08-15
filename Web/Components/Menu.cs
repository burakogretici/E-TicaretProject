using Entities.Dtos.Menus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Components
{
    public class Menu : ViewComponent
    {
        private readonly IHttpClient _httpClient;

        public Menu(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = new List<MenuDto>();
            var menus = await _httpClient.GetAsync<List<MenuDto>>("menus/getall");
            if (menus?.Data != null)
            {
                foreach (var item in menus.Data.Where(a => !a.ParentMenuId.HasValue))
                {
                    var menuDto = await FillChildsAsync(item);
                    menu.Add(menuDto);
                }
            }
            return View(menu);
        }

        private async Task<MenuDto> FillChildsAsync(MenuDto model)
        {
            if (model == null)
                return null;

            int? parentId = model.Id;
            var children = await _httpClient.GetAsync<List<MenuDto>>($"menus/GetAllByParentMenu/{parentId}");
            if (children?.Data != null)
            {
                model.Childs = new List<MenuDto>();
                foreach (var item in children.Data)
                {
                    var childModel = await FillChildsAsync(item);
                    model.Childs.Add(childModel);
                }
            }

            return model;
        }
    }
}

