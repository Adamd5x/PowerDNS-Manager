using Microsoft.EntityFrameworkCore.Query.Internal;

namespace hiPower.Core.Mappings;

internal class LocationMapping : IRegister
{
    public void Register (TypeAdapterConfig config)
    {
        config.NewConfig<DataCenter, ServerLocation> ()
              .Map (dest => dest.Id, src => src.Id)
              .Map (dest => dest.Name, src => src.Name)
              .Map (dest => dest.Address, src => src.Address)
              .Map (dest => dest.City, src => src.City)
              .Map (dest => dest.PostalCode, src => src.PostalCode)
              .Map (dest => dest.Region, src => src.Region)
              .Map (dest => dest.Country, src => src.Country)
              .Map (dest => dest.Description, src => src.Description);

        config.NewConfig<ServerLocation, DataCenter> ()
              .Map (dest => dest.Id, src => src.Id)
              .Map (dest => dest.Name, src => src.Name)
              .Map (dest => dest.Address, src => src.Address)
              .Map (dest => dest.City, src => src.City)
              .Map (dest => dest.PostalCode, src => src.PostalCode)
              .Map (dest => dest.Region, src => src.Region)
              .Map (dest => dest.Country, src => src.Country)
              .Map( dest => dest.Description, src => src.Description);

        config.NewConfig<DataCenter, HintItem>()
              .Map(dest => dest.Id, src => src.Id)
              .Map(dest => dest.Name, src => src.Name);
    }
}
