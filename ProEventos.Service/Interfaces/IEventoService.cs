using ProEventos.Service.DTO;
using System.Threading.Tasks;

namespace ProEventos.Service.Interfaces
{
    public interface IEventoService
    {
        Task<EventoDTO> AddEventos(EventoDTO model);
        Task<EventoDTO> Update(int eventoId, EventoDTO model);
        Task<bool> Delete(int eventoId);
        Task<EventoDTO[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDTO[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
