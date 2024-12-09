using hiPower.Common.Type;
using hiPower.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hiPower.Database.Configuration;

internal class MonitorServiceEntityConfiguration : IEntityTypeConfiguration<MonitorService>
{
    public void Configure (EntityTypeBuilder<MonitorService> builder)
    {
        builder.ToTable ($"{Prefix.Table}{nameof(MonitorService)}");

        builder.HasKey ( t => t.ServiceId );

        builder.HasIndex (i => new { i.ServiceId, i.MonitorState });

        builder.Property (p => p.ServiceId)
               .HasMaxLength (36)
               .HasConversion (value => value.ToUpperInvariant (),
                               value => value)
               .IsRequired();

        builder.Property(p => p.MonitorState)
               .HasConversion(value => value.ToString().ToLowerInvariant(),
                              value => Enum.Parse<MonitorState>(value, true))
               .HasMaxLength(10)
               .IsRequired();

    }
}
