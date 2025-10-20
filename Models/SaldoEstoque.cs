using System;

namespace PIE_Stock_Track.Models;

public class SaldoEstoque
{
    public SaldoEstoque(Guid id, int quantidade, Guid loteId)
    {
        Id = id;
        Quantidade = quantidade;
        LoteId = loteId;
    }

    private Guid Id { get; set; }
    public int Quantidade { get; set; }
    public Guid LoteId { get; set; }
}