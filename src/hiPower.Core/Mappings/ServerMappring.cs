using hiPower.Common.Type.Extensions;
using hiPower.Common.Type.Options;

namespace hiPower.Core.Mappings;

internal class ServerMappring : IRegister
{
    public void Register (TypeAdapterConfig config)
    {
        config.NewConfig<Server, ServiceDetails> ()
               .Map (dest => dest.Id, src => src.Id)
               .Map (dest => dest.LocalId, src => src.LocalId)
               .Map (dest => dest.DataCenterId, src => src.DataCenterId)
               .Map (dest => dest.Name, src => src.Name)
               .Map (dest => dest.Description, src => src.Description)
               .Map (dest => dest.Proto, src => src.Proto)
               .Map (dest => dest.HostAddress, src => src.HostAddress)
               .Map (dest => dest.Port, src => src.Port)
               .Map (dest => dest.ApiKey, src => src.ApiKey)
               .Map (dest => dest.Auth, src => src.Auth)
               .Map (dest => dest.Version, src => src.Version)
               .Map (dest => dest.OS, src => src.OS)
               .Map (dest => dest.Configuration, src => src.Configuration)
               .Map(dest => dest.Mode, src => src.ServiceMode);

        config.NewConfig<ServiceDetails, Server> ()
               .Map (dest => dest.Id, src => src.Id)
               .Map (dest => dest.LocalId, src => src.LocalId)
               .Map (dest => dest.DataCenterId, src => src.DataCenterId)
               .Map (dest => dest.Name, src => src.Name)
               .Map (dest => dest.Description, src => src.Description)
               .Map (dest => dest.Proto, src => src.Proto)
               .Map (dest => dest.HostAddress, src => src.HostAddress)
               .Map (dest => dest.Port, src => src.Port)
               .Map (dest => dest.ApiKey, src => src.ApiKey)
               .Map (dest => dest.Auth, src => src.Auth)
               .Map (dest => dest.Version, src => src.Version)
               .Map (dest => dest.OS, src => src.OS)
               .Map (dest => dest.Configuration, src => src.Configuration)
               .Map( dest => dest.ServiceMode, src => src.Mode);

        config.NewConfig<ServiceDetails, RemoteServiceOptions> ()
              .MapWith (src => new RemoteServiceOptions(src.Proto.ToProtocol(), src.HostAddress, Convert.ToUInt16(src.Port), src.LocalId, src.ApiKey, src.Auth, src.Mode));
    }
}
