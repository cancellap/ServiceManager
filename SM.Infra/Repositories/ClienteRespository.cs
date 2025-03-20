using Microsoft.EntityFrameworkCore;
using SM.Domaiin.Entities;
using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using SM.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infra.Repositories
{
    public class ClienteRespository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRespository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cliente?> GetClienteByCnpjAsync(string cnpj)
        {

            var cliente = await _dBContext.Clientes
               .Where(c => c.Cnpj == cnpj)
               .Include(c => c.EnderecoSede)
                   .ThenInclude(es => es.Endereco)
               .FirstOrDefaultAsync();

            return cliente;
        }

        public async Task<Cliente?> GetByIdClientesAsync(int id)
        {
            var cliente = await _dBContext.Clientes
                .Where(c => c.Id == id)
                .Include(c => c.EnderecoSede)
                    .ThenInclude(es => es.Endereco)
                .FirstOrDefaultAsync();

            return cliente;
        }
        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _dBContext.Clientes
                .Include(c => c.EnderecoSede)
                    .ThenInclude(es => es.Endereco)
                .ToListAsync();
        }
    }

}
