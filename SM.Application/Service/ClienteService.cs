using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
    public class ClienteService(ClienteRespository clienteRepository,
        IMapper mapper,
        EnderecoRepository enderecoRepository,
        EnderecoSedeRepository enderecoSedeRepository) : IClienteService
    {
        private readonly EnderecoRepository _enderecoRepository = enderecoRepository;
        private readonly ClienteRespository _clienteRepository = clienteRepository;
        private readonly EnderecoSedeRepository _enderecoSedeRepository = enderecoSedeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> ObterOuCriarEnderecoAsync(Endereco endereco)
        {
            var enderecoExistente = await _enderecoRepository.
                GetEnderecoByDetailsAsync(endereco.Rua, endereco.Cidade, endereco.Estado, endereco.Cep);

            if (enderecoExistente != null)
            {
                Console.WriteLine("Endereco já existe" + enderecoExistente.Id);
                return enderecoExistente.Id;
            }

            await _enderecoRepository.AddAsync(endereco);

            Console.WriteLine("Endereco criado" + endereco.Id);
            return endereco.Id;
        }


        public async Task<ClienteDto> CreateClienteAsync(ClienteCreateDto clienteCreateDto)
        {

            var clienteExistente = await _clienteRepository.GetClienteByCnpjAsync(clienteCreateDto.Cnpj);

            if (clienteExistente != null)
                throw new Exception("Cliente já cadastrado");

            var clienteEntity = _mapper.Map<Cliente>(clienteCreateDto);

            var endereco = clienteEntity.EnderecoSede.Endereco;

            int enderecoId = await ObterOuCriarEnderecoAsync(endereco);

            var enderecoSede = new EnderecoSede
            {
                ClienteId = clienteEntity.Id,
                EnderecoId = enderecoId,
                Complemento = clienteCreateDto.EnderecoSedeCreateDto.Complemento,
                CreatedAt = DateTime.UtcNow,
            };

            clienteEntity.EnderecoSede = enderecoSede;

            var clienteCriado = await _clienteRepository.AddAsync(clienteEntity);
            _enderecoRepository.AddAsync(endereco);
            _enderecoSedeRepository.AddAsync(clienteEntity.EnderecoSede);

            var clienteDto = _mapper.Map<ClienteDto>(clienteCriado);

            return clienteDto;

        }

        public async Task<ClienteDto> DeleteClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdClientesAsync(id);

            var enderecoSede = cliente.EnderecoSede;

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            var clienteExcluido = await _clienteRepository.deleteAsync(cliente);
            await _enderecoSedeRepository.deleteAsync(enderecoSede);

            return _mapper.Map<ClienteDto>(clienteExcluido);

        }

        public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
        {
            var listaCliente = (await _clienteRepository.GetAllClientesAsync());
            if (listaCliente.Count == 0)
                return null;
            var dtos = _mapper.Map<IEnumerable<ClienteDto>>(listaCliente);
            return dtos;
        }


        public async Task<ClienteDto> GetClienteByCnpjAsync(string cnpj)
        {
            var cliente = await _clienteRepository.GetClienteByCnpjAsync(cnpj);
            if (cliente == null)
                return null;
            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }

        public async Task<ClienteDto> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdClientesAsync(id);
            if (cliente == null)
                return null;
            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }
    }
}
