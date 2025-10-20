using System;

namespace PIE_Stock_Track.Models;

public class MovimentoEstoque
{
    private Guid Id { get; set; }
    private DateTime DataSaida { get; set; }
    private Guid IdProduto { get; set; }
    private int Quantidade { get; set; }
    private string TipoMovimento { get; set; }
    private string Origem { get; set; }
}