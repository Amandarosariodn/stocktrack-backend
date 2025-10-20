using PIE_Stock_Track.Data;
using PIE_Stock_Track.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace PIE_Stock_Track.Repository
{
    public class SaldoEstoqueRepository
    {
        private readonly EstoqueContext banco;

        public SaldoEstoqueRepository(EstoqueContext context)
        {
            banco = context;
        }

        public async Task<List<SaldoEstoque>> ObterSaldoEstoque()
        {
            return await banco.SaldoEstoques.AsNoTracking().ToListAsync();
        }

        public async Task<SaldoEstoque> ObterSaldoEstoquePorId(Guid idlote)
        {
            return await banco.SaldoEstoques.FindAsync(idlote);
        }

        public async Task AdicionarSaldoEstoque(SaldoEstoque saldoEstoque)
        {

            banco.SaldoEstoques.AddAsync(saldoEstoque);
            await banco.SaveChangesAsync();
        }

        public async Task AtualizarSaldoEstoque(SaldoEstoque saldoEstoque)
        {
            banco.SaldoEstoques.Update(saldoEstoque);
            await banco.SaveChangesAsync();
        }

        public async Task RemoverSaldoEstoque(Guid id)
        {
            var saldoEstoque = await banco.SaldoEstoques.FindAsync(id);
            if (saldoEstoque != null)
            {
                banco.SaldoEstoques.Remove(saldoEstoque);
                await banco.SaveChangesAsync();
            }
        }

    }
}