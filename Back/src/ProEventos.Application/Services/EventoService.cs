using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        // Injeção de dependência
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        // Métodos
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                // Adiciona o model no contexto
                _geralPersist.Add<Evento>(model);

                // Salva as alterações no banco de dados
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public async Task<Evento> UpdateEventos(int idEvento, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(idEvento, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);

                // Salva as alterações no banco de dados
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int idEvento)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(idEvento, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);

                // Salva as alterações no banco de dados
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int enventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(enventoId, includePalestrantes);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}