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
    public class LivrosController : ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;

        public LivrosController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListarTodos()
        {
            var livros = await _livrariaDbContext.Livros.ToListAsync();

            if (livros.Count == 0) return NotFound("Nenhum livro cadastrado.");


            return Ok(new
            {
                Status = "Sucesso",
                Code = "200",
                data =
                livros.Select(x =>
                new
                {
                    id = x.Id,
                    descricao = x.Descricao,
                    isbn = x.ISBN,
                    autorId = x.AutorId,
                    anoLancamento = x.AnoLancamento
                }).ToList()
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CadastrarLivro(LivroInput livroInput)
        {
            var livro = new Livro
            {
                Descricao = livroInput.Descricao,
                AutorId = livroInput.AutorId,
                ISBN = livroInput.ISBN,
                AnoLancamento = livroInput.AnoLancamento
            };

            await _livrariaDbContext.Livros.AddAsync(livro);
            await _livrariaDbContext.SaveChangesAsync();

            return Ok(
                new
                {
                    Status = "Sucesso",
                    Code = "201",
                    data = new
                    {
                        descricao = livro.Descricao,
                        autorId = livro.AutorId,
                        isbn = livro.ISBN,
                        anoLancamento = livro.AnoLancamento
                    }
                });
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AtualizarLivro(LivroUpdateInput livroUpdateInput)
        {
            var livro = await _livrariaDbContext.Livros.SingleOrDefaultAsync(x => x.Id == livroUpdateInput.LivroId);

            if (livro == null) return NotFound( new 
            { 
                Status=400,
                Code=404,
                data = "Não encontrado encontrado."
            });

            livro.Descricao = livroUpdateInput.Descricao;
            livro.AnoLancamento = livroUpdateInput.AnoLancamento;

            _livrariaDbContext.Livros.Update(livro);
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
        [Route("{livroId}")]
        public async Task<IActionResult> Excluir(int livroId)
        {
            var livro = await _livrariaDbContext.Livros.SingleOrDefaultAsync(x => x.Id == livroId);

            if (livro == null) return NotFound(new { Status="Falha", Code="400", data="Não encontrado"});

            _livrariaDbContext.Livros.Remove(livro);

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
