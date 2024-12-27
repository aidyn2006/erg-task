using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Services.impl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class GenealogyController : Controller
{
    private readonly IGenealogyService _genealogyService;

    public GenealogyController(IGenealogyService genealogyService)
    {
        _genealogyService = genealogyService;
    }


    [HttpGet]
    [SwaggerOperation(Summary = "This operation retrieves all genealogy.")]
    [SwaggerResponse(200, Description = "Successful response with a list of genealogy.")]
    [SwaggerResponse(204, Description = "No content - no genealogy found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> GetAll([FromQuery] int? year)
    {
        var supplies = await _genealogyService.GetGenealogyAsync(year);

        if (supplies == null || !supplies.Any())
        {
            return NoContent();
        }

        return Ok(supplies);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "This operation retrieves a genealogy by ID.")]
    [SwaggerResponse(200, Description = "Successful response with the genealogy object.")]
    [SwaggerResponse(404, Description = "Genealogy not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> GetEventById([FromRoute] int id)
    {
        var supply = await _genealogyService.GetGenealogyByIdAsync(id);

        if (supply == null)
        {
            return NotFound($"Genealogy with ID {id} not found.");
        }

        return Ok(supply);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "This operation creates a new genealogy.")]
    [SwaggerResponse(201, Description = "Genealogy created successfully.")]
    [SwaggerResponse(400, Description = "Invalid input.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> CreateEvent([FromBody] GenealogyDto genealogyDto)
    {
        var createdSupply = await _genealogyService.CreateGenealogyAsync(genealogyDto);
        return CreatedAtAction(nameof(GetEventById), new { id = createdSupply.Id }, createdSupply);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "This operation updates an existing genealogy by ID.")]
    [SwaggerResponse(200, Description = "Genealogy updated successfully.")]
    [SwaggerResponse(404, Description = "Genealogy not found.")]
    [SwaggerResponse(400, Description = "Invalid input.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] GenealogyDto genealogyDto)
    {
        var updatedSupply = await _genealogyService.UpdateGenealogyAsync(id, genealogyDto);

        if (updatedSupply == null)
        {
            return NotFound($"Genealogy with ID {id} not found.");
        }

        return Ok(updatedSupply);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "This operation deletes a genealogy by ID.")]
    [SwaggerResponse(204, Description = "Genealogy deleted successfully.")]
    [SwaggerResponse(404, Description = "Genealogy not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<string> DeleteEvent([FromRoute] int id)
    {
        return await _genealogyService.DeleteGenealogyAsync(id);
    }

    [HttpPost("/gen")]
    [SwaggerOperation(Summary = "This post action creates a new genealogy.")]
    [SwaggerResponse(201, Description = "Created genealogy successfully.")]
    [SwaggerResponse(404, Description = "Genealogy not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> CreatePost([FromQuery] int evenId, [FromQuery] float dimension)
    {
        return  Ok( await _genealogyService.CreateNewGenealogyAsync(evenId,dimension));
    }
    [HttpPost("/list")]
    [SwaggerOperation(Summary = "This post action creates a new events and genealogy.")]
    [SwaggerResponse(201, Description = "Created genealogy successfully.")]
    [SwaggerResponse(404, Description = "Genealogy not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> CreatePosts([FromQuery] int[]  eventIds, [FromQuery] float dimension)
    {
        return  Ok( await _genealogyService.CreateGenealogyListAsync(eventIds, dimension));
    }

    [HttpDelete("/del/{id}")]
    [SwaggerOperation(Summary = "This post action deletes a genealogy by ID.")]
    [SwaggerResponse(204, Description = "Genealogy deleted successfully.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> DeletePost([FromRoute] int id, bool isHardDelete)
    {
        return Ok(await _genealogyService.DeleteEventAsync(id, isHardDelete));
    }


}