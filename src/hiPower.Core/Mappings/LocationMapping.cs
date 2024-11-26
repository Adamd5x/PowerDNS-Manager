namespace hiPower.Core.Mappings;

internal class LocationMapping : IRegister
{
    public void Register (TypeAdapterConfig config)
    {
        config.NewConfig<Location, ServerLocation>()
              .Map(dest => dest.Id, src => src.Id)
              .Map(dest => dest.Name, src => src.Name)
              .Map(dest => dest.Address, src => src.Address)
              .Map(dest => dest.City, src => src.City)
              .Map(dest => dest.PostalCode, src => src.PostalCode)
              .Map(dest => dest.Region, src => src.Region)
              .Map(dest => dest.Country, src => src.Country);

        config.NewConfig<ServerLocation, Location> ()
              .Map (dest => dest.Id, src => src.Id)
              .Map (dest => dest.Name, src => src.Name)
              .Map (dest => dest.Address, src => src.Address)
              .Map (dest => dest.City, src => src.City)
              .Map (dest => dest.PostalCode, src => src.PostalCode)
              .Map (dest => dest.Region, src => src.Region)
              .Map (dest => dest.Country, src => src.Country);
    }
}
