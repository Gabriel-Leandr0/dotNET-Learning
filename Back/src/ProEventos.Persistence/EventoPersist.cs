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
    public class EventoPersist : IEventoPersist
    {
        public ProEventosContext _context;
        
        public EventoPersist(ProEventosContext context)
        {
            _context = context;
        }

        // Eventos
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            // O Include é utilizado para incluir os palestrantes e redes sociais
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            // Se includePalestrantes for true, inclui os palestrantes
            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            // O OrderBy ordena por Id
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            // O Include é utilizado para incluir os palestrantes e redes sociais
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            // Se includePalestrantes for true, inclui os palestrantes
            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            // O OrderBy ordena por Id
            query = query.OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }


        public Task<Evento> GetEventoByIdAsync(int idEvento, bool includePalestrantes = false)
        {
            // O Include é utilizado para incluir os palestrantes e redes sociais
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            // Se includePalestrantes for true, inclui os palestrantes
            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            // O OrderBy ordena por Id
            query = query.OrderBy(e => e.Id)
                .Where(e => e.Id == idEvento);

            return query.FirstOrDefaultAsync();
        }

    }
}