using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    // A classe ProEventosPersistence serve para utilizar os métodos da interface IProEventosPersistence
    public class PalestrantePersist : IPalestrantePersist
    {
        public ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;            
        }


        // Palestrantes
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            // O Include é utilizado para incluir os palestrantes e redes sociais
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(p => p.RedesSociais);

            // Se includePalestrantes for true, inclui os palestrantes
            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            // O OrderBy ordena por Id
            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false)
        {
            // O Include é utilizado para incluir os palestrantes e redes sociais
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(p => p.RedesSociais);

            // Se includePalestrantes for true, inclui os palestrantes
            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return query.ToArrayAsync();
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int idPalestrante, bool includeEventos = false)
        {
                        // O Include é utilizado para incluir os palestrantes e redes sociais
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(p => p.RedesSociais);

            // Se includePalestrantes for true, inclui os palestrantes
            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
            .Where(p => p.Id == idPalestrante);
                        
            return query.FirstOrDefaultAsync(p => p.Id == idPalestrante);
        }


    }
}