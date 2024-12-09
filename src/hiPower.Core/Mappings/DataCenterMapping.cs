using Microsoft.EntityFrameworkCore.Query.Internal;

namespace hiPower.Core.Mappings;

internal class DataCenterMapping : IRegister
{
    public void Register (TypeAdapterConfig config)
    {
        config.NewConfig<Dto.Manager.DataCenter, Entity.DataCenter> ()
              .Map (dest => dest.Id, src => src.Id)
              .Map (dest => dest.Name, src => src.Name)
              .Map (dest => dest.Address, src => src.Address)
              .Map (dest => dest.City, src => src.City)
              .Map (dest => dest.PostalCode, src => src.PostalCode)
              .Map (dest => dest.Region, src => src.Region)
              .Map (dest => dest.Country, src => src.Country)
              .Map (dest => dest.Description, src => src.Description);

        config.NewConfig<Entity.DataCenter, Dto.Manager.DataCenter> ()
              .Map (dest => dest.Id, src => src.Id)
              .Map (dest => dest.Name, src => src.Name)
              .Map (dest => dest.Address, src => src.Address)
              .Map (dest => dest.City, src => src.City)
              .Map (dest => dest.PostalCode, src => src.PostalCode)
              .Map (dest => dest.Region, src => src.Region)
              .Map (dest => dest.Country, src => src.Country)
              .Map( dest => dest.Description, src => src.Description);

        config.NewConfig<Dto.Manager.DataCenter, HintItem>()
              .Map(dest => dest.Id, src => src.Id)
              .Map(dest => dest.Name, src => src.Name);
    }
}
