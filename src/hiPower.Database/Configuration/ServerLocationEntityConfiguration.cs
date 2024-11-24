using hiPower.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hiPower.Database.Configuration;

internal class ServerLocationEntityConfiguration : IEntityTypeConfiguration<ServerLocation>
{
    public void Configure (EntityTypeBuilder<ServerLocation> builder)
    {
        builder.ToTable($"{Prefix.Table}{nameof(ServerLocation)}");

        builder.HasKey( x => x.Id );

        builder.HasIndex (x => x.Name);

        builder.Property(x => x.Id)
               .HasMaxLength(32)
               .HasConversion(value => value.ToUpperInvariant(),
                              value => value)
               .IsRequired();

        builder.Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property (p => p.Description)
               .HasMaxLength (250);

        builder.Property( x => x.Address)
               .HasMaxLength(150);

        builder.Property (x => x.City)
               .HasMaxLength (150);

        builder.Property (x => x.PostalCode)
               .HasMaxLength (50);

        builder.Property (x => x.Region)
               .HasMaxLength (50);

        builder.Property (x => x.Country)
               .HasMaxLength (50);

        builder.HasMany(x => x.Servers)
               .WithOne(y => y.Location)
               .HasForeignKey(x => x.LocationId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
