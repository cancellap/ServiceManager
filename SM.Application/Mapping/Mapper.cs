using AutoMapper;
using SM.Application.DTOs;
using SM.Domaiin.Entities;

namespace SM.Application.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Mapeamento de Cliente
            CreateMap<ClienteCreateDto, Cliente>()
                .ForMember(dest => dest.EnderecoComplemento, opt => opt.MapFrom(src => src.EnderecoComplementoCreateDto));

            CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.EnderecoComplementoDto, opt => opt.MapFrom(src => src.EnderecoComplemento));


            CreateMap<ClienteDto, Cliente>();
            CreateMap<EnderecoComplementoDto, EnderecoComplemento>();

            CreateMap<EnderecoComplemento, EnderecoComplementoDto>()
                 .ForMember(dest => dest.EnderecoDto, opt => opt.MapFrom(src => src.Endereco)) 
                 .ForMember(dest => dest.ClienteDto, opt => opt.Ignore())
                 .ForMember(dest => dest.TecnicoDto, opt => opt.Ignore());

            // Mapeamento de EnderecoComplemento
            CreateMap<EnderecoComplementoCreateDto, EnderecoComplemento>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento));

            // Mapeamento de Endereco
            CreateMap<Endereco, EnderecoDto>();

            // Mapeamento de Tecnico
            CreateMap<TecnicoCreateDto, Tecnico>()
                .ForMember(dest => dest.EnderecoComplemento, opt => opt.MapFrom(src => src.EnderecoComplementoCreateDto));

            CreateMap<Tecnico, TecnicoDto>()
                .ForMember(dest => dest.EnderecoComplementoDto, opt => opt.MapFrom(src => src.EnderecoComplemento));

            CreateMap<TecnicoDto, Tecnico>();
                
        }
    }
}