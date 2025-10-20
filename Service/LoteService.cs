using PIE_Stock_Track.Models;
using PIE_Stock_Track.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using PIE_Stock_Track.Enums;

namespace PIE_Stock_Track.Service
{
    public class LoteService
    {
        private readonly LoteRepository _repository;

        public LoteService(LoteRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Lote>> ListarTodosOsLotes()
        {
            return _repository.ObterTodosLotes();
        }

        //terminar
        public LoteEnum ValidarStatusLote(Guid id, string status)
        {
            bool valido = Enum.TryParse<LoteEnum>(status, true, out var statusEnum);

            if (!valido)
            {
                throw new ArgumentException("Status inválido!");
            }

            return statusEnum;
        }


        public async Task<List<Lote>> ListarTodosOsLotesPorStatus(Guid id, string status)
        {
            LoteEnum statusEnum = ValidarStatusLote(id, status);

            // Só aqui chamamos o repository, com enum válido
            return await _repository.ObterTodosLotePorStatus(statusEnum);
        }

        public async Task<Lote> ObterLotePorId(Guid id)
        {

            return await _repository.ObterLotePorId(id);
        }

        public async Task<Lote> AtualizarStatusDoLote(Guid id, string status, Produto produto)
        {

            LoteEnum statusEnum = ValidarStatusLote(id, status);
            //validar status.. verificar vencimento

            Lote lote = await _repository.ObterLotePorId(id);
            if (lote == null)
                throw new Exception("Lote não encontrado");
            lote.Status = statusEnum;

            if (produto.Validade < DateTime.Now)
                lote.Status = LoteEnum.vencido;

            return await _repository.AtualizarLote(id);

        }

        public async Task<Lote> AdicionarLote(Lote lote)
        {
            Lote lotenum = new Lote();
            lotenum.Status = LoteEnum.disponivel;


            await _repository.AdicionarLote(lote);
            return lote;

        }


        public async Task RemoverLote(Guid id)
        {
            await _repository.RemoverLote(id);

        }

        public async Task AtualizarLote(Guid id, Lote lote)
        {
            var existente = await _repository.ObterLotePorId(id);
            if (existente == null)
                throw new Exception("Lote não encontrada");

            await _repository.AtualizarLote(lote);

        }


    }
}