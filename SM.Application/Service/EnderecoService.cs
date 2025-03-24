using SM.Application.Interfaces;
using SM.Domaiin.Entities;
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

        public Task<int> ObterOuCriarEnderecoAsync(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
