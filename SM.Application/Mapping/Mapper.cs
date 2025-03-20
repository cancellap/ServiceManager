using AutoMapper;
using SM.Application.DTOs;
using SM.Domaiin.Entities;
namespace SM.Application.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Cliente, ClienteCreateDto>()
                .ForMember(dest => dest.EnderecoSedeCreateDto, opt => opt.MapFrom(src => src.EnderecoSede));

            CreateMap<ClienteCreateDto, Cliente>()
                .ForMember(dest => dest.EnderecoSede, opt => opt.MapFrom(src => src.EnderecoSedeCreateDto));

            CreateMap<EnderecoSedeCreateDto, EnderecoSede>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento));

            CreateMap<ClienteDto, Cliente>()
                .ForMember(dest => dest.EnderecoSede, opt => opt.MapFrom(src => src.EnderecoSedeDto));



            CreateMap<Cliente, ClienteDto>()
             .ForMember(dest => dest.EnderecoSedeDto, opt => opt.MapFrom(src => src.EnderecoSede));

            CreateMap<EnderecoSede, EnderecoSedeDto>()
                .ForMember(dest => dest.EnderecoDto, opt => opt.MapFrom(src => src.Endereco));

            CreateMap<Endereco, EnderecoDto>();

        }
    }
}
