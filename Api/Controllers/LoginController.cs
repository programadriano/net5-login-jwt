using Api.Domain;
using Api.Infra.Security;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public IActionResult Post(
            [FromBody] Credencial credenciais,
            [FromServices] ILoginService loginService)
        {
            try
            {
                var validarUsuario = loginService.Autentica(credenciais);

                if (validarUsuario == null)
                    return NotFound();

                return Ok(new
                {
                    token = JwtToken.GenerateToken(validarUsuario, _config),
                    usuario = validarUsuario
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
