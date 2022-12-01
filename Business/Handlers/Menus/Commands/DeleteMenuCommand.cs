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
    public class DeleteMenuCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, IResult>
        {
            private readonly IMenuService _menuService;
            private readonly IMapper _mapper;
            public DeleteMenuCommandHandler(IMenuService menuService, IMapper mapper)
            {
                _menuService = menuService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<MenuDto>(request);
                var menu = await _menuService.DeleteAsync(mapper);
                return menu;

            }
        }
    }
}
