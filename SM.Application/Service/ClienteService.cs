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
    public class ClienteService(
        ClienteRepository clienteRepository,
        EnderecoRepository enderecoRepository,
        EnderecoComplementoRepository enderecoSedeRepository,
        EnderecoService enderecoService,
        IMapper mapper) : IClienteService
    {
        private readonly ClienteRepository _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        private readonly EnderecoRepository _enderecoRepository = enderecoRepository ?? throw new ArgumentNullException(nameof(enderecoRepository));
        private readonly EnderecoComplementoRepository _enderecoComplementoRepository = enderecoSedeRepository ?? throw new ArgumentNullException(nameof(enderecoSedeRepository));
        private readonly EnderecoService _enderecoService = enderecoService ?? throw new ArgumentNullException(nameof(enderecoService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        //colocar esse metodo dentro do EnderecoService, para que nao se repita aqui e no tecnicoService
        //public async Task<int> ObterOuCriarEnderecoAsync(Endereco endereco)
        //{
        //    var enderecoExistente = await _enderecoRepository.
        //        GetEnderecoByDetailsAsync(endereco.Rua, endereco.Cidade, endereco.Estado, endereco.Cep);

        //    if (enderecoExistente != null)
        //    {
        //        Console.WriteLine("Endereco já existe" + enderecoExistente.Id);
        //        return enderecoExistente.Id;
        //    }

        //    await _enderecoRepository.AddAsync(endereco);

        //    Console.WriteLine("Endereco criado" + endereco.Id);
        //    return endereco.Id;
        //}


        public async Task<ClienteDto> CreateClienteAsync(ClienteCreateDto clienteCreateDto)
        {
            var clienteExistente = await _clienteRepository.GetClienteByCnpjAsync(clienteCreateDto.Cnpj);
            if (clienteExistente != null)
                throw new InvalidOperationException("Cliente já cadastrado");

            var clienteEntity = _mapper.Map<Cliente>(clienteCreateDto);
            clienteEntity.EnderecoComplemento = null;

            var endereco = clienteCreateDto.EnderecoComplementoCreateDto.Endereco;
            int enderecoId = await _enderecoService.ObterOuCriarEnderecoAsync(endereco);
            if (enderecoId == 0)
                throw new InvalidOperationException("Erro ao obter ou criar o endereço.");

            var clienteCriado = await _clienteRepository.AddAsync(clienteEntity);

            var enderecoComplemento = new EnderecoComplemento
            {
                ClienteId = clienteCriado.Id,
                EnderecoId = enderecoId,
                Complemento = clienteCreateDto.EnderecoComplementoCreateDto.Complemento,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            await _enderecoComplementoRepository.AddAsync(enderecoComplemento);

            clienteCriado.EnderecoComplemento = enderecoComplemento;
            await _clienteRepository.updateClienteAsync(clienteCriado); 

            return _mapper.Map<ClienteDto>(clienteCriado);
        }

        public async Task<ClienteDto> DeleteClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdClientesAsync(id);

            var enderecoComplemento = cliente.EnderecoComplemento;

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            var clienteExcluido = await _clienteRepository.deleteAsync(cliente);
            await _enderecoComplementoRepository.deleteAsync(enderecoComplemento);

            return _mapper.Map<ClienteDto>(clienteExcluido);

        }

        public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
        {
            var listaCliente = (await _clienteRepository.GetAllClientesAsync());
            if (listaCliente.Count == 0)
                return null;
            var listaClientesDtos = _mapper.Map<IEnumerable<ClienteDto>>(listaCliente);
            return listaClientesDtos;
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
