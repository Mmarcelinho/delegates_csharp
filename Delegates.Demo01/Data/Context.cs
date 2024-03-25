using Delegates.Demo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Delegates.Demo01.Data;

    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => 
        optionsBuilder.UseSqlServer(@"
        Server=localhost,1433;
        Database=Db;User ID=sa;
        Password=1q2w3e4r@#$;
        Trusted_Connection=False;
        TrustServerCertificate=True;");
    }
