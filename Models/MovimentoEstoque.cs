using System;

namespace PIE_Stock_Track.Models;

public class MovimentoEstoque
{
    public Guid Id { get; set; }
    public DateTime DataSaida { get; set; }
    public Guid IdProduto { get; set; }
    public int Quantidade { get; set; }
    public string? TipoMovimento { get; set; }
    public string? Origem { get; set; }
}