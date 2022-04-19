using Comp.ProductManagement.Application.DTOs.Product;
using Comp.ProductManagement.Application.Features.Product.Requests.Commands;
using Comp.ProductManagement.Application.Features.Product.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comp.ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns a list of products
        /// </summary>
        /// <returns>A list of products</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET: api/products
        ///     
        /// </remarks>
        /// <response code="200">Products are succesfully returned </response>
        /// <response code="400">Unexpected error</response>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var products = await _mediator.Send(new GetProductListRequest());
            return Ok(products);
        }

        /// <summary>
        /// Returns a  product
        /// </summary>
        /// <returns>A product</returns>
        /// <param name="id">The id of the product</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET: api/products/1
        ///     
        /// </remarks>
        /// <response code="200">Product is succesfully returned </response>
        /// <response code="400">Unexpected error</response>
        /// <response code="404">Product not found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetProductDetailsRequest { Id = id });
            return Ok(leaveType);
        }

        /// <summary>
        /// Create of products
        /// </summary>
        /// <returns>The new product</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST: api/products
        ///     
        /// </remarks>
        /// <response code="200">Product was succesfully created </response>
        /// <response code="400">Unexpected error</response>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductDto product)
        {
            var command = new CreateProductCommand {ProductDto  = product };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        /// <summary>
        /// Update a  product
        /// </summary>
        /// <param name="product">The product</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT: api/products/1
        ///     
        /// </remarks>
        /// <response code="200">Product is succesfully updated </response>
        /// <response code="400">Unexpected error</response>
        /// <response code="404">Product not found</response>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateProductDto product)
        {
            var command = new UpdateProductCommand { ProductDto = product };
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete a  product
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE: api/products/1
        ///     
        /// </remarks>
        /// <response code="200">Product is succesfully deleted </response>
        /// <response code="400">Unexpected error</response>
        /// <response code="404">Product not found</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
