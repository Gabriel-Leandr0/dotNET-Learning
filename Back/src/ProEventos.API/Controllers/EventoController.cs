using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Model;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext context;
        public EventoController(DataContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetByID(int id)
        {
            return context.Eventos.Where(evento => evento.EventoId == id );
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
