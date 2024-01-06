using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Model;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> eventos = new Evento[]{
        new Evento()
            {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Santos-SP",
                Lote = "1º Lote",
                QtdPessoas = 26,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.jpg"
            },
            new Evento()
            {
                EventoId = 2,
                Tema = "Java",
                Local = "Santos-SP",
                Lote = "2º Lote",
                QtdPessoas = 246,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.jpg"
            },
        };
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetByID(int id)
        {
            return eventos.Where(evento => evento.EventoId == id );
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
