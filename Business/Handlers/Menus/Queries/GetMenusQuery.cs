using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Menus;
using Core.Utilities.Results;
using Entities.Dtos.Menus;
using MediatR;


namespace Business.Handlers.Menus.Queries
{
    public class GetMenusQuery : IRequest<IDataResult<IEnumerable<MenuDto>>>
    {
        public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, IDataResult<IEnumerable<MenuDto>>>
        {
            private readonly IMenuService _menuService;

            public GetMenusQueryHandler(IMenuService menuService)
            {
                _menuService = menuService;
            }

            public async Task<IDataResult<IEnumerable<MenuDto>>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
            {
                var menuList = await _menuService.GetAllAsync();
                return menuList;
            }

        }
    }
}
