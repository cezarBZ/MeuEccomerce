using MediatR;
using MeuEccomerce.API.Application.Commands.ShoppingCarts;
using MeuEccomerce.API.Application.Query.ShoppingCarts;
using MeuEccomerce.API.Application.Services;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeuEccomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ShoppingCartService  _shoppingCartService;

        public ShoppingCartController(IMediator mediator, ShoppingCartService shoppingCartService)
        {
            _mediator = mediator;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ShoppingCartItem>>> GetItems()
        {
            var query = new GetShoppingCartItemsQuery(_shoppingCartService.Id);
            var shoppingCartItems = await _mediator.Send(query);
            return Ok(shoppingCartItems);
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddProduct(Guid productId)
        {
            var cmd = new AddItemToShoppingCartCommand(productId, _shoppingCartService.Id);
            await _mediator.Send(cmd);
            return NoContent();
        }

        [HttpDelete("delete-product/{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var command = new DeleteProductFromShoppingCartCommand(_shoppingCartService.Id, productId);
            var result = await _mediator.Send(command);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("clear")]
        public async Task<ActionResult> Clear()
        {
            var command = new ClearShoppingCartCommand(_shoppingCartService.Id);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("total-price")]
        public async Task<ActionResult<decimal>> GetTotalPrice()
        {
            var query = new GetShoppingCartTotalPriceQuery(_shoppingCartService.Id);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
