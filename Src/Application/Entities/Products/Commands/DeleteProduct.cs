using MediatR;

namespace Application.Entities.Products.Commands
{
    public class DeleteProduct : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
