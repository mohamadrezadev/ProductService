using MediatR;

namespace Application.Entities.Products.Queries
{
    public class GetProductByid :IRequest<ProductDto>
    {
        public int Id { get; set; }
    }

   
}
