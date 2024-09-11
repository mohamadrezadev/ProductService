using MediatR;

namespace Application.Entities.Products.Queries
{
    public class GetProductList:IRequest<List<ProductDto>>
    {
    }
  
}
