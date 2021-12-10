using LivrariaBackend.Context;
using LivrariaBackend.InputModels;
using LivrariaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;

        public AutoresController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListarTodos()
        {
            var autores = await _livrariaDbContext.Autores.ToListAsync();

            if (autores.Count == 0) return NotFound("Nenhum autor cadastrado.");


            return Ok( new

            {
                Status = "Sucesso",
                Code = "200",
                data =
                autores.Select(x =>
                new
                {
                    id = x.Id,
                    nome = x.Nome,
                    sobreNome = x.SobreNome
                }).ToList()
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CadastrarAutor(AutorInput autorInput)
        {
            var autor = new Autor
            {
                Nome = autorInput.Nome,
                SobreNome = autorInput.SobreNome
            };

            await _livrariaDbContext.Autores.AddAsync(autor);
            await _livrariaDbContext.SaveChangesAsync();

            return Ok("Autor criado com sucesso!");
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AtualizarAutor(AutorUpdateInput autorUpdateInput)
        {
            var autor = await _livrariaDbContext.Autores.SingleOrDefaultAsync(x => x.Id == autorUpdateInput.autorId);

            if (autor == null) return NotFound("Livro não encontrado.");

            autor.Nome = autorUpdateInput.Nome;
            autor.SobreNome = autorUpdateInput.SobreNome;

            _livrariaDbContext.Autores.Update(autor);
            await _livrariaDbContext.SaveChangesAsync();

            return Ok(
                new
                {
                    status = "Sucesso",
                    code = 201,
                    data = true
                });

        }

        [HttpDelete]
        [Authorize]
        [Route("{autorId}")]
        public async Task<IActionResult> Excluir(int autorId)
        {
            var autor = await _livrariaDbContext.Autores.SingleOrDefaultAsync(x => x.Id == autorId);

            if (autor == null) return NotFound(new { Status = "Falha", Code = "400", data = "Não encontrado" });

            _livrariaDbContext.Autores.Remove(autor);

            await _livrariaDbContext.SaveChangesAsync();

            return Ok(
                new
                {
                    Status = "Sucesso",
                    Code = "201",
                    data = true
                }
                );

        }

    }
}
