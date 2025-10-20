using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PIE_Stock_Track.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        private string Nome { get; set; }
        public DateTime Validade { get; set; }
        private double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        private string Descricao { get; set; }
        public ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    }

}