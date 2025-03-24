using SM.Application.DTOs;
using SM.Application.Interfaces;
using SM.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Service
{
    public class ServicosService : IServicosService
    {
        private readonly ServicosRepository _servicosRepository;

        Task<ServicosDto> IServicosService.CreateServicosAsync(ServicosCreateDto servicosDto)
        {
            
        }

        Task<ServicosDto> IServicosService.DeleteServicosAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ServicosDto>> IServicosService.GetAllServicosAsync()
        {
            throw new NotImplementedException();
        }

        Task<ServicosDto> IServicosService.GetServicosByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
