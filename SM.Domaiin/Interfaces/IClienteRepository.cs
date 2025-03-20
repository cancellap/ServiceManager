using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClienteByCnpjAsync(string cnpj);

        Task<Cliente?> GetByIdClientesAsync(int id);
    }
}
