using PIE_Stock_Track.Models;
using PIE_Stock_Track.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq;

namespace PIE_Stock_Track.Service
{
    public class FornecedorService
    {
        private readonly FornecedorRepository _repository;

        public FornecedorService(FornecedorRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Fornecedor>> ListarFornecedores()
        {
            return _repository.ObterTodosFornecedores();
        }

        public async Task<Fornecedor> EncontrarFornecedorPorId(Guid id)
        {
            var fornecedor = await _repository.ObterFornecedorPorId(id);
            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado");
            return fornecedor;
        }

        public async Task CadastrarFornecedor(Fornecedor fornecedor)
        {
            var quantidadeDigitos = fornecedor.CNPJ.Count(char.IsDigit);
            if (quantidadeDigitos != 14)
                throw new Exception("CNPJ Inválido!");

            await _repository.AdicionarFornecedor(fornecedor);
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            var existente = await _repository.ObterFornecedorPorId(fornecedor.Id);
            if (existente == null)
                throw new Exception("Produto não encontrado");

            await _repository.AtualizarFornecedor(fornecedor);

        }

        public async Task RemoverFornecedor(Guid id)
        {
            await _repository.RemoverFornecedor(id);
        }

    }
}
