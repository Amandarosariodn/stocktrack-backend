using PIE_Stock_Track.Data;
using PIE_Stock_Track.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace PIE_Stock_Track.Repository
{
    public class FornecedorRepository
    {
        private readonly EstoqueContext banco;

        public FornecedorRepository(EstoqueContext context)
        {
            banco = context;
        }

        public async Task<List<Fornecedor>> ObterTodosFornecedores()
        {
            return await banco.Fornecedores.AsNoTracking().ToListAsync();
        }

        public async Task<Fornecedor> ObterFornecedorPorId(Guid id)
        {
            return await banco.Fornecedores.FindAsync(id);
        }

        public async Task AdicionarFornecedor(Fornecedor fornecedor)
        {
            await banco.Fornecedores.AddAsync(fornecedor);
            await banco.SaveChangesAsync();
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            banco.Fornecedores.Update(fornecedor);
            await banco.SaveChangesAsync();
        }

        public async Task RemoverFornecedor(Guid id)
        {
            var fornecedor = await banco.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                banco.Fornecedores.Remove(fornecedor);
                await banco.SaveChangesAsync();
            }
        }

    }
}