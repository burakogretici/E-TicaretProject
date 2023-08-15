using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Menus;
using Core.Utilities.Results;
using Entities.Dtos.Menus;
using MediatR;

namespace Business.Handlers.Menus.Queries
{
    public class GetParentMenusQuery : IRequest<IDataResult<IEnumerable<MenuDto>>>
    {
        public int Id { get; set; }
        public class GetParentMenusQueryHandler : IRequestHandler<GetParentMenusQuery, IDataResult<IEnumerable<MenuDto>>>
        {
            private readonly IMenuService _menuService;

            public GetParentMenusQueryHandler(IMenuService menuService)
            {
                _menuService = menuService;
            }

            public async Task<IDataResult<IEnumerable<MenuDto>>> Handle(GetParentMenusQuery request, CancellationToken cancellationToken)
            {
                var parentMenuList = await _menuService.GetAllByParentMenuAsync(request.Id);
                return parentMenuList;
            }

        }

    }
}