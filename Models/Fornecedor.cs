using System;
using System.Collections.Generic;

namespace PIE_Stock_Track.Models;

public class Fornecedor
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public int Telefone { get; set; }

    public ICollection<Lote> Lotes { get; set; } = new List<Lote>();

}