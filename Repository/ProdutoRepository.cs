using PIE_Stock_Track.Data;
using PIE_Stock_Track.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Npgsql.Replication.PgOutput.Messages;

namespace PIE_Stock_Track.Repository
{
    public class ProdutoRepository
    {
        private readonly EstoqueContext banco;

        public ProdutoRepository(EstoqueContext context)
        {
            banco = context;
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await banco.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await banco.Produtos.FindAsync(id);

        }

        public async Task AdicionarAsync(Produto produto)
        {
            await banco.Produtos.AddAsync(produto);
            await banco.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            banco.Produtos.Update(produto);
            await banco.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var produto = await banco.Produtos.FindAsync(id);
            if (produto != null)
            {
                banco.Produtos.Remove(produto);
                await banco.SaveChangesAsync();
            }
        }

        internal async Task ObterPorIdAsync(object get)
        {
            throw new NotImplementedException();
        }
    }
}
