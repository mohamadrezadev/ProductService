using MediatR;

namespace Application.Entities.Products.Commands
{
    public class UpdateProduct:IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string imageURl { get; set; }
        public int Price { get; set; }
    }
}
