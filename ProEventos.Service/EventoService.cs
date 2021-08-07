using ProEventos.Domain;
using ProEventos.Repository.Interfaces;
using ProEventos.Sevice.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProEventos.Service
{
    public class EventoService : IEventoService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralRepository.Add<Evento>(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> Update(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralRepository.Update(model);

                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int eventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado!");

                _geralRepository.Delete<Evento>(evento);

                return await _geralRepository.SaveChangesAsync();
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
                var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventoByIdAsync(eventoId);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventosByTemaAsync(tema);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
