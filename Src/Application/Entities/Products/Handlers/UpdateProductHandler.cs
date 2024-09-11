using Application.Entities.Products.Commands;
using Application.Interface.Common;
using AutoMapper;
using MediatR;

namespace Application.Entities.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductHandler( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> Handle( UpdateProduct request, CancellationToken cancellationToken )
        {
            var product =_mapper.Map<Product>(request);
            await _unitOfWork.ProductRepository.UpdateAsync(product, cancellationToken );
            return product;
         
        }
    }
}
