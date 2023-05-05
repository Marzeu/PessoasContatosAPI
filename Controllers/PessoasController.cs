using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
            [FromServices] PessoasContatosContext context)
        {
            try
            {
                var pessoas = await context.Pessoa.Include(p => p.Contatos).ToListAsync();
                var pessoasContatosViewModel = pessoas.Select(p => new PessoaContatoViewModel
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Contatos = p.Contatos.Select(c => new ContatoViewModel
                    {
                        Valor = c.Valor,
                        Tipo = c.Tipo,

                    }).ToList(),
                });

                return Ok(new ResultViewModel<List<PessoaContatoViewModel>>(pessoasContatosViewModel.ToList()));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<PessoaContatoViewModel>>("Falha interna no servidor"));
            }
        }

        [HttpGet("api/v1/pessoas/{id:int}")]
        public async Task<IActionResult> GetByIdAsyncPessoas(
            [FromRoute] int id,
            [FromServices] PessoasContatosContext context)
        {
            try
            {
                var pessoa = await context.Pessoa.FirstOrDefaultAsync(p => p.Id == id);
                var contatos = await context.Contato.Where(c => c.PessoaId == id).ToListAsync();

                var pessoasContatosViewModel = new PessoaContatoViewModel
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Contatos = pessoa.Contatos.Select(c => new ContatoViewModel
                    {
                        Valor = c.Valor,
                        Tipo = c.Tipo,

                    }).ToList(),
                };

                if (pessoa == null) return NotFound(new ResultViewModel<PessoaContatoViewModel>("Pessoa não encontrada"));

                return Ok(new ResultViewModel<PessoaContatoViewModel>(pessoasContatosViewModel));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<PessoaContatoViewModel>("Falha interna no servidor"));
            }
        }

        [HttpPost("api/v1/pessoa")]
        public async Task<IActionResult> PostAsyncPessoa(
            [FromBody] EditorPessoaViewModel model,
            [FromServices] PessoasContatosContext context)
        {

            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<Pessoa>(ModelState.GetErrors()));

            try
            {
                var pessoa = new Pessoa
                {
                    Id = 0,
                    Nome = model.Nome,
                    //Contatos = model.Contatos.Select(c => new Contato
                    //{
                    //    Valor = c.Valor,
                    //    Tipo = c.Tipo,

                    //}).ToList(),
                };

                await context.Pessoa.AddAsync(pessoa);
                await context.SaveChangesAsync();

                return Created($"api/v1/pessoas/{pessoa.Id}", new ResultViewModel<Pessoa>(pessoa));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Pessoa>("Não foi possível incluir a pessoa"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Pessoa>("Falha interna no servidor"));
            }
        }

        [HttpPut("api/v1/pessoa/{id:int}")]
        public async Task<IActionResult> PutAsyncPessoa(
            [FromRoute] int id,
            [FromBody] EditorPessoaViewModel model,
            [FromServices] PessoasContatosContext context)
        {
            try
            {
                var pessoa = await context.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

                if (pessoa == null) return NotFound(new ResultViewModel<Pessoa>("Pessoa não encontrada"));

                pessoa.Nome = model.Nome;

                context.Pessoa.Update(pessoa);
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

        [HttpDelete("api/v1/pessoa/{id:int}")]
        public async Task<IActionResult> DeleteAsyncPessoa(
                [FromRoute] int id,
                [FromServices] PessoasContatosContext context)
        {
            try
            {
                var pessoa = await context.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

                if (pessoa == null) return NotFound(new ResultViewModel<Pessoa>("Pessoa não encontrada"));

                context.Pessoa.Remove(pessoa);
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
