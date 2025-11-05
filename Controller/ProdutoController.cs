using Microsoft.AspNetCore.Mvc;
using PIE_Stock_Track.Models;
using PIE_Stock_Track.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIE_Stock_Track.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoService.ListarProdutosAsync();
            return Ok(produtos);
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(Guid id)
        {
            try
            {
                var produto = await _produtoService.ObterProdutoPorIdAsync(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        // POST: api/produto
        [HttpPost]
        public async Task<ActionResult> PostProduto([FromBody] Produto produto)
        {
            try
            {
                await _produtoService.CadastrarProdutoAsync(produto);
                return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/produto/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduto(Guid id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest(new { mensagem = "ID do produto não corresponde ao parâmetro da URL." });

            try
            {
                await _produtoService.AtualizarProdutoAsync(produto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/produto/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(Guid id)
        {
            try
            {
                await _produtoService.RemoverProdutoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
