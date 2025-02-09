using Api_Hitss.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Hitss.Mappings
{
    public class PaymentScheduleMapping : IEntityTypeConfiguration<PaymentFlowSummary>
    {
        public void Configure(EntityTypeBuilder<PaymentFlowSummary> builder)
        {
            builder.ToTable("PaymentFlowSummary");
            builder.HasKey(p => p.PaymentFlowSummary_Id);

            builder.HasMany(f => f.PaymentSchedule)
           .WithOne(p => p.PaymentFlowSummary)
           .HasForeignKey(p => p.PaymentFlowSummary_Id);    
        }
    }
}
