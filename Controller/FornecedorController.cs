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
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedorController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: api/fornecedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
        {
            var fornecedores = await _fornecedorService.ListarFornecedores();
            return Ok(fornecedores);
        }

        // GET: api/fornecedor/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedorPorID(Guid id)
        {
            try
            {
                var fornecedor = await _fornecedorService.ObterFornecedorPorId(id);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        // POST: api/fornecedor
        [HttpPost]
        public async Task<ActionResult> PostFornecedor([FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _fornecedorService.CadastrarFornecedor(fornecedor);
                return CreatedAtAction(nameof(GetFornecedorPorID), new { id = fornecedor.Id }, fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/fornecedor/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutFornecedor(Guid id, [FromBody] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id) // Corrigido: era fornecedor.id (minúsculo)
                return BadRequest(new { mensagem = "ID do fornecedor não corresponde ao parâmetro da URL." });

            try
            {
                await _fornecedorService.AtualizarFornecedor(fornecedor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/fornecedor/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFornecedor(Guid id)
        {
            try
            {
                await _fornecedorService.RemoverFornecedor(id); // Corrigido: era _produtoService
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
