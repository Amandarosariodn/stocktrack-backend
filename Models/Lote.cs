using System;
using System.Collections.Generic;
using PIE_Stock_Track.Enums;

namespace PIE_Stock_Track.Models;

public class Lote
{
    public Lote()
    {
    }

    public Lote(Guid id, Guid idProduto, Guid idFornecedor, DateTime criacao, LoteEnum status, ICollection<MovimentoEstoque> movimentoEstoques, ICollection<SaldoEstoque> saldoEstoques)
    {
        Id = id;
        IdProduto = idProduto;
        IdFornecedor = idFornecedor;
        Criacao = criacao;
        Status = status;
        MovimentoEstoques = movimentoEstoques;
        SaldoEstoques = saldoEstoques;
    }

    public Guid Id { get; set; }
    public Guid IdProduto { get; set; }
    public Guid IdFornecedor { get; set; }
    public DateTime Criacao { get; set; }
    public LoteEnum Status { get; set; }
    public ICollection<MovimentoEstoque> MovimentoEstoques { get; set; } = new List<MovimentoEstoque>();
    public ICollection<SaldoEstoque> SaldoEstoques { get; set; } = new List<SaldoEstoque>();


}