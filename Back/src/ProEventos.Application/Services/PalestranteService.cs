using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPalestranteService _palestrantePersist;

        // Injeção de dependência
        public PalestranteService(IGeralPersist geralPersist, IPalestranteService palestrantePersist)
        {
            _geralPersist = geralPersist;
            _palestrantePersist = palestrantePersist;
        }

        public async Task<Palestrante> AddPalestrantes(Palestrante model)
        {
            try
            {
                // Adiciona o model no contexto
                _geralPersist.Add<Palestrante>(model);

                // Salva as alterações no banco de dados
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Palestrante> UpdatePalestrantes(int idPalestrante, Palestrante model)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(idPalestrante, false);
                if (palestrante == null) return null;

                model.Id = palestrante.Id;

                _geralPersist.Update(model);

                // Salva as alterações no banco de dados
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
                }

                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int idPalestrante)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(idPalestrante, false);
                if (palestrante == null) throw new Exception("Palestrante para delete não encontrado.");

                _geralPersist.Delete<Palestrante>(palestrante);

                // Salva as alterações no banco de dados
                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesAsync(includeEventos);
                if (palestrantes == null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesAsyncByName(nome, includeEventos);
                if (palestrantes == null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, includeEventos);
                if (palestrante == null) return null;

                return palestrante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}