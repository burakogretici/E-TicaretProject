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
    public class CreateMenuCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Guid? ParentMenuId { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; }
        public bool Hidden { get; set; }
        public bool IsAdmin { get; set; }


        public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, IResult>
        {
            private readonly IMenuService _menuService;
            private readonly IMapper _mapper;
            public CreateMenuCommandHandler(IMenuService menuService, IMapper mapper)
            {
                _menuService = menuService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<MenuDto>(request);
                var menu = await _menuService.AddAsync(mapper);
                return menu;
            }
        }
    }
}
