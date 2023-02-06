using MediatR;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.API.Application.Query.Products;
using MeuEccomerce.API.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuEccomerce.API.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ProductValidator _validationRules;
    public ProductsController(IMediator mediator, ProductValidator validationRules)
    {
        _mediator = mediator;
        _validationRules = validationRules;
    }

    [HttpGet]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(Id));
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var product = await _mediator.Send(new GetAllProductsQuery());
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductCommand command)
    {
        var validator = _validationRules.Validate(command);

        if (!validator.IsValid)
            return BadRequest(validator.Errors);

        var cmd = await _mediator.Send(command);

        return Ok("Deu bom");
    }

    [HttpDelete]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        DeleteProductCommand product = new(Id);
        var cmd = await _mediator.Send(product);
        if (!cmd)
            return BadRequest();
        return Ok("Deu bom");
        
    }

}
