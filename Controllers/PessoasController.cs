using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PessoasContatosAPI.Data;
using PessoasContatosAPI.Extensions;
using PessoasContatosAPI.Models;
using PessoasContatosAPI.ViewModels;
using System.Linq.Expressions;

namespace PessoasContatosAPI.Controllers
{
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet("api/v1/pessoas")]
        public async Task<IActionResult> GetAsyncPessoas(
            [FromServices] PessoasContext context)
        {
            try
            {
                var pessoas = await context.Pessoas.ToListAsync();

                return Ok(new ResultViewModel<List<Pessoa>>(pessoas));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Pessoa>>("Falha interna no servidor"));
            }
        }

        [HttpGet("api/v1/pessoas/{id:int}")]
        public async Task<IActionResult> GetByIdAsyncPessoas(
            [FromRoute] int id,
            [FromServices] PessoasContext context)
        {
            try
            {
                var pessoas = await context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

                if (pessoas == null) return NotFound(new ResultViewModel<Pessoa>("Pessoa não encontrada"));

                return Ok(new ResultViewModel<Pessoa>(pessoas));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Pessoa>("Falha interna no servidor"));
            }
        }

        [HttpPost("pessoas")]
        public async Task<IActionResult> PostAsyncPessoa(
            [FromBody] EditorPessoaViewModel model,
            [FromServices] PessoasContext context)
        {

            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<Pessoa>(ModelState.GetErrors()));

            try
            {
                var pessoa = new Pessoa
                {
                    Id = 0,
                    Nome = model.Nome,
                };

                await context.Pessoas.AddAsync(pessoa);
                await context.SaveChangesAsync();

                return Created($"api/v1/pessoas/{pessoa.Id}", new ResultViewModel<Pessoa>(pessoa));
            }
            catch (DbUpdateException ex)
            {                    
                return StatusCode(500, new ResultViewModel<Pessoa>("Não foi incluir a pessoa"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Pessoa>("Falha interna no servidor"));
            }
        }

        [HttpPut("pessoas/{id:int}")]
        public async Task<IActionResult> PutAsyncPessoa(
            [FromRoute] int id,
            [FromBody] EditorPessoaViewModel model,
            [FromServices] PessoasContext context)
        {
            try
            {
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

                if (pessoa == null) return NotFound(new ResultViewModel<Pessoa>("Pessoa não encontrada"));

                pessoa.Nome = model.Nome;

                context.Pessoas.Update(pessoa);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Pessoa>(pessoa));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possível editar a pessoa");
            }
            catch
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpDelete("api/v1/pessoas/{id:int}")]
        public async Task<IActionResult> DeleteAsyncPessoa(
                [FromRoute] int id,
                [FromServices] PessoasContext context)
        {
            try
            {
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

                if (pessoa == null) return NotFound(new ResultViewModel<Pessoa>("Pessoa não encontrada"));

                context.Pessoas.Remove(pessoa);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Pessoa>(pessoa));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Pessoa>("Não foi possível excluir"));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Pessoa>("Falha interna no servidor"));
            }
        }
    }
}
