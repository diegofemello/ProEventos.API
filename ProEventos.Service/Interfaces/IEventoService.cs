using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Sevice.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> Update(int eventoId, Evento model);
        Task<bool> Delete(int eventoId);
        Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
