using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Menus;
using Core.Utilities.Results;
using Entities.Dtos.Menus;
using MediatR;

namespace Business.Handlers.Menus.Queries
{
    public class GetMenuQuery : IRequest<IDataResult<MenuDto>>
    {
        public int Id { get; set; }

        public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, IDataResult<MenuDto>>
        {
            private readonly IMenuService _menuService;

            public GetMenuQueryHandler(IMenuService menuService)
            {
                _menuService = menuService;
            }
            public async Task<IDataResult<MenuDto>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
            {
                var menu = await _menuService.GetByIdAsync(request.Id);
                return menu;
            }
        }
    }
}
