using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TrainController : Controller
{
 
    [HttpGet]
    [HttpGet("{id}")]
    [SwaggerResponse(200, Description = "Успешный ответ с объектом типа Item.")]
    [SwaggerResponse(404, null, Description = "Элемент не найден.")]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
}