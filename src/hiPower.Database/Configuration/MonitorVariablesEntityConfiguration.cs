using hiPower.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hiPower.Database.Configuration;

internal class MonitorVariablesEntityConfiguration : IEntityTypeConfiguration<MonitorVariables>
{
    public void Configure (EntityTypeBuilder<MonitorVariables> builder)
    {
        builder.ToTable ($"{Prefix.Table}{nameof (MonitorVariables)}");

        builder.HasKey (k => k.ServiceId);

        builder.Property (p => p.ServiceId)
               .HasMaxLength (36)
               .HasConversion (value => value.ToUpperInvariant (),
                              value => value)
               .IsRequired ();

        builder.Property (p => p.Variable)
               .HasMaxLength (30)
               .IsRequired ();
    }
}
