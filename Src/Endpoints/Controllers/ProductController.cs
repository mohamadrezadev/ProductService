using Application.Entities;
using Application.Entities.Products.Commands;
using Application.Entities.Products.Queries;
using Endpoint.Api.Examples;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Endpoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController( IMediator mediator )
        {
            _mediator = mediator;
        }
        [HttpGet(Name ="GetProducts")]
        public async Task<IActionResult> GetProductsAsync( CancellationToken cancellationToken )
        {
            var studentDetails = await _mediator.Send(new GetProductList(),cancellationToken);

            return Ok(studentDetails);
        }
        [HttpPost(Name ="AddOrUpdate")]
        [ProducesResponseType(typeof(ProductCreateDto), 200)]
        [SwaggerRequestExample(typeof(ProductCreateDto), typeof(ProductCreateDtoExample))]
        public async Task<IActionResult> CreateProduct(ProductCreateDto  createProduct,CancellationToken cancellationToken=default )
        {
            var request = new CreateProduct { ProductCreateDto = createProduct };

            var res= await _mediator.Send(request ,cancellationToken);
            return Ok(res);
        }
        
        [HttpGet("GetProduct/{Id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int Id, CancellationToken cancellationToken )
        {
            var request = new GetProductByid () { Id = Id };
            var studentDetails = await _mediator.Send(request,cancellationToken);
       
            return Ok(studentDetails);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProduct deleteProduct,CancellationToken cancellationToken  )
        {
             var res=await _mediator.Send(deleteProduct,cancellationToken);
            return Ok(res);
        }
    }
}
