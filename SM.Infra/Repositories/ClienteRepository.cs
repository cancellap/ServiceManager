using Microsoft.EntityFrameworkCore;
using SM.Domaiin.Entities;
using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using SM.Infra.Repositories.Base;

namespace SM.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cliente?> GetClienteByCnpjAsync(string cnpj)
        {

            var cliente = await _dBContext.Clientes
               .Where(c => c.Cnpj == cnpj)
               .Include(c => c.EnderecoComplemento)
                   .ThenInclude(es => es.Endereco)
               .FirstOrDefaultAsync();

            return cliente;
        }

        public async Task<Cliente> GetByIdClientesAsync(int id)
        {
            var cliente = _dBContext.Clientes
                .Include(c => c.EnderecoComplemento)
                .ThenInclude(ec => ec.Endereco) 
                .FirstOrDefault(c => c.Id == id);
            return cliente;
        }
        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _dBContext.Clientes
                .Include(c => c.EnderecoComplemento)
                    .ThenInclude(es => es.Endereco)
                .ToListAsync();
        }

        public async Task<Cliente> updateClienteAsync(Cliente cliente)
        {
            _dBContext.Clientes.Update(cliente);
            await _dBContext.SaveChangesAsync();
            return cliente;
        }
    }

}
