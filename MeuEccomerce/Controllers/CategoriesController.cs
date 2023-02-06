using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.API.Application.Query.Categories;
using MeuEccomerce.API.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuEccomerce.API.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly CategoryValidator _validationRules;

    public CategoriesController(IMediator mediator, CategoryValidator validationRules)
    {
        _mediator = mediator;
        _validationRules = validationRules;
    }
    [HttpGet]
    [Route("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(Id));
        return Ok(category);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var category = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand command)
    {
        var validator = _validationRules.Validate(command);

        if (!validator.IsValid)
            return BadRequest(validator.Errors);

        var cmd = await _mediator.Send(command);
        return Ok(command);
    }

    [HttpPatch]
    [Route("{Id:int}/disable")]
    public async Task<IActionResult> Disable(int Id)
    {
        DisableCategoryCommand category = new(Id);

        var cmd = await _mediator.Send(category);

        if (!cmd)
            return BadRequest();
        return Ok("Categoria desabilitada");
    }

    [HttpPatch]
    [Route("{Id:int}/enable")]
    public async Task<IActionResult> Enable(int Id)
    {
        EnableCategoryCommand category = new(Id);

        var cmd = await _mediator.Send(category);

        if (!cmd)
            return BadRequest();
        return Ok("Categoria habilitada");
    }

}
