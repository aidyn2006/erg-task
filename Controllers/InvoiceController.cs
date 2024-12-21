using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Services.impl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class InvoiceController : Controller
{
 
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    

    [HttpGet]
    [SwaggerOperation(Summary = "This operation retrieves all invoices.")]
    [SwaggerResponse(200, Description = "Successful response with a list of invoices.")]
    [SwaggerResponse(204, Description = "No content - no invoice found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> GetAll([FromQuery] int? year, [FromQuery] int? type)
    {
        var supplies = await _invoiceService.GetInvoiceAsync(year,type);

        if (supplies == null || !supplies.Any())
        {
            return NoContent();
        }
        return Ok(supplies);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "This operation retrieves a invoice by ID.")]
    [SwaggerResponse(200, Description = "Successful response with the invoice object.")]
    [SwaggerResponse(404, Description = "Invoice not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> GetEventById([FromRoute] int id)
    {
        var supply = await _invoiceService.GetInvoiceByIdAsync(id);

        if (supply == null)
        {
            return NotFound($"Invoice with ID {id} not found.");
        }

        return Ok(supply);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "This operation creates a new genealogy.")]
    [SwaggerResponse(201, Description = "Genealogy created successfully.")]
    [SwaggerResponse(400, Description = "Invalid input.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> CreateEvent([FromBody] InvoiceDto invoiceDto)
    {
        var createdSupply = await  _invoiceService.CreateInvoiceAsync(invoiceDto);
        return CreatedAtAction(nameof(GetEventById), new { id = createdSupply.Id }, createdSupply);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "This operation updates an existing invoice by ID.")]
    [SwaggerResponse(200, Description = "Invoice updated successfully.")]
    [SwaggerResponse(404, Description = "Invoice not found.")]
    [SwaggerResponse(400, Description = "Invalid input.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] InvoiceDto invoiceDto)
    {
        var updatedSupply = await _invoiceService.UpdateInvoiceAsync(id, invoiceDto);

        if (updatedSupply == null)
        {
            return NotFound($"Invoice with ID {id} not found.");
        }

        return Ok(updatedSupply);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "This operation deletes a invoice by ID.")]
    [SwaggerResponse(204, Description = "Invoice deleted successfully.")]
    [SwaggerResponse(404, Description = "Invoice not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<string> DeleteEvent([FromRoute] int id)
    {
        return await _invoiceService.DeleteInvoiceAsync(id);
    }
    
}