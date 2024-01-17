using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly ProEventosContext context;
        public EventosController(ProEventosContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetByID(int id)
        {
            return context.Eventos.FirstOrDefault(evento => evento.Id == id );
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo POST";
        }

        [HttpPut("{id}")]
        public string Put()
        {
            return "Exemplo PUT";
        }

        [HttpDelete("{id}")]
        public string Delete()
        {
            return "Exemplo DELETE";
        }
    }
}
