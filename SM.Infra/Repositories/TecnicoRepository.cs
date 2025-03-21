using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using SM.Infra.Repositories.Base;
using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SM.Infra.Repositories
{
    public class TecnicoRepository : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Tecnico?> GetTecnicoByCpfAsync(string cpf)
        {
            var tecnico = await _dBContext.Tecnicos
               .Where(c => c.Cpf == cpf)
               .Include(c => c.EnderecoComplemento)
                   .ThenInclude(es => es.Endereco)
               .FirstOrDefaultAsync();

            return tecnico;
        }
        public async Task<Tecnico?> GetTecnicoByIdAsync(int id)
        {
            var tecnico = await _dBContext.Tecnicos
               .Where(c => c.Id == id)
               .Include(c => c.EnderecoComplemento)
                   .ThenInclude(es => es.Endereco)
               .FirstOrDefaultAsync();

            return tecnico;

        }
        public async Task<List<Tecnico>> GetAllTecnicosAsync()
        {
            return await _dBContext.Tecnicos
                .Include(c => c.EnderecoComplemento)
                    .ThenInclude(es => es.Endereco)
                .ToListAsync();
        }
        public async Task<Tecnico> updateTecnicoAsync(Tecnico tecnico)
        {
            _dBContext.Tecnicos.Update(tecnico);
            await _dBContext.SaveChangesAsync();
            return tecnico;
        }
    }
}
