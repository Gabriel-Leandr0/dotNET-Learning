using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;


namespace ProEventos.Persistence
{
    // A classe ProEventosPersistence serve para utilizar os métodos da interface IProEventosPersistence
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            // Injeção de dependência
            _context = context;

        }
        
        // Geral
        public void Add<T>(T entity) where T : class
        {
            // O Add recebe uma entidade
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            // O Update recebe uma entidade
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            // O Remove recebe uma entidade
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            // O RemoveRange recebe um array de entidades
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Se o retorno for maior que 0, significa que houve alteração no banco de dados
            return (await _context.SaveChangesAsync()) > 0;
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

        // Palestrantes

        public Task<Palestrante[]> GetAllPalestrantesAsync(int palestranteId, bool includeEventos = false)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            throw new NotImplementedException();
        }


    }
}