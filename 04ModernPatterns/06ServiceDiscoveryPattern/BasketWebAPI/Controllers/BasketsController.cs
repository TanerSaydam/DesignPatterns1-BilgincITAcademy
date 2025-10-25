using Microsoft.AspNetCore.Mvc;

namespace BasketWebAPI.Controllers;

[ApiController]
[Route("/api/baskets")]
public class BasketsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        await Task.CompletedTask;
        return Ok();
    }
}
