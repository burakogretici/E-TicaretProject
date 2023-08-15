using AutoMapper;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Business.Services
{
    public interface IServiceBase
    {
    }

    public class ServiceBase : IServiceBase
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ServiceBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
            _mapper = _serviceProvider.GetService<IMapper>();
        }
    }
}
