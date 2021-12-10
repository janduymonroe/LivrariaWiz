using LivrariaBackend.Context;
using LivrariaBackend.InputModels;
using LivrariaBackend.Models;
using LivrariaBackend.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LivrariaBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;

        public UsuariosController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var usuarios = await _livrariaDbContext.Usuarios.ToListAsync();

            if (usuarios != null)
            {
                return Ok(usuarios);

            }

            return NotFound("Nenhum usuário cadastrado.");
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(UsuarioInput dadosEntrada)
        {
            var usuario = new Usuario()
            {
                Email = dadosEntrada.Email,
                Senha = dadosEntrada.Senha,
                Role = 2
            };

            await _livrariaDbContext.Usuarios.AddAsync(usuario);
            await _livrariaDbContext.SaveChangesAsync();

            return Ok(
                new
                {
                    Status = "Ok",
                    Code = 201,
                    data = true
                });
        }
    }
}
