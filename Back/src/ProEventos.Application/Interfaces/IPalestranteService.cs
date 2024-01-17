using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrantes(Palestrante model);
        Task<Palestrante> UpdatePalestrantes(int idPalestrante, Palestrante model);
        Task<bool> DeleteEventos(int idPalestrante);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}