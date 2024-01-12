using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        [ForeignKey("IdPalestrante")]
        public int IdPalestrante { get; set; }
        public Palestrante Palestrante { get; set; }

        [ForeignKey("IdEvento")]
        public int IdEvento { get; set; }
        public Evento Evento { get; set; } 
    }
}