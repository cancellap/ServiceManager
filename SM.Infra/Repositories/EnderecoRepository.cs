using Microsoft.EntityFrameworkCore;
using SM.Domaiin.Entities;
using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using SM.Infra.Repositories.Base;

namespace SM.Infra.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Endereco> GetEnderecoByDetailsAsync(string rua, string cidade, string estado, string cep)
        {
            var endereco = await _dBContext.Endereco
                                           .FirstOrDefaultAsync(e => e.Rua.Equals(rua) &&
                                                                     e.Cidade.Equals(cidade) &&
                                                                     e.Estado.Equals(estado) &&
                                                                     e.Cep.Equals(cep));

            return endereco;
        }
    }
}
