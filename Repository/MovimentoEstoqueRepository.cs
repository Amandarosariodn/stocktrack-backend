using PIE_Stock_Track.Data;
using PIE_Stock_Track.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace PIE_Stock_Track.Repository
{
    public class MovimentoEstoqueRepository
    {
        private readonly EstoqueContext banco;

        public MovimentoEstoqueRepository(EstoqueContext context)
        {
            banco = context;
        }

        public async Task<List<MovimentoEstoque>> ObterTodosMovimentos()
        {
            return await banco.MovimentosEstoque.AsNoTracking().ToListAsync();
        }

        public async Task<MovimentoEstoque> ObterMovimentoPorId(Guid id)
        {
            return await banco.MovimentosEstoque.FindAsync(id);
        }

        public async Task AdicionarMovimentoEstoque(MovimentoEstoque movimentoEstoque)
        {
            await banco.MovimentosEstoque.AddAsync(movimentoEstoque);
            await banco.SaveChangesAsync();
        }

        public async Task AtualizarMovimentoEstoque(MovimentoEstoque movimentoEstoque)
        {
            banco.MovimentosEstoque.Update(movimentoEstoque);
            await banco.SaveChangesAsync();
        }

        public async Task RemoverMovimentoEstoque(Guid id)
        {
            var movimentos = await banco.MovimentosEstoque.FindAsync(id);
            if (movimentos != null)
            {
                banco.MovimentosEstoque.Remove(movimentos);
                await banco.SaveChangesAsync();
            }
        }

    }
}