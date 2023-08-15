using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Menus;
using Core.Utilities.Results;
using Entities.Dtos.Menus;
using MediatR;

namespace Business.Handlers.Menus.Commands
{
    public class UpdateMenuCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public Guid? ParentMenuId { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; }
        public bool Hidden { get; set; }
        public bool IsAdmin { get; set; }


        public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, IResult>
        {
            private readonly IMenuService _menuService;
            private readonly IMapper _mapper;
            public UpdateMenuCommandHandler(IMenuService menuService, IMapper mapper)
            {
                _menuService = menuService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<MenuDto>(request);
                var menu = await _menuService.UpdateAsync(mapper);
                return menu;

            }
        }
    }
}
