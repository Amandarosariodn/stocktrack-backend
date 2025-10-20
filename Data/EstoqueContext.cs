using Microsoft.EntityFrameworkCore;
using PIE_Stock_Track.Models;

namespace PIE_Stock_Track.Data
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options)
            : base(options)
        {
        }

        // Cada DbSet representa uma tabela no banco
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Lote> Lotes { get; set; } = null!;
        public DbSet<MovimentoEstoque> MovimentosEstoque { get; set; } = null!;
        public DbSet<Fornecedor> Fornecedores { get; set; } = null!;
        public DbSet<SaldoEstoque> SaldoEstoques { get; set; } = null!;

    }
}
