using Application.Utils;
using MediatR;

namespace Application.Entities.Products.Commands
{
    public class CreateProduct:IRequest<DefaultResult<ProductDto>>
    {
        public ProductCreateDto ProductCreateDto { get; set; }
    }
}
