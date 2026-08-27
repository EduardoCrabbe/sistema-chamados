using Microsoft.EntityFrameworkCore;
using SistemaChamados.Models;

namespace SistemaChamados.Data;

public class AplicacaoDbContext : DbContext
{
    // DbSet representa a tabela que será criada no banco
    public DbSet<Chamado> Chamados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Define a conexão local com o SQL Server de desenvolvimento
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SistemaChamadosDb;Trusted_Connection=True;");
    }
}