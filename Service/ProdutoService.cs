using PIE_Stock_Track.Models;
using PIE_Stock_Track.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace PIE_Stock_Track.Service
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService(ProdutoRepository repository)
        {
            _repository = repository;
        }



        public Task<List<Produto>> ListarProdutosAsync()
        {
            return _repository.ObterTodosAsync();
        }

        public async Task<Produto> ObterProdutoPorIdAsync(Guid id)
        {
            var produto = await _repository.ObterPorIdAsync(id);
            if (produto == null)
                throw new Exception("Produto não encontrado");

            return produto;
        }

        public async Task CadastrarProdutoAsync(Produto produto)
        {
            if (produto.PrecoVenda <= 0)
                throw new Exception("Preço deve ser maior que zero");

            await _repository.AdicionarAsync(produto);
        }

        public async Task AtualizarProdutoAsync(Produto produto)
        {
            var existente = await _repository.ObterPorIdAsync(produto.Id);
            if (existente == null)
                throw new Exception("Produto não encontrado");

            await _repository.AtualizarAsync(produto);
        }

        public async Task RemoverProdutoAsync(Guid id)
        {
            await _repository.RemoverAsync(id);
        }
    }
}
