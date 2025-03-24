using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Application.DTOs;
using SM.Domaiin.Entities;

namespace SM.Application.Interfaces
{
    public interface ITecnicoService
    {
        Task<TecnicoDto> CreateTecnicoAsync(TecnicoCreateDto tecnicoCreateDto);
        Task<IEnumerable<TecnicoDto>> GetAllTecnicoAsync();
        Task<TecnicoDto> GetTecnicoByIdAsync(int id);
        Task<TecnicoDto> DeleteTecnicoAsync(int id);
        Task<TecnicoDto> GetTecnicoByCpfAsync(string cpf);
    }
}
