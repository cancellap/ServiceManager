using SM.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Interfaces
{
    interface IClienteService
    {
        Task<ClienteDto> CreateClienteAsync(ClienteCreateDto clienteDto);
        Task<IEnumerable<ClienteDto>> GetAllClientesAsync();
        Task<ClienteDto> GetClienteByIdAsync(int id);
        Task<ClienteDto> DeleteClienteAsync(int id);

    }
}
