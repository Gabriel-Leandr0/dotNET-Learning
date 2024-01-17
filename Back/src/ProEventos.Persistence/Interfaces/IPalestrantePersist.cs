using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    // A interface serve para definir um contrato
    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}