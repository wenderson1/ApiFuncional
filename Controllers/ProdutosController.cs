using ApiFuncional.Data;
using ApiFuncional.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFuncional.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController(ApiDbContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await context.Produtos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            return await context.Produtos.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            context.Produtos.Add(produto);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new {id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutProduto(int id, Produto produto)
        {
            Produto produtoAtual = await context.Produtos.FindAsync(id);
            produtoAtual = produto;
            
            context.Produtos.Update(produtoAtual);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            Produto produtoAtual = await context.Produtos.FindAsync(id);


            context.Produtos.Remove(produtoAtual);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
