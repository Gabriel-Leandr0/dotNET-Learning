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
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext context;
        public EventosController(DataContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IEnumerable<Eventos> Get()
        {
            return context.Eventos;
        }

        [HttpGet("{id}")]
        public Eventos GetByID(int id)
        {
            return context.Eventos.FirstOrDefault(evento => evento.EventosId == id );
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
