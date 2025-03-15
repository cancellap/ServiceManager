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
            return await _dBContext.Clientes
                .FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }
    }

}
