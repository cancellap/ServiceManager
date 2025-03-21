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
    public class EnderecoService : IEnderecoService
    {
        private readonly EnderecoRepository _enderecoRepository;

        public EnderecoService(EnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<int> ObterOuCriarEnderecoAsync(Endereco endereco)
        {
            if (endereco == null)
                throw new ArgumentNullException(nameof(endereco));

            var enderecoExistente = await _enderecoRepository.
                GetEnderecoByDetailsAsync(endereco.Rua, endereco.Cidade, endereco.Estado, endereco.Cep);

            if (enderecoExistente != null)
            {
                Console.WriteLine("Endereco já existe: " + enderecoExistente.Id);
                return enderecoExistente.Id;
            }

            await _enderecoRepository.AddAsync(endereco);

            Console.WriteLine("Endereco criado: " + endereco.Id);
            return endereco.Id;
        }

    }
}
