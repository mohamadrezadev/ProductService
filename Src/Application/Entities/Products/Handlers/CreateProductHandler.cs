using Application.Entities.Products.Commands;
using Application.Interface.Common;
using Application.Utils;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Products.Handlers
{

    public class CreateProductHandler : IRequestHandler<CreateProduct, DefaultResult<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler( IUnitOfWork unitOfWork,IMapper mapper,ILogger<CreateProductHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public ILogger<CreateProductHandler> _logger { get; set; }

        public async Task<DefaultResult<ProductDto>> Handle( CreateProduct request, CancellationToken cancellationToken )
        {
            var product=_mapper.Map<Product>( request.ProductCreateDto );
            var result=  await _unitOfWork.ProductRepository.AddNewOrUpdate(product);
            
            _logger.Log (logLevel:LogLevel.Information,"Add Or Update Product Succesfuly");
          
            var productDto=_mapper.Map<ProductDto>( result.Data );
           
            return new DefaultResult<ProductDto> ()
            {
                Data = productDto,
                Message = result.Message,
                IsSuccess = result.IsSuccess,
                Errors = result.Errors
            };
        }
    }
}
