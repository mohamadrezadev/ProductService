using Application.Entities.Products.Queries;
using Application.Interface.Common;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Entities.Products.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductList, List<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductListHandler( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle( GetProductList request, CancellationToken cancellationToken )
        {
            var res= await _unitOfWork.ProductRepository.Entities.ToListAsync(cancellationToken);
             
            return _mapper.Map<List<ProductDto>>(res); ;
        }
    }
}
