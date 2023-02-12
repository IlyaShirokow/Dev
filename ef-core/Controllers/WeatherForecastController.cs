using ef_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ef_core.Controllers;

[ApiController]
[Route("/api")]
public class WeatherForecastController : ControllerBase
{
    private readonly BrokerContext _db;

    public WeatherForecastController(BrokerContext db)
    {
        _db = db;
    }

    [HttpGet("test")] //  /api/test
    public int[] Get()
    {
        return new[] { 1, 2, 3, 4, 5 };
    }
}
