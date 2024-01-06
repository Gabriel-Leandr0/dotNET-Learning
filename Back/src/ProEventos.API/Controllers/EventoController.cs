using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "Exemplo GET";
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
