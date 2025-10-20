using PIE_Stock_Track.Data;
using PIE_Stock_Track.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PIE_Stock_Track.Enums;
using System.Linq;

namespace PIE_Stock_Track.Repository
{
    public class LoteRepository
    {
        private readonly EstoqueContext banco;

        public LoteRepository(EstoqueContext context)
        {
            banco = context;
        }

        public async Task<List<Lote>> ObterTodosLotes()
        {
            return await banco.Lotes.AsNoTracking().ToListAsync();
        }

        public async Task<List<Lote>> ObterTodosLotePorStatus(LoteEnum status)
        {
            return await banco.Lotes.AsNoTracking().Where(p => p.Status == status).ToListAsync();
        }


        public async Task<Lote> ObterLotePorId(Guid id)
        {
            return await banco.Lotes.FindAsync(id);
        }

        public async Task AdicionarLote(Lote lote)
        {
            banco.Lotes.AddAsync(lote);
            await banco.SaveChangesAsync();
        }

        public async Task AtualizarLote(Lote lote)
        {
            banco.Lotes.Update(lote);
            await banco.SaveChangesAsync();
        }

        public async Task RemoverLote(Guid id)
        {
            var lote = await banco.Lotes.FindAsync(id);
            if (lote != null)
            {
                banco.Lotes.Remove(lote);
                await banco.SaveChangesAsync();
            }
        }

        internal async Task<Lote> AtualizarLote(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}