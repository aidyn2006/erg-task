using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Services.impl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PackageController : Controller
{
 
    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
        _packageService = packageService;
    } 
        [HttpGet]
        [SwaggerOperation(Summary = "This operation retrieves all packages.")]
        [SwaggerResponse(200, Description = "Successful response with a list of packages.")]
        [SwaggerResponse(204, Description = "No content - no package found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> GetAll([FromQuery] int? type,[FromQuery] int? status)
        {
            var supplies = await _packageService.GetPackageAsync(type,status);

            if (supplies == null || !supplies.Any())
            {
                return NoContent();
            }
            return Ok(supplies);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "This operation retrieves a package by ID.")]
        [SwaggerResponse(200, Description = "Successful response with the package object.")]
        [SwaggerResponse(404, Description = "Package not found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> GetEventById([FromRoute] int id)
        {
            var supply = await _packageService.GetPackageByIdAsync(id);

            if (supply == null)
            {
                return NotFound($"Package with ID {id} not found.");
            }

            return Ok(supply);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "This operation creates a new package.")]
        [SwaggerResponse(201, Description = "Package created successfully.")]
        [SwaggerResponse(400, Description = "Invalid input.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> CreateEvent([FromBody] PackageDto packageDto)
        {
            var createdSupply = await  _packageService.CreatePackageAsync(packageDto);
            return CreatedAtAction(nameof(GetEventById), new { id = createdSupply.Id }, createdSupply);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "This operation updates an existing package by ID.")]
        [SwaggerResponse(200, Description = "Package updated successfully.")]
        [SwaggerResponse(404, Description = "Package not found.")]
        [SwaggerResponse(400, Description = "Invalid input.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] PackageDto packageDto)
        {
            var updatedSupply = await _packageService.UpdatePackageAsync(id, packageDto);

            if (updatedSupply == null)
            {
                return NotFound($"Package with ID {id} not found.");
            }

            return Ok(updatedSupply);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "This operation deletes a package by ID.")]
        [SwaggerResponse(204, Description = "Package deleted successfully.")]
        [SwaggerResponse(404, Description = "Package not found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<string> DeleteEvent([FromRoute] int id)
        {
            return await _packageService.DeletePackageAsync(id);
        }
        
}