using Application.Entities.Products.Queries;
using Application.Interface.Common;
using AutoMapper;
using MediatR;

namespace Application.Entities.Products.Handlers
{
    public class GetProductByidHandler : IRequestHandler<GetProductByid, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByidHandler( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle( GetProductByid request, CancellationToken cancellationToken )
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(cancellationToken, request.Id);
            
            return _mapper.Map<ProductDto>(product);
        }
    }
}
