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
    public class SaldoEstoqueService
    {
        private readonly SaldoEstoqueRepository _repository;

        public SaldoEstoqueService(SaldoEstoqueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SaldoEstoque>> ListarTodoOSaldoEstoque()
        {
            return await _repository.ObterSaldoEstoque();
        }

        public async Task<SaldoEstoque> ObterSaldoPorId(Guid id)
        {
            var saldo = await _repository.ObterSaldoEstoquePorId(id);
            if (saldo == null)
                throw new Exception("Nao encontrado");

            return saldo;
        }

        public async Task<SaldoEstoque> CadastrarSaldo(SaldoEstoque saldoEstoque, Guid idlote)
        {
            var lote = await _repository.ObterSaldoEstoquePorId(idlote);
            if (lote == null)
                throw new Exception("Nao encontrado");

            await _repository.AdicionarSaldoEstoque(saldoEstoque);

            return lote;
        }

        public async Task AtualizarSaldo(SaldoEstoque saldoEstoque)
        {
            var existente = await _repository.ObterSaldoEstoquePorId(saldoEstoque.LoteId);
            if (existente == null)
                throw new Exception("Produto não encontrado");

            await _repository.AtualizarSaldoEstoque(saldoEstoque);
        }

        public async Task RemoverSaldo(Guid id)
        {
            await _repository.RemoverSaldoEstoque(id);
        }



    }

}


