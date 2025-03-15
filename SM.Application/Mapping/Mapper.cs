using AutoMapper;
using SM.Domaiin.Entities; 
using SM.Application.DTOs; 

namespace SM.Application.Mapping
{
    public class Mapper : Profile 
    {
        public Mapper()
        {
            CreateMap<EnderecoSedeDto, EnderecoSede>();
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteDto, Cliente >();
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.enderecoSede, opt => opt.Ignore());

        }
    }
}
