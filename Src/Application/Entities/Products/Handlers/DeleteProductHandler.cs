using Application.Entities.Products.Commands;
using Application.Interface.Common;
using AutoMapper;
using MediatR;

namespace Application.Entities.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductHandler( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle( DeleteProduct request, CancellationToken cancellationToken )
        {
           var product= await _unitOfWork.ProductRepository.GetByIdAsync(cancellationToken,request.Id);
            if( product is not null )
            {
                await _unitOfWork.ProductRepository.DeleteAsync(product, cancellationToken);
                return true;
            }
            return false;
        }
    }
}
