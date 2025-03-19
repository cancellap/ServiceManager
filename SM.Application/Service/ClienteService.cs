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
    public class ClienteService(ClienteRespository clienteRepository, IMapper mapper, EnderecoRepository enderecoRepository) : IClienteService
    {
        private readonly EnderecoRepository _enderecoRepository = enderecoRepository;
        private readonly ClienteRespository _clienteRepository = clienteRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> ObterOuCriarEnderecoAsync(Endereco endereco)
        {
            var enderecoExistente = await _enderecoRepository.
                GetEnderecoByDetailsAsync(endereco.Rua, endereco.Cidade, endereco.Estado, endereco.Cep);


            if (enderecoExistente != null)
            {
                return enderecoExistente.Id;
            }

            await _enderecoRepository.AddAsync(endereco);


            return endereco.Id;
        }


        public async Task<ClienteDto> CreateClienteAsync(ClienteCreateDto clienteCreateDto)
        {

            var clienteExistente = await _clienteRepository.GetClienteByCnpjAsync(clienteCreateDto.Cnpj);

            if (clienteExistente != null)
                throw new Exception("Cliente já cadastrado");

            var cliente = _mapper.Map<Cliente>(clienteCreateDto);

            var enderecoCliente = cliente.EnderecoSede.Endereco;
            var enderecoId = await ObterOuCriarEnderecoAsync(enderecoCliente);
            Console.WriteLine(enderecoId);

            cliente.EnderecoSede.EnderecoId = enderecoId;

            var enderecoSedeEntity = _mapper.Map<EnderecoSede>(clienteCreateDto.EnderecoSedeCreateDto);
            cliente.EnderecoSede = enderecoSedeEntity;

            await _clienteRepository.AddAsync(cliente);

            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }

        public Task<ClienteDto> DeleteClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
        {
            var listaCliente = (await _clienteRepository.GetAll());
            if (listaCliente.Count == 0)
                return null;
            var dtos = _mapper.Map<IEnumerable<ClienteDto>>(listaCliente);
            return dtos;
        }


        public async Task<ClienteDto> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.FindOneId(id);
            if (cliente == null)
                return null;
            var dto = _mapper.Map<ClienteDto>(cliente);
            return dto;
        }
    }
}
