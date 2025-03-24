using Microsoft.EntityFrameworkCore;
using SM.Domaiin.Entities;
using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using SM.Infra.Repositories.Base;

namespace SM.Infra.Repositories
{
    public class ServicosRepository : BaseRepository<Servicos>, IServicosRepository
    {
        public ServicosRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
