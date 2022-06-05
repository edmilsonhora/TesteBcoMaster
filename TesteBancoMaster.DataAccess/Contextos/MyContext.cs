using Microsoft.EntityFrameworkCore;
using TesteBancoMaster.DataAccess.Mappings;
using TesteBancoMaster.DomainModel;

namespace TesteBancoMaster.DataAccess.Contextos
{
    public class MyContext : DbContext
    {

        public MyContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=myDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RotaMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Rota> Rotas { get; set; }
    }
}
