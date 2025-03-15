using AutoMapper;

namespace SM.Infra.Mapping
{
    internal class Mapping : Profile 
    {
        public Mapping()
        {
            CreateMap<EnderecoSedeDto, EnderecoSede>();
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<Cliente, ClienteDto>();
        }
    }
}
