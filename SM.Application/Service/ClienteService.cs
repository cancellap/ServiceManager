using AutoMapper;
using SM.Application.DTOs;
using SM.Application.Interfaces;
using SM.Domaiin.Entities;
using SM.Domaiin.Interfaces;
using SM.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Service
{
    public class ClienteService : IClienteService
    {

        private readonly ClienteRespository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(ClienteRespository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

       
        public async Task<ClienteDto> CreateClienteAsync(ClienteCreateDto clienteCreateDto)
        {

            var clienteExistente = await _clienteRepository.GetClienteByCnpjAsync(clienteCreateDto.Cnpj);

            if (clienteExistente != null)
                throw new Exception("Cliente já cadastrado");

            var clienteEntity = _mapper.Map<Cliente>(clienteCreateDto);

            var enderecoSedeEntity = _mapper.Map<EnderecoSede>(clienteCreateDto.EnderecoSede);
            clienteEntity.enderecoSede = enderecoSedeEntity;

            await _clienteRepository.AddAsync(clienteEntity);

            var clienteDto = _mapper.Map<ClienteDto>(clienteEntity);

            return clienteDto;
        }

        public Task<ClienteDto> DeleteClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDto> GetClienteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
