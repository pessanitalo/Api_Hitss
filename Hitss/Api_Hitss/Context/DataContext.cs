using Api_Hitss.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Hitss.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Proposta> Proposta { get; set; }
        public DbSet<PaymentFlowSummary> PaymentFlowSummary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
