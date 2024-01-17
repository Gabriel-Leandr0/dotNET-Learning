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
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext _context;
        public GeralPersist(ProEventosContext context)
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
    }
}