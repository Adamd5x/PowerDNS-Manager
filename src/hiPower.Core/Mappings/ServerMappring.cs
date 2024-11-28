namespace hiPower.Core.Mappings;

internal class ServerMappring : IRegister
{
    public void Register (TypeAdapterConfig config)
    {
        config.NewConfig<Dto.Manager.Server, Entity.Server> ()
               .Map (dest => dest.Id, src => src.Id)
               .Map (dest => dest.LocalId, src => src.LocalId)
               .Map (dest => dest.LocationId, src => src.LocationId)
               .Map (dest => dest.Name, src => src.Name)
               .Map (dest => dest.Proto, src => src.Proto)
               .Map (dest => dest.HostAddress, src => src.HostAddress)
               .Map (dest => dest.Port, src => src.Port)
               .Map (dest => dest.ApiKey, src => src.ApiKey)
               .Map (dest => dest.Auth, src => src.Auth)
               .Map (dest => dest.Version, src => src.Version)
               .Map (dest => dest.OS, src => src.OS)
               .Map (dest => dest.Configuration, src => src.Configuration)
               .Map (dest => dest.Timeout, src => src.Timeout)
               .Map (dest => dest.Retries, src => src.Retries);

        config.NewConfig<Entity.Server, Dto.Manager.Server> ()
               .Map (dest => dest.Id, src => src.Id)
               .Map (dest => dest.LocalId, src => src.LocalId)
               .Map (dest => dest.LocationId, src => src.LocationId)
               .Map (dest => dest.Name, src => src.Name)
               .Map (dest => dest.Proto, src => src.Proto)
               .Map (dest => dest.HostAddress, src => src.HostAddress)
               .Map (dest => dest.Port, src => src.Port)
               .Map (dest => dest.ApiKey, src => src.ApiKey)
               .Map (dest => dest.Auth, src => src.Auth)
               .Map (dest => dest.Version, src => src.Version)
               .Map (dest => dest.OS, src => src.OS)
               .Map (dest => dest.Configuration, src => src.Configuration)
               .Map (dest => dest.Timeout, src => src.Timeout)
               .Map (dest => dest.Retries, src => src.Retries);
    }
}
