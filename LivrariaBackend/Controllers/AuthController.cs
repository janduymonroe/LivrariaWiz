using LivrariaBackend.Adaptadores;
using LivrariaBackend.Context;
using LivrariaBackend.Services.Auth.Jwt;
using LivrariaBackend.Services.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace LivrariaBackend.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthGerenciador jwtAuthGerenciador;
        private readonly LivrariaDbContext livrariaDbContext;

        public AuthController(IJwtAuthGerenciador jwtAuthGerenciador, LivrariaDbContext livrariaDbContext)
        {
            this.jwtAuthGerenciador = jwtAuthGerenciador;
            this.livrariaDbContext = livrariaDbContext;

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(JwtUsuarioCredenciais jwtUsuarioCredenciais)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var usuario = await livrariaDbContext.Usuarios.SingleOrDefaultAsync(c =>
                c.Email == jwtUsuarioCredenciais.Email && c.Senha == jwtUsuarioCredenciais.Senha);

                if (usuario == null) return NotFound();

                return Ok(new
                {
                    data = jwtAuthGerenciador.GerarToken(usuario.ParaJwtCredenciais())
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                });
            }
        }
    }
}
