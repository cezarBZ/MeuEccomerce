using AutoMapper;
using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.API.Application.Query;
using MeuEccomerce.API.Application.Query.Categories;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuEccomerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
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
        var cmd = await _mediator.Send(command);

        if (!cmd)
            return BadRequest();
        return Ok("Deu bom");
    }

    [HttpPatch]
    [Route("{Id:int}/disable")]
    public async Task<IActionResult> Disable(int Id)
    {
        DisableCategoryCommand category = new(Id);

        var cmd = await _mediator.Send(category);

        if (!cmd)
            return BadRequest();
        return Ok("Deu bom");
    }

    [HttpPatch]
    [Route("{Id:int}/enable")]
    public async Task<IActionResult> Enable(int Id)
    {
        EnableCategoryCommand category = new(Id);

        var cmd = await _mediator.Send(category);

        if (!cmd)
            return BadRequest();
        return Ok("Deu bom");
    }

}
