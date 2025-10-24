using Microsoft.AspNetCore.Mvc;

namespace _01Middleware.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [MyValidation]
    public IActionResult GetAll()
    {
        return Ok(new List<string>());
    }
}
