using ERG_Task.DTOs;
using ERG_Task.Services.impl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CreateInstancesController : ControllerBase
{
    private readonly ICreateInstancesService _createInstancesService;

    public CreateInstancesController(ICreateInstancesService createInstancesService)
    {
        _createInstancesService = createInstancesService;
    }

    [HttpPost]
    [SwaggerOperation(description: "Create new instances")]
    [SwaggerResponse(200, description: "Success")]
    [SwaggerResponse(400, description: "Bad Request")]
    public async Task<IActionResult> Post([FromBody] CreateInstancesRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        try
        {
            var result = await _createInstancesService.CreateInstancesAsync(request);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message); 
        }
    }
}
