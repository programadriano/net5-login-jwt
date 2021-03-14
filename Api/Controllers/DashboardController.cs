using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DashboardController : BaseController
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            _logger.LogInformation(JsonSerializer.Serialize(new
            {
                CorrelationId = CorrelationId,
                Mensagem = "Acessando Dash",
                Data = Usuario
            }));

            return Ok(new
            {
                autenticado = true,
                sessao = "Dados de dash"
            });
        }
    }
}
