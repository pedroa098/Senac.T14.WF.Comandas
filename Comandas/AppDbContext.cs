using Microsoft.EntityFrameworkCore;

namespace Comandas
{
    // classe que representa o banco de dados
    public class AppDbContext : DbContext
    {
        // propriedade que representa a tabela Usuarios
        public DbSet<Usuario> Usuarios { get; set; }

        // métodos que configura informando para o EF que o banco será SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=comandas.db");
        }
    }

}
