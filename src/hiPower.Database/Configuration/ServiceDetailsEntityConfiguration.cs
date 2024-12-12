using hiPower.Common.Type;
using hiPower.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hiPower.Database.Configuration;

internal class ServiceDetailsEntityConfiguration : IEntityTypeConfiguration<ServiceDetails>
{
    public void Configure (EntityTypeBuilder<ServiceDetails> builder)
    {
        builder.ToTable ($"{Prefix.Table}{nameof(ServiceDetails)}");

        builder.HasKey ( t => t.Id );

        builder.Property(p => p.Id)
               .HasMaxLength(36)
               .HasConversion(value => value.ToUpperInvariant(),
                              value => value)
               .IsRequired ();

        builder.Property(p => p.DataCenterId)
               .HasMaxLength(36)
               .HasConversion(value => value.ToUpperInvariant(),
                              value => value)
               .IsRequired ();

        builder.Property (p => p.LocalId)
               .HasMaxLength (250);

        builder.Property (p => p.Name)
               .HasMaxLength (50)
               .IsRequired ();

        builder.Property (p => p.Description)
               .HasMaxLength (250);

        builder.Property(p => p.Proto)
               .HasMaxLength(10)
               .IsRequired ();

        builder.Property(p => p.HostAddress)
               .HasMaxLength(250)
               .IsRequired ();

        builder.Property(p => p.Proto)
               .HasPrecision(0, 5)
               .IsRequired ();

        builder.Property (p => p.Version)
               .HasMaxLength (20);

        builder.Property (p => p.OS)
               .HasMaxLength (150);

        builder.Property (p => p.ApiKey)
               .HasMaxLength (250);

        builder.Property (p => p.Auth)
               .HasMaxLength (250);

        builder.Property (p => p.State)
               .HasConversion(value => value.ToString(),
                              value => Enum.Parse<ServiceState>(value,true))
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(p => p.Mode)
               .HasMaxLength(20)
               .HasConversion(v => v.ToString(),
                              v => Enum.Parse<ServiceMode>(v,true))
               .IsRequired ();

        builder.HasMany (x => x.MonitorStatistics)
               .WithOne (y => y.ServiceDetails)
               .HasForeignKey (k => k.ServiceId)
               .OnDelete(DeleteBehavior.ClientCascade);
    }
}
