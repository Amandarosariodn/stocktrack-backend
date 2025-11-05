using PIE_Stock_Track.Models;
using PIE_Stock_Track.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using PIE_Stock_Track.Service;
using System.Data.Common;

namespace PIE_Stock_Track.Service
{
    public class MovimentoEstoqueService
    {
        private readonly MovimentoEstoqueRepository _repository;

        public MovimentoEstoqueService(MovimentoEstoqueRepository repository)
        {
            _repository = repository;
        }

        public Task<List<MovimentoEstoque>> ListarMovimentosAsync()
        {
            return _repository.ObterTodosMovimentos();
        }

        public async Task<MovimentoEstoque> ObterMovimentoPorId(Guid id)
        {
            var movimento = await _repository.ObterMovimentoPorId(id);
            if (movimento == null)
                throw new Exception("Movimento não encontrado");

            return movimento;
        }

        public async Task CadastrarMovimentoAsync(MovimentoEstoque movimentoEstoque)
        {

            await _repository.AdicionarMovimentoEstoque(movimentoEstoque);
        }

        public async Task AtualizarMovimentoEstoque(Guid id)
        {
            var existente = await _repository.ObterMovimentoPorId(id);
            if (existente == null)
                throw new Exception("Produto não encontrado");

            await _repository.AtualizarMovimentoEstoque(existente);
        }

        public async Task RemoverMovimentoAsync(Guid id)
        {
            await _repository.RemoverMovimentoEstoque(id);
        }
    }
}