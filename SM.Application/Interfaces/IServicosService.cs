using System;
using SM.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Interfaces
{
    interface IServicosService
    {
        Task<ServicosDto> CreateServicosAsync(ServicosCreateDto servicosDto);
        Task<IEnumerable<ServicosDto>> GetAllServicosAsync();
        Task<ServicosDto> GetServicosByIdAsync(int id);
        Task<ServicosDto> DeleteServicosAsync(int id);
    }
}
