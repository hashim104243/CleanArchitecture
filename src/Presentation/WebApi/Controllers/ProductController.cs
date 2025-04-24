


//using Application.Feature.Product.Query;
using Application.Feature.Product.CreateProduct;
using Application.Feature.Product.Deleteproduct;
using Application.Feature.Product.GetAllProducts;
using Application.Feature.Product.UpdateProduct;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{   
   
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet("GetProducts")]

        public async Task<IActionResult> GetProduct(CancellationToken cancellationToken)
        {

            var data = await mediator.Send(new GetAllProductRequest(), cancellationToken);
            return Ok(data);
        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreatProduct(Product product,CancellationToken cancellationToken)
        {


            var data = await mediator.Send(new CreateProductRequest(product){}, cancellationToken);
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var data=mediator.Send(new DeleteProductRequest() {Id=id });
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var data = mediator.Send(new UpdateProductRequest(product) );
            return Ok(data);
        }

    }
};
