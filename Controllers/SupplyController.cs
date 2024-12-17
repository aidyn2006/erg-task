using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ERG_Task.DTOs;
using ERG_Task.Services.impl;

namespace ERG_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyController : ControllerBase
    {
        private readonly ISupplyService _supplyService;

        public SupplyController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "This operation retrieves all supplies.")]
        [SwaggerResponse(200, Description = "Successful response with a list of supplies.")]
        [SwaggerResponse(204, Description = "No content - no supplies found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> GetAll()
        {
            var supplies = await _supplyService.GetSupplyAsync();

            if (supplies == null || !supplies.Any())
            {
                return NoContent();
            }

            return Ok(supplies);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "This operation retrieves a supply by ID.")]
        [SwaggerResponse(200, Description = "Successful response with the supply object.")]
        [SwaggerResponse(404, Description = "Supply not found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> GetSupplyById([FromRoute] int id)
        {
            var supply = await _supplyService.GetSupplyByIdAsync(id);

            if (supply == null)
            {
                return NotFound($"Supply with ID {id} not found.");
            }

            return Ok(supply);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "This operation creates a new supply.")]
        [SwaggerResponse(201, Description = "Supply created successfully.")]
        [SwaggerResponse(400, Description = "Invalid input.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> CreateSupply([FromBody] SupplyDto supplyDto)
        {
            var createdSupply = await _supplyService.CreateSupplyAsync(supplyDto);
            return CreatedAtAction(nameof(GetSupplyById), new { id = createdSupply.Id }, createdSupply);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "This operation updates an existing supply by ID.")]
        [SwaggerResponse(200, Description = "Supply updated successfully.")]
        [SwaggerResponse(404, Description = "Supply not found.")]
        [SwaggerResponse(400, Description = "Invalid input.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> UpdateSupply([FromRoute] int id, [FromBody] SupplyDto supplyDto)
        {
            var updatedSupply = await _supplyService.UpdateSupplyAsync(id, supplyDto);

            if (updatedSupply == null)
            {
                return NotFound($"Supply with ID {id} not found.");
            }

            return Ok(updatedSupply);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "This operation deletes a supply by ID.")]
        [SwaggerResponse(204, Description = "Supply deleted successfully.")]
        [SwaggerResponse(404, Description = "Supply not found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<string> DeleteSupply([FromRoute] int id)
        {
            return await _supplyService.DeleteSupplyAsync(id);
        }
    }
}
