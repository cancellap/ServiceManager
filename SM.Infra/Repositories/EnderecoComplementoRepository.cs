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
    public class EnderecoComplementoRepository : BaseRepository<EnderecoComplemento>, IEnderecoComplementoRepository
    {
        public EnderecoComplementoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
