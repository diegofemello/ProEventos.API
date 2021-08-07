using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Repository;
using ProEventos.Repository.Contexts;

namespace ProEventos.API.Controllers
{
    [ApiController]
  [Route("[controller]")]
  public class EventoController : ControllerBase
  {
    private readonly ProEventosContext _context;
    public EventoController(ProEventosContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos.ToList();
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
      return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
    }
  }
}
