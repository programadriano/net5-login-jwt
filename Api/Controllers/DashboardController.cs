using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Dados de dash");
        }
    }
}
