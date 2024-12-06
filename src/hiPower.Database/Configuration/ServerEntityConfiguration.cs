using hiPower.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hiPower.Database.Configuration;

internal class ServerEntityConfiguration : IEntityTypeConfiguration<ServerDetails>
{
    public void Configure (EntityTypeBuilder<ServerDetails> builder)
    {
        builder.ToTable ($"{Prefix.Table}Server");

        builder.HasKey ( t => t.Id );

        builder.Property(p => p.Id)
               .HasMaxLength(36)
               .HasConversion(value => value.ToUpperInvariant(),
                              value => value)
               .IsRequired ();

        builder.Property(p => p.LocationId)
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
               .HasPrecision (0, 3)
               .IsRequired();

        builder.Property (p => p.Timeout)
               .HasPrecision (0, 5);

        builder.Property (p => p.Retries)
               .HasPrecision (0, 2);
    }
}
